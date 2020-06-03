using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonstandardQuery.MyDataClasses {
    //Матрица достижимости, вида (базовая_таблица, целевая_таблица) -> (через какую соседнюю таблицу проходит связь, условие соединения с соседом)
    class RelationMatrix {
        //Матрица отношений (матрица достижимости)
        private Dictionary<string, Dictionary<string, RelationMatixElem>> Matrix { get; set; }
        //Таблицы БД, для которых строится матрица
        private List<TableInfo> DBTables;

        //Свойство для получения списка базовых таблиц
        public List<string> BaseTables {
            get {
                return Matrix.Keys.ToList();
            }
        }

        //Индексатор для доступа к части целевых таблиц
        public Dictionary<string, RelationMatixElem> this[string baseTable] {
            get { return Matrix[baseTable]; }
            set { Matrix[baseTable] = value; }
        }

        //Индексатор для выдачи связи
        public RelationMatixElem this[string baseTable, string aimTable] {
            get { return Matrix[baseTable][aimTable]; }
            set { Matrix[baseTable][aimTable] = value; }
        }

        //Конструктор
        public RelationMatrix(List<TableInfo> tables) {
            Matrix = new Dictionary<string, Dictionary<string, RelationMatixElem>>();
            int tablesCount = tables.Count; //количество таблиц
            foreach (var baseTable in tables) {
                Matrix[baseTable.TableName] = new Dictionary<string, RelationMatixElem>();
                foreach (var aimTable in tables) {
                    Matrix[baseTable.TableName][aimTable.TableName] = null;
                }
            }

            DBTables = tables;
        }

        //Получение списка непосредственных соседей таблицы по матрице отношений
        public List<string> GetNeighborTablesNames(string tableName) {
            List<string> neighborTableNames = new List<string>();
            foreach (var table in DBTables)
                if (Matrix[tableName][table.TableName] != null && Matrix[tableName][table.TableName].ViaTable == table.TableName)
                    neighborTableNames.Add(table.TableName);
            return neighborTableNames;
        }

        //Поиск в глубину для нашей матрицы
        //Результат в reachableTables - множество достижимых из таблицы curTableName таблиц
        public void GetConnectedTablesNames(HashSet<string> reachebleTables, string curTableName) {
            reachebleTables.Add(curTableName);
            var neighborTables = GetNeighborTablesNames(curTableName);
            foreach (var neighborTableName in neighborTables) {
                var tableName = neighborTableName;
                if (Matrix[curTableName][tableName] != null && !reachebleTables.Contains(tableName))
                    GetConnectedTablesNames(reachebleTables, tableName);
            }
        }

        //Получить путь соединения двух таблиц
        public void GetTwoTablesConnectionPath(string baseTable, string aimTable, List<string> tablesPath, List<string> connectionConditions) {
            tablesPath.Add(baseTable);
            if (Matrix[baseTable][aimTable] == null)
                return;
            string nextTableName = Matrix[baseTable][aimTable].ViaTable;
            connectionConditions.Add(Matrix[baseTable][aimTable].ConnectionCondition);
            GetTwoTablesConnectionPath(nextTableName, aimTable, tablesPath, connectionConditions);
        }
    }
}
