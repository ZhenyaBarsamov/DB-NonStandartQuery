using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonstandardQuery.MyDataClasses {
    class TableInfo {
        public string TableName { get; set; }
        public List<ColumnInfo> TableColumns { get; set; }
        //Имя колонки в БД(с кавычками)
        public string QualifiedTableName => $"\"{TableName}\"";
        //Отображаемое в интерфесе имя столбца
        public string DisplayedName => displayedNames.ContainsKey(TableName.ToLower()) ? displayedNames[TableName.ToLower()] : TableName;

        //Для отображения в интерфейсе
        public override string ToString() {
            return DisplayedName;
        }

        //Словарь с отображаемыми именами колонок
        private static Dictionary<string, string> displayedNames;
        //Метод для инициализации словаря
        public static void SetDisplayedNames(Dictionary<string, string> _displayedNames) {
            displayedNames = _displayedNames;
        }
    }
}
