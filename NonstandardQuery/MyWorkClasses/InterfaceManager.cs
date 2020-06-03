using NonstandardQuery.MyDataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonstandardQuery.MyWorkClasses {
    class InterfaceManager {
        //Инициализация листбокса объектами
        public void FillListBox(ListBox lb, IEnumerable<object> objects) {
            lb.Items.Clear();
            foreach (var obj in objects) {
                lb.Items.Add(obj);
            }
        }

        //Инициализация комбобокса объектами
        public void FillComboBox(ComboBox cb, IEnumerable<object> objects) {
            cb.Items.Clear();
            foreach (var obj in objects) {
                cb.Items.Add(obj);
            }
        }

        //Добавить новое условие в листвью
        public void AddConditionToListView(ListView lv, Condition condition) {
            var lvItem = new ListViewItem(new[] { condition.DisplayedColumnName, condition.Criterion, condition.Value.ToString(), condition.Ligament });
            lvItem.Tag = condition;
            lv.Items.Add(lvItem);
        }

        //Инициализация результирующего ListView
        public void CreateResultListView(ListView listView, List<ColumnInfo> selectingColumns) {
            //Очищаем элемент управления
            listView.Clear();
            //Добавляем колонки
            foreach (var selectingColumn in selectingColumns)
                listView.Columns.Add(selectingColumn.ToString());
        }
    }
}
