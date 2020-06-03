using NonstandardQuery.MyWorkClasses;
using System;
using System.Windows.Forms;
using NonstandardQuery.MyDataClasses;
using System.Collections.Generic;
using System.Linq;
using NpgsqlTypes;

namespace NonstandardQuery {
    public partial class MainForm : Form {
        //Поля формы
        InterfaceManager interfaceManager;
        DataManager dataManager;

        DataBaseInfo dataBaseInfo; //Инфа о БД
        List<ColumnInfo> columnsList; //Для хранения списка всех полей
        QueryManager queryManager;


        //Конструктор формы
        public MainForm() {
            InitializeComponent();
            //Инициализируем словарь для отображения полей
            var fileManager = new FileManager();
            var translateDict = fileManager.GetTranslateDictionary();
            ColumnInfo.SetDisplayedNames(translateDict);
            TableInfo.SetDisplayedNames(translateDict);
            //Получаем инфу о базе данных
            dataManager = new DataManager();
            var tablesDict = dataManager.GetFullTablesInfo();
            var tablesRelations = dataManager.GetRelationMatrix(tablesDict.Values.ToList());
            dataBaseInfo = new DataBaseInfo(tablesDict, tablesRelations);
            //Инициализация полей формы
            queryManager = new QueryManager(dataBaseInfo);
            interfaceManager = new InterfaceManager();
            //Инициализируем элементы управления формы
            columnsList = dataBaseInfo.GetAllColumnsList();
            interfaceManager.FillListBox(lbAllFields, columnsList);
            interfaceManager.FillComboBox(cbFields, columnsList);
        }


        //-------------------------------ВЫБОР ПОЛЕЙ------------------------------
        //Выбрать поле
        private void bSelectItem_Click(object sender, EventArgs e) {
            var addingItem = lbAllFields.SelectedItem;
            if (addingItem != null)
                lbSelectedFields.Items.Add(addingItem);
            //Добавляем его в доступные для сортировки
            lbAllFieldsForSort.Items.Add(addingItem);
        }
        
        //Выбрать все поля
        private void bSelectAllItems_Click(object sender, EventArgs e) {
            var allItems = lbAllFields.Items;
            foreach (var item in allItems)
                lbSelectedFields.Items.Add(item);
            //Добавляем их в доступные для сортировки
            foreach (var addingItem in allItems)
                lbAllFieldsForSort.Items.Add(addingItem);
        }

        //Убрать выбранное поле
        private void bRemoveItem_Click(object sender, EventArgs e) {
            var removingItem = lbSelectedFields.SelectedItem;
            if (removingItem != null)
                lbSelectedFields.Items.Remove(removingItem);
            //Удаляем его из доступных для сортировки
            lbAllFieldsForSort.Items.Remove(removingItem);
            //Ищем его в уже отсортированных полях, и удаляем, если есть
            int sortedFieldsCount = lbSortedFields.Items.Count;
            for (int i = 0; i < sortedFieldsCount; i++) {
                if (((OrderedColumn)lbSortedFields.Items[i]).Column.QualifiedColumnName == ((ColumnInfo)removingItem).QualifiedColumnName)
                    lbSortedFields.Items.RemoveAt(i);
            }
        }

        //Убрать все выбранные поля
        private void bRemoveAllItems_Click(object sender, EventArgs e) {
            lbSelectedFields.Items.Clear();
            //Удаляем их из доступных для сортировки
            lbAllFieldsForSort.Items.Clear();
            lbSortedFields.Items.Clear();
        }
        //------------------------------------------------------------------------


        //-----------------------ВЫБОР ПОРЯДКА СОРТИРОВКИ-------------------------
        //Добавление поля в сортируемые
        private void bAddFieldToSorted_Click(object sender, EventArgs e) {
            var addingdField = (ColumnInfo)lbAllFieldsForSort.SelectedItem;
            if (addingdField == null)
                return;
            var orderedField = new OrderedColumn { Column = addingdField, Desc = true};
            lbSortedFields.Items.Add(orderedField);
            //Удаляем его из списка доступных для сортировки
            lbAllFieldsForSort.Items.Remove(addingdField);
        }

        //Добавление всех полей в сортируемые
        private void bAddAllFieldsToSorted_Click(object sender, EventArgs e) {
            var allItems = lbAllFieldsForSort.Items;
            foreach (ColumnInfo field in allItems) {
                var orderedField = new OrderedColumn { Column = field, Desc = true };
                lbSortedFields.Items.Add(orderedField);
            }
            //Удаляем всё из списка доступных для сортировки
            lbAllFieldsForSort.Items.Clear();
        }

        //Удаление поля из сортируемых
        private void bRemoveFieldFromSorted_Click(object sender, EventArgs e) {
            var removingItem = (OrderedColumn)lbSortedFields.SelectedItem;
            if (removingItem != null) {
                lbSortedFields.Items.Remove(removingItem);
                //Добавляем поле в доступные для сортировки
                lbAllFieldsForSort.Items.Add(removingItem.Column);
            }
        }

        //Удаление всех полей из сортируемых
        private void bRemoveAllFieldsFromSorted_Click(object sender, EventArgs e) {
            var removingItems = lbSortedFields.Items;
            //Добавляем все поля в доступные для сортировки
            foreach (OrderedColumn removingItem in removingItems)
                lbAllFieldsForSort.Items.Add(removingItem.Column);
            lbSortedFields.Items.Clear();
        }

        //Поднять поле в списке сортируемых
        private void bUpFieldInSorted_Click(object sender, EventArgs e) {
            var uppingItemIndex = lbSortedFields.SelectedIndex;
            //Если выбран какой-то элемент, и выбран не первый - поднимаем
            if (uppingItemIndex != -1 && uppingItemIndex != 0) {
                var tmp = lbSortedFields.Items[uppingItemIndex - 1];
                lbSortedFields.Items[uppingItemIndex - 1] = lbSortedFields.Items[uppingItemIndex];
                lbSortedFields.Items[uppingItemIndex] = tmp;
            }
        }

        //Опустить поле в списке сортируемых
        private void bDownFieldInSorted_Click(object sender, EventArgs e) {
            var downingItemIndex = lbSortedFields.SelectedIndex;
            //Если выбран какой-то элемент, и выбран не последний - опускаем
            if (downingItemIndex != -1 && downingItemIndex != lbSortedFields.Items.Count - 1) {
                var tmp = lbSortedFields.Items[downingItemIndex + 1];
                lbSortedFields.Items[downingItemIndex + 1] = lbSortedFields.Items[downingItemIndex];
                lbSortedFields.Items[downingItemIndex] = tmp;
            }
        }

        //Сортировать поле по возрастанию
        private void rbIncreasingOrder_CheckedChanged(object sender, EventArgs e) {
            var curOrderedField = (OrderedColumn)lbSortedFields.SelectedItem;
            if (curOrderedField == null)
                return;
            curOrderedField.Desc = false;
        }

        //Сортировать поле по убыванию
        private void rbDecreasingOrder_CheckedChanged(object sender, EventArgs e) {
            var curOrderedField = (OrderedColumn)lbSortedFields.SelectedItem;
            if (curOrderedField == null)
                return;
            curOrderedField.Desc = true;
        }

        //Выбор другого сортируемого элемента
        private void lbSortedFields_SelectedIndexChanged(object sender, EventArgs e) {
            var curOrderedField = (OrderedColumn)lbSortedFields.SelectedItem;
            if (curOrderedField == null)
                return;
            if (curOrderedField.Desc)
                rbDecreasingOrder.Checked = true;
            else
                rbIncreasingOrder.Checked = true;
        }
        //------------------------------------------------------------------------



        //-----------------------ДОБАВЛЕНИЕ УСЛОВИЙ-------------------------------
        //Добавление условия
        private void bAddCondition_Click(object sender, EventArgs e) {
            //Проверки добавляемого условия на заполнение всех полей
            if (cbFields.SelectedItem == null || string.IsNullOrEmpty(cbCriterion.Text) || string.IsNullOrEmpty(cbFieldValue.Text) || string.IsNullOrEmpty(cbLigament.Text)) {
                MessageBox.Show("Были введены не все параметры условия!", "Ошибка");
                return;
            }
            //Проверка значения на правильность
            object value = null;
            var dataType = ((ColumnInfo)cbFields.SelectedItem).ColumnType;
            //Массив байт - не работает
            if (dataType == NpgsqlDbType.Bytea) {
                MessageBox.Show("Условия с полем данного типа не может быть добавлено", "Ошибка");
                return;
            }
            //Если текст, то это и есть значение
            if (dataType == NpgsqlDbType.Varchar || dataType == NpgsqlDbType.Text || dataType == NpgsqlDbType.Char)
                value = cbFieldValue.Text;
            //Если дата/время, используем связанный объект или пытаемся парсить строку
            else if (dataType == NpgsqlDbType.Date || dataType == NpgsqlDbType.Time || dataType == NpgsqlDbType.Timestamp) {
                if (cbFieldValue.SelectedItem == null) {
                    if (DateTime.TryParse(cbFieldValue.Text, out DateTime tmp))
                        value = tmp;
                }
                else
                    value = cbFieldValue.SelectedItem;
            }
            //Если числовые типы - парсим строку
            else if (dataType == NpgsqlDbType.Integer) {
                if (int.TryParse(cbFieldValue.Text, out int tmp))
                    value = tmp;
            }
            else if (dataType == NpgsqlDbType.Real) {
                if (float.TryParse(cbFieldValue.Text, out float tmp))
                    value = tmp;
            }
            else if (dataType == NpgsqlDbType.Double) {
                if (double.TryParse(cbFieldValue.Text, out double tmp))
                    value = tmp;
            }
            else if (dataType == NpgsqlDbType.Numeric) {
                if (decimal.TryParse(cbFieldValue.Text, out decimal tmp))
                    value = tmp;
            }
            //Если значение не было получено - ошибка
            if (value == null) {
                MessageBox.Show("Введено неверное значение!", "Ошибка");
                return;
            }
            //Добавление условия
            interfaceManager.AddConditionToListView(lvConditions,
                new Condition {
                    Column = (ColumnInfo)cbFields.SelectedItem,
                    Criterion = cbCriterion.Text,
                    Value = value,
                    Ligament = cbLigament.Text
                });
        }

        //Удаление условия
        private void bRemoveCondition_Click(object sender, EventArgs e) {
            var removingItems = lvConditions.SelectedItems;
            foreach (ListViewItem item in removingItems)
                lvConditions.Items.Remove(item);
        }

        //Смена выбранного поля
        private void cbFields_SelectedIndexChanged(object sender, EventArgs e) {
            var selectedField = (ColumnInfo)cbFields.SelectedItem;
            if (selectedField == null)
                return;
            var fieldValues = dataManager.GetColumnValues(selectedField.Table.TableName, selectedField.ColumnName);
            //Если было выбрано поле типа bytea, оборачиваем массивы в класс и запрещаем редактирование значений
            if (selectedField.ColumnType == NpgsqlTypes.NpgsqlDbType.Bytea) {
                int elemCount = fieldValues.Count;
                for (int i = 0; i < elemCount; i++) {
                    fieldValues[i] = ByteArray.ToByteArray((byte[])fieldValues[i]);
                }
                cbFieldValue.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else {
                cbFieldValue.DropDownStyle = ComboBoxStyle.DropDown;
            }

            interfaceManager.FillComboBox(cbFieldValue, fieldValues);
            cbFieldValue.Text = "";
        }
        //------------------------------------------------------------------------



        //---------------------------ОБЩИЕ ДЕЙСТВИЯ-------------------------------
        //Сброс
        private void bCancel_Click(object sender, EventArgs e) {
            lbSelectedFields.Items.Clear();
            lbSortedFields.Items.Clear();
            lvConditions.Items.Clear();
            lbAllFieldsForSort.Items.Clear();
            lvResult.Clear();
        }

        //Показать запрос
        private void bShowQuery_Click(object sender, EventArgs e) {
            //Если не выбрано ни одного поля - выход
            if (lbSelectedFields.Items.Count == 0)
                MessageBox.Show("Вы не выбрали ни одного поля!", "Ошибка");
            //Получаем список запрошенных столбцов
            List<ColumnInfo> selectingColumns = new List<ColumnInfo>();
            foreach (ColumnInfo column in lbSelectedFields.Items)
                selectingColumns.Add(column);
            //Получаем список запрошенных условий
            List<Condition> conditions = new List<Condition>();
            foreach (ListViewItem lvCondition in lvConditions.Items)
                conditions.Add((Condition)lvCondition.Tag);
            //Получаем список правил сортировки
            List<OrderedColumn> orders = new List<OrderedColumn>();
            foreach (OrderedColumn order in lbSortedFields.Items)
                orders.Add(order);
            //Получаем текст запроса
            string queryText = queryManager.GetQueryText(selectingColumns, conditions, orders, true);
            //Выводим запрос
            MessageBox.Show(queryText, "Текст запроса");
        }

        //Выполнить запрос
        private void bDoQuery_Click(object sender, EventArgs e) {
            //Если не выбрано ни одного поля - выход
            if (lbSelectedFields.Items.Count == 0)
                MessageBox.Show("Вы не выбрали ни одного поля!", "Ошибка");
            //Получаем список запрошенных столбцов
            List<ColumnInfo> selectingColumns = new List<ColumnInfo>();
            foreach (ColumnInfo column in lbSelectedFields.Items)
                selectingColumns.Add(column);
            //Получаем список запрошенных условий
            List<Condition> conditions = new List<Condition>();
            foreach (ListViewItem lvCondition in lvConditions.Items)
                conditions.Add((Condition)lvCondition.Tag);
            //Получаем список правил сортировки
            List<OrderedColumn> orders = new List<OrderedColumn>();
            foreach (OrderedColumn order in lbSortedFields.Items)
                orders.Add(order);
            //Получаем текст запроса
            string queryText = queryManager.GetQueryText(selectingColumns, conditions, orders, false);
            //Инициализируем таблицу
            interfaceManager.CreateResultListView(lvResult, selectingColumns);
            //Выполняем запрос
            if (!dataManager.ExecuteQuery(lvResult, selectingColumns, conditions, queryText)) {
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка");
                return;
            }
            tcMain.SelectedIndex = 3;
            MessageBox.Show("Запрос успешно выполнен", "Запрос");
            //Показываем таблицу
        }
        //------------------------------------------------------------------------
    }
}
