using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NonstandardQuery.MyDataClasses;
using Npgsql;
using NpgsqlTypes;

namespace NonstandardQuery.MyWorkClasses {
    class DataManager {
        //Поля класса
        //public DataBaseInfo DBInfo { get; set; }

        //Строка подключения, формируется из cfg-файла
        private readonly string sConnStr = new NpgsqlConnectionStringBuilder {
            Host = DataBaseSetting.Default.Host,
            Port = DataBaseSetting.Default.Port,
            Database = DataBaseSetting.Default.DataBaseName,
            Username = DataBaseSetting.Default.Login,
            Password = DataBaseSetting.Default.Password,
            MaxAutoPrepare = 10,
            AutoPrepareMinUsages = 2
        }.ConnectionString;

        //Метод получения информации о таблицах
        private  List<TableInfo> GetTablesInfo() {
            List<TableInfo> res = new List<TableInfo>();
            using (var sConn = new NpgsqlConnection(sConnStr)) {
                //Проверка соединения
                try {
                    sConn.Open();
                }
                catch {
                    return null;
                }
                //Формируем команду
                var sCommand = new NpgsqlCommand {
                    Connection = sConn,
                    CommandText = @"
SELECT table_name
FROM information_schema.tables
WHERE table_schema = 'public'
"
                };
                //Запрос
                using (var reader = sCommand.ExecuteReader()) {
                    while (reader.Read()) {
                        res.Add(new TableInfo { TableName = (string)reader["table_name"] });
                    }
                }
            }
            return res;
        }
        
        //Метод получения информации о колонках таблицы
        private List<ColumnInfo> GetColumnsInfo(TableInfo tableInfo) {
            List<ColumnInfo> res = new List<ColumnInfo>();
            using (var sConn = new NpgsqlConnection(sConnStr)) {
                //Проверка подключения
                try {
                    sConn.Open();
                }
                catch {
                    return null;
                }
                //Формируем команду
                var sCommand = new NpgsqlCommand {
                    Connection = sConn,
                    CommandText = @"
SELECT table_name, column_name, data_type
FROM information_schema.columns
WHERE table_schema = 'public' AND table_name = @table_name
"
                };
                sCommand.Parameters.AddWithValue("@table_name", tableInfo.TableName);
                //Запрос и заполнение списка
                using (var reader = sCommand.ExecuteReader()) {
                    while (reader.Read()) {
                        res.Add(new ColumnInfo { Table = tableInfo, ColumnName = (string)reader["column_name"], ColumnType = DataBaseInfo.GetNpgDataType((string)reader["data_type"]) });
                    }
                }
            }
            return res;
        }

        //Метод получения полной информации о таблицах БД
        public Dictionary<string, TableInfo> GetFullTablesInfo() {
            Dictionary<string, TableInfo> fullInfo = new Dictionary<string, TableInfo>();
            //Получаем список таблиц
            var tables = GetTablesInfo();
            //Если вдруг была ошибка
            if (tables == null)
                return null;
            //Для каждой таблицы получаем инфу о её колонках и записываем всё в словарь
            foreach (var table in tables) {
                var tableColumns = GetColumnsInfo(table);
                //Если вдруг была ошибка
                if (tableColumns == null)
                    return null;
                table.TableColumns = tableColumns;
                fullInfo[table.TableName] = table;
            }
            return fullInfo;
        }

        //Метод получения первичной информации о связях таблиц из БД
        private bool GetDBTablesRelations(RelationMatrix relationMatrix) {;
            using (var sConn = new NpgsqlConnection(sConnStr)) {
                //Проверка подключения
                try {
                    sConn.Open();
                }
                catch {
                    return false;
                }
                //Формируем команду
                var sCommand = new NpgsqlCommand {
                    Connection = sConn,
                    CommandText = @"
SELECT t1.table_name AS base_table,
       t1.column_name AS base_column,
       t2.table_name AS aim_table,
       t2.column_name AS aim_column
FROM information_schema.key_column_usage AS t1
         JOIN
     information_schema.constraint_column_usage AS t2
     ON t1.constraint_schema = t2.constraint_schema AND t1.constraint_name = t2.constraint_name
         JOIN
     information_schema.table_constraints AS t3
     ON t2.constraint_schema = t3.constraint_schema AND t2.constraint_name = t3.constraint_name
WHERE t3.constraint_type = 'FOREIGN KEY' AND t1.constraint_schema = 'public'
"
                };
                //Запрос и заполнение списка
                using (var reader = sCommand.ExecuteReader()) {
                    while (reader.Read()) {
                        var baseTableName = (string)reader["base_table"];
                        var baseColumnName = (string)reader["base_column"];
                        var aimTableName = (string)reader["aim_table"];
                        var aimColumnName = (string)reader["aim_column"];
                        string connectionCondition = $"\"{baseTableName}\".\"{baseColumnName}\" = \"{aimTableName}\".\"{aimColumnName}\"";

                        //Создаём двухстороннюю связь
                        relationMatrix[baseTableName][aimTableName] =
                            new RelationMatixElem {
                                ViaTable = aimTableName,
                                ConnectionCondition = connectionCondition
                            };
                        relationMatrix[aimTableName][baseTableName] =
                            new RelationMatixElem {
                                ViaTable = baseTableName,
                                ConnectionCondition = connectionCondition
                            };
                    }
                }
            }
            return true;
        }

        //Метод формирования матрицы связей таблиц БД. (параметр)(матрица достижимости)
        public RelationMatrix GetRelationMatrix(List<TableInfo> tables) {
            RelationMatrix relationMatrix = new RelationMatrix(tables);
            //Заполним матрицу первоначальными данными. Не смогли - ошибка
            if (!GetDBTablesRelations(relationMatrix))
                return null;
            //Составляем список имён всех таблиц
            var allTableNames = new List<string>();
            foreach (var table in tables)
                allTableNames.Add(table.TableName);
            //Заполняем матрицу
            foreach (var baseTableName in allTableNames) {
                //Получаем список соседей этой таблицы
                var neighborTableNames = relationMatrix.GetNeighborTablesNames(baseTableName);
                //Для каждого соседа ищем достижимые вершины
                foreach (var neighborTableName in neighborTableNames) {
                    var reachebleTables = new HashSet<string>(); //множество достижимых из соседней таблицы таблиц
                    reachebleTables.Add(baseTableName); //базовая таблица достижима - в неё идти не надо
                    relationMatrix.GetConnectedTablesNames(reachebleTables, neighborTableName);
                    reachebleTables.Remove(baseTableName); //убираем базовую таблицу из множества достижимых - здесь она нам не нужна
                    //Помечаем достижимые из соседа вершины как достижимые из базовой таблицы, делаем в матрице соотв. запись
                    foreach (var reachebleTableName in reachebleTables)
                        relationMatrix[baseTableName][reachebleTableName] = new RelationMatixElem {
                            ViaTable = neighborTableName,
                            ConnectionCondition = relationMatrix[baseTableName][neighborTableName].ConnectionCondition
                        };
                }
            }
            return relationMatrix;
        }

        //Метод получения значений поля из БД
        public List<object> GetColumnValues(string tableName, string fieldName) {
            List<object> res = new List<object>();
            using (var sConn = new NpgsqlConnection(sConnStr)) {
                //Проверка подключения
                try {
                    sConn.Open();
                }
                catch {
                    return null;
                }
                //Формируем команду
                var sCommand = new NpgsqlCommand {
                    Connection = sConn,
                    CommandText = $@"
SELECT DISTINCT ""{fieldName}""
FROM ""{tableName}""
"
                };
                //Запрос и заполнение списка
                using (var reader = sCommand.ExecuteReader()) {
                    while (reader.Read()) {
                        res.Add(reader[fieldName]);
                    }
                }
            }
            return res;
        }

        //*Вставлять параметры объектами - можно. Получить текст параметризованного запроса - только с параметром

        //Выполнить запрос и заполнить результирующую таблицу
        public bool ExecuteQuery(ListView listView, List<ColumnInfo> selectingColumns, List<Condition> conditions, string queryText) {
            using (var sConn = new NpgsqlConnection(sConnStr)) {
                //Проверка подключения
                try {
                    sConn.Open();
                }
                catch {
                    return false;
                }
                //Формируем команду
                var sCommand = new NpgsqlCommand {
                    Connection = sConn,
                    CommandText = queryText
                };
                //Добавляем параметры = имя параметра + номер условия
                for (int i = 0; i <conditions.Count; i++)
                    sCommand.Parameters.AddWithValue(conditions[i].Column.ParamName + i.ToString(), conditions[i].Value);
                //Запрос и заполнение списка
                NpgsqlDataReader reader;
                try {
                    reader = sCommand.ExecuteReader();
                }
                catch {
                    return false;
                }
                while (reader.Read()) {
                    //Собираем значения в список
                    List<string> values = new List<string>();
                    foreach (var column in selectingColumns) {
                        values.Add(reader[column.Table.TableName + "." + column.ColumnName].ToString());
                    }
                    //Добавляем новую строку в результирующую таблицу
                    listView.Items.Add(
                        new ListViewItem(values.ToArray())
                    );
                }
            }
            //Авторесайз столбцов таблицы
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            return true;
        }
    }
}
