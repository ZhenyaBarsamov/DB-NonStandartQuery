using NpgsqlTypes;
using System.Collections.Generic;
using NonstandardQuery.MyWorkClasses;

namespace NonstandardQuery.MyDataClasses {
    class ColumnInfo {
        public TableInfo Table { get; set; }
        public string ColumnName { get; set; }
        public NpgsqlDbType ColumnType { get; set; }
        //Название для печати в интерфейсе
        public string DisplayedName => displayedNames.ContainsKey(ColumnName.ToLower()) ? displayedNames[ColumnName.ToLower()] : ColumnName;
        //Полное название для БД в кавычках
        public string QualifiedColumnName => $"\"{Table.TableName}\".\"{ColumnName}\"";

        //Для отображения в элементах управления
        public override string ToString() {
            return $"{Table}: {DisplayedName}";
        }

        //Имя параметра для данного поля
        public string ParamName => $"@{Table.TableName}.{ColumnName}";

        //Словарь с отображаемыми именами колонок
        private static Dictionary<string, string> displayedNames;
        //Метод для инициализации словаря
        public static void SetDisplayedNames(Dictionary<string, string> _displayedNames) {
            displayedNames = _displayedNames;
        }
    }
}
