using System;
using System.Collections.Generic;
using NpgsqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonstandardQuery.MyDataClasses {
    class DataBaseInfo {
        //Имя таблицы-информация о таблице
        public Dictionary<string, TableInfo> TablesDict {get; set; }
        //Матрица достижимости таблиц
        public RelationMatrix Relations { get; set; }

        //Конструктор
        public DataBaseInfo(Dictionary<string, TableInfo> tablesDict, RelationMatrix relations) {
            TablesDict = tablesDict;
            Relations = relations;
        }

        //Формирование списка всех полей БД
        public List<ColumnInfo> GetAllColumnsList() {
            var res = new List<ColumnInfo>();

            var tables = TablesDict.Values;
            foreach (var table in tables) {
                foreach (var column in table.TableColumns) {
                    res.Add(column);
                }
            }
            return res;
        }

        //Метод получения типа по его названию
        public static NpgsqlDbType GetNpgDataType(string typeName) {
            if (typeName == "character varying")
                return NpgsqlDbType.Varchar;
            else if (typeName == "text")
                return NpgsqlDbType.Text;
            else if (typeName == "char")
                return NpgsqlDbType.Char;
            else if (typeName == "integer")
                return NpgsqlDbType.Integer;
            else if (typeName == "real")
                return NpgsqlDbType.Real;
            else if (typeName == "double precision")
                return NpgsqlDbType.Double;
            else if (typeName == "numeric")
                return NpgsqlDbType.Numeric;
            else if (typeName == "bytea")
                return NpgsqlDbType.Bytea;
            else if (typeName == "date")
                return NpgsqlDbType.Date;
            else if (typeName == "time")
                return NpgsqlDbType.Time;
            else if (typeName == "timestamp")
                return NpgsqlDbType.Timestamp;
            else
                //На всякий случай
                throw new ArgumentException("Имя типа не подошло ни к одному типу из БД");
        }
    }
}
