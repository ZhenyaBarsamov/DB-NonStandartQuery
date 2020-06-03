using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonstandardQuery.MyDataClasses {
    class RelationMatixElem {
        //Путь проходит через таблицу...
        public string ViaTable { get; set; }
        //Условие соединения этой таблицы со следующей по пути
        public string ConnectionCondition { get; set; }

        //Для отладки
        public override string ToString() {
            return $"Via {ViaTable}";
        }
    }
}
