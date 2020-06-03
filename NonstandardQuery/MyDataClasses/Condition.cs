using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonstandardQuery.MyDataClasses {
    class Condition {
        public ColumnInfo Column { get; set; }
        //Отображаемое в интерфейсе имя колонки
        public string DisplayedColumnName => $"{Column.Table.DisplayedName}:  {Column.DisplayedName}";
        //Критерий для условия
        public string Criterion { get; set; }
        //Значение - объект
        public object Value { get; set; }
        //Связка (И, ИЛИ)
        public string Ligament { get; set; }


        //Получить связку на языке SQL
        public string GetSqlLigament() {
            if (Ligament == "И")
                return "AND";
            else
                return "OR";
        }

        //Вернуть форматированное значение столбца (в кавычки/без них)
        public string GetFormattedValue(ColumnInfo thisColumn, object value) {
            NpgsqlDbType columnType = thisColumn.ColumnType;
            if (columnType == NpgsqlDbType.Varchar || columnType == NpgsqlDbType.Text || columnType == NpgsqlDbType.Char || columnType == NpgsqlDbType.Bytea
                || columnType == NpgsqlDbType.Date || columnType == NpgsqlDbType.Time || columnType == NpgsqlDbType.Timestamp) {
                return $"'{value}'";
            }
            else if (columnType == NpgsqlDbType.Integer || columnType == NpgsqlDbType.Real || columnType == NpgsqlDbType.Double || columnType == NpgsqlDbType.Numeric) {
                return $"{value}";
            }
            else
                //На всякий случай
                throw new ArgumentException();
        }

        //Условие для помещения в запрос (для вывода запроса)
        public string ConditionString => $"{Column.QualifiedColumnName} {Criterion} {GetFormattedValue(Column, Value)}";

        //Условие с параметром для помещения в запрос (для выполнения запроса)
        public string ParametrizedConditionString => $"{Column.QualifiedColumnName} {Criterion} {Column.ParamName}";
    }
}
