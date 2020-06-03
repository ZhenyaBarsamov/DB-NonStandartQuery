using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonstandardQuery.MyDataClasses {
    class OrderedColumn {
        public ColumnInfo Column { get; set; }
        public bool Desc { get; set; } //По убыванию ли?
        //Строка сортировки для помещения в запрос
        public string OrderedColumnStr => $"{Column.QualifiedColumnName}{(Desc ? " DESC" : "")}";

        //Для отображения в интерфейсе
        public override string ToString() {
            return Column.ToString();
        }
    }
}
