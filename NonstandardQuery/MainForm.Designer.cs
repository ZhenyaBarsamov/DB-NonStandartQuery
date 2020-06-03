namespace NonstandardQuery {
    partial class MainForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpFields = new System.Windows.Forms.TabPage();
            this.bRemoveAllFields = new System.Windows.Forms.Button();
            this.bRemoveField = new System.Windows.Forms.Button();
            this.bSelectAllIFields = new System.Windows.Forms.Button();
            this.bSelectField = new System.Windows.Forms.Button();
            this.gbSelectedFileds = new System.Windows.Forms.GroupBox();
            this.lbSelectedFields = new System.Windows.Forms.ListBox();
            this.gbAllFields = new System.Windows.Forms.GroupBox();
            this.lbAllFields = new System.Windows.Forms.ListBox();
            this.tpConditions = new System.Windows.Forms.TabPage();
            this.gbLigament = new System.Windows.Forms.GroupBox();
            this.cbLigament = new System.Windows.Forms.ComboBox();
            this.gbFieldValue = new System.Windows.Forms.GroupBox();
            this.cbFieldValue = new System.Windows.Forms.ComboBox();
            this.gbCriterion = new System.Windows.Forms.GroupBox();
            this.cbCriterion = new System.Windows.Forms.ComboBox();
            this.gbFields = new System.Windows.Forms.GroupBox();
            this.cbFields = new System.Windows.Forms.ComboBox();
            this.bRemoveCondition = new System.Windows.Forms.Button();
            this.bAddCondition = new System.Windows.Forms.Button();
            this.lvConditions = new System.Windows.Forms.ListView();
            this.fieldNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CriterionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filedValueColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ligamentColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpOrder = new System.Windows.Forms.TabPage();
            this.bRemoveAllFieldsFromSorted = new System.Windows.Forms.Button();
            this.bRemoveFieldFromSorted = new System.Windows.Forms.Button();
            this.bAddAllFieldsToSorted = new System.Windows.Forms.Button();
            this.bAddFieldToSorted = new System.Windows.Forms.Button();
            this.gbSortedFields = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bUpFieldInSorted = new System.Windows.Forms.Button();
            this.bDownFieldInSorted = new System.Windows.Forms.Button();
            this.gbOrder = new System.Windows.Forms.GroupBox();
            this.rbDecreasingOrder = new System.Windows.Forms.RadioButton();
            this.rbIncreasingOrder = new System.Windows.Forms.RadioButton();
            this.lbSortedFields = new System.Windows.Forms.ListBox();
            this.gbFieldsForSort = new System.Windows.Forms.GroupBox();
            this.lbAllFieldsForSort = new System.Windows.Forms.ListBox();
            this.tpResult = new System.Windows.Forms.TabPage();
            this.lvResult = new System.Windows.Forms.ListView();
            this.bShowQuery = new System.Windows.Forms.Button();
            this.bDoQuery = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.tcMain.SuspendLayout();
            this.tpFields.SuspendLayout();
            this.gbSelectedFileds.SuspendLayout();
            this.gbAllFields.SuspendLayout();
            this.tpConditions.SuspendLayout();
            this.gbLigament.SuspendLayout();
            this.gbFieldValue.SuspendLayout();
            this.gbCriterion.SuspendLayout();
            this.gbFields.SuspendLayout();
            this.tpOrder.SuspendLayout();
            this.gbSortedFields.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbOrder.SuspendLayout();
            this.gbFieldsForSort.SuspendLayout();
            this.tpResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpFields);
            this.tcMain.Controls.Add(this.tpConditions);
            this.tcMain.Controls.Add(this.tpOrder);
            this.tcMain.Controls.Add(this.tpResult);
            this.tcMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tcMain.Location = new System.Drawing.Point(12, 12);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1519, 681);
            this.tcMain.TabIndex = 0;
            // 
            // tpFields
            // 
            this.tpFields.Controls.Add(this.bRemoveAllFields);
            this.tpFields.Controls.Add(this.bRemoveField);
            this.tpFields.Controls.Add(this.bSelectAllIFields);
            this.tpFields.Controls.Add(this.bSelectField);
            this.tpFields.Controls.Add(this.gbSelectedFileds);
            this.tpFields.Controls.Add(this.gbAllFields);
            this.tpFields.Location = new System.Drawing.Point(4, 27);
            this.tpFields.Name = "tpFields";
            this.tpFields.Padding = new System.Windows.Forms.Padding(3);
            this.tpFields.Size = new System.Drawing.Size(1511, 650);
            this.tpFields.TabIndex = 0;
            this.tpFields.Text = "Поля";
            this.tpFields.UseVisualStyleBackColor = true;
            // 
            // bRemoveAllFields
            // 
            this.bRemoveAllFields.Location = new System.Drawing.Point(729, 368);
            this.bRemoveAllFields.Name = "bRemoveAllFields";
            this.bRemoveAllFields.Size = new System.Drawing.Size(50, 31);
            this.bRemoveAllFields.TabIndex = 5;
            this.bRemoveAllFields.Text = "<<";
            this.bRemoveAllFields.UseVisualStyleBackColor = true;
            this.bRemoveAllFields.Click += new System.EventHandler(this.bRemoveAllItems_Click);
            // 
            // bRemoveField
            // 
            this.bRemoveField.Location = new System.Drawing.Point(729, 318);
            this.bRemoveField.Name = "bRemoveField";
            this.bRemoveField.Size = new System.Drawing.Size(50, 31);
            this.bRemoveField.TabIndex = 4;
            this.bRemoveField.Text = "<";
            this.bRemoveField.UseVisualStyleBackColor = true;
            this.bRemoveField.Click += new System.EventHandler(this.bRemoveItem_Click);
            // 
            // bSelectAllIFields
            // 
            this.bSelectAllIFields.Location = new System.Drawing.Point(729, 270);
            this.bSelectAllIFields.Name = "bSelectAllIFields";
            this.bSelectAllIFields.Size = new System.Drawing.Size(50, 31);
            this.bSelectAllIFields.TabIndex = 3;
            this.bSelectAllIFields.Text = ">>";
            this.bSelectAllIFields.UseVisualStyleBackColor = true;
            this.bSelectAllIFields.Click += new System.EventHandler(this.bSelectAllItems_Click);
            // 
            // bSelectField
            // 
            this.bSelectField.Location = new System.Drawing.Point(729, 222);
            this.bSelectField.Name = "bSelectField";
            this.bSelectField.Size = new System.Drawing.Size(50, 31);
            this.bSelectField.TabIndex = 2;
            this.bSelectField.Text = ">";
            this.bSelectField.UseVisualStyleBackColor = true;
            this.bSelectField.Click += new System.EventHandler(this.bSelectItem_Click);
            // 
            // gbSelectedFileds
            // 
            this.gbSelectedFileds.Controls.Add(this.lbSelectedFields);
            this.gbSelectedFileds.Location = new System.Drawing.Point(785, 7);
            this.gbSelectedFileds.Name = "gbSelectedFileds";
            this.gbSelectedFileds.Size = new System.Drawing.Size(720, 638);
            this.gbSelectedFileds.TabIndex = 1;
            this.gbSelectedFileds.TabStop = false;
            this.gbSelectedFileds.Text = "Выбранные поля";
            // 
            // lbSelectedFields
            // 
            this.lbSelectedFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSelectedFields.FormattingEnabled = true;
            this.lbSelectedFields.ItemHeight = 18;
            this.lbSelectedFields.Location = new System.Drawing.Point(3, 20);
            this.lbSelectedFields.Name = "lbSelectedFields";
            this.lbSelectedFields.Size = new System.Drawing.Size(714, 615);
            this.lbSelectedFields.TabIndex = 1;
            // 
            // gbAllFields
            // 
            this.gbAllFields.Controls.Add(this.lbAllFields);
            this.gbAllFields.Location = new System.Drawing.Point(6, 6);
            this.gbAllFields.Name = "gbAllFields";
            this.gbAllFields.Size = new System.Drawing.Size(720, 639);
            this.gbAllFields.TabIndex = 0;
            this.gbAllFields.TabStop = false;
            this.gbAllFields.Text = "Все поля";
            // 
            // lbAllFields
            // 
            this.lbAllFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAllFields.FormattingEnabled = true;
            this.lbAllFields.ItemHeight = 18;
            this.lbAllFields.Items.AddRange(new object[] {
            "Один",
            "Два",
            "Три"});
            this.lbAllFields.Location = new System.Drawing.Point(3, 20);
            this.lbAllFields.Name = "lbAllFields";
            this.lbAllFields.Size = new System.Drawing.Size(714, 616);
            this.lbAllFields.TabIndex = 0;
            // 
            // tpConditions
            // 
            this.tpConditions.Controls.Add(this.gbLigament);
            this.tpConditions.Controls.Add(this.gbFieldValue);
            this.tpConditions.Controls.Add(this.gbCriterion);
            this.tpConditions.Controls.Add(this.gbFields);
            this.tpConditions.Controls.Add(this.bRemoveCondition);
            this.tpConditions.Controls.Add(this.bAddCondition);
            this.tpConditions.Controls.Add(this.lvConditions);
            this.tpConditions.Location = new System.Drawing.Point(4, 27);
            this.tpConditions.Name = "tpConditions";
            this.tpConditions.Padding = new System.Windows.Forms.Padding(3);
            this.tpConditions.Size = new System.Drawing.Size(1511, 650);
            this.tpConditions.TabIndex = 1;
            this.tpConditions.Text = "Условия";
            this.tpConditions.UseVisualStyleBackColor = true;
            // 
            // gbLigament
            // 
            this.gbLigament.Controls.Add(this.cbLigament);
            this.gbLigament.Location = new System.Drawing.Point(1270, 522);
            this.gbLigament.Name = "gbLigament";
            this.gbLigament.Size = new System.Drawing.Size(235, 65);
            this.gbLigament.TabIndex = 7;
            this.gbLigament.TabStop = false;
            this.gbLigament.Text = "Связка";
            // 
            // cbLigament
            // 
            this.cbLigament.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLigament.FormattingEnabled = true;
            this.cbLigament.Items.AddRange(new object[] {
            "И",
            "ИЛИ"});
            this.cbLigament.Location = new System.Drawing.Point(6, 23);
            this.cbLigament.Name = "cbLigament";
            this.cbLigament.Size = new System.Drawing.Size(223, 26);
            this.cbLigament.TabIndex = 3;
            // 
            // gbFieldValue
            // 
            this.gbFieldValue.Controls.Add(this.cbFieldValue);
            this.gbFieldValue.Location = new System.Drawing.Point(852, 522);
            this.gbFieldValue.Name = "gbFieldValue";
            this.gbFieldValue.Size = new System.Drawing.Size(412, 65);
            this.gbFieldValue.TabIndex = 6;
            this.gbFieldValue.TabStop = false;
            this.gbFieldValue.Text = "Значение";
            // 
            // cbFieldValue
            // 
            this.cbFieldValue.FormattingEnabled = true;
            this.cbFieldValue.Location = new System.Drawing.Point(6, 23);
            this.cbFieldValue.Name = "cbFieldValue";
            this.cbFieldValue.Size = new System.Drawing.Size(400, 26);
            this.cbFieldValue.TabIndex = 3;
            // 
            // gbCriterion
            // 
            this.gbCriterion.Controls.Add(this.cbCriterion);
            this.gbCriterion.Location = new System.Drawing.Point(675, 522);
            this.gbCriterion.Name = "gbCriterion";
            this.gbCriterion.Size = new System.Drawing.Size(171, 65);
            this.gbCriterion.TabIndex = 5;
            this.gbCriterion.TabStop = false;
            this.gbCriterion.Text = "Критерий";
            // 
            // cbCriterion
            // 
            this.cbCriterion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterion.FormattingEnabled = true;
            this.cbCriterion.Items.AddRange(new object[] {
            "=",
            "<>",
            ">",
            ">=",
            "<",
            "<="});
            this.cbCriterion.Location = new System.Drawing.Point(6, 23);
            this.cbCriterion.Name = "cbCriterion";
            this.cbCriterion.Size = new System.Drawing.Size(159, 26);
            this.cbCriterion.TabIndex = 3;
            // 
            // gbFields
            // 
            this.gbFields.Controls.Add(this.cbFields);
            this.gbFields.Location = new System.Drawing.Point(7, 522);
            this.gbFields.Name = "gbFields";
            this.gbFields.Size = new System.Drawing.Size(662, 65);
            this.gbFields.TabIndex = 4;
            this.gbFields.TabStop = false;
            this.gbFields.Text = "Имя поля";
            // 
            // cbFields
            // 
            this.cbFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFields.FormattingEnabled = true;
            this.cbFields.Location = new System.Drawing.Point(6, 23);
            this.cbFields.Name = "cbFields";
            this.cbFields.Size = new System.Drawing.Size(650, 26);
            this.cbFields.TabIndex = 3;
            this.cbFields.SelectedIndexChanged += new System.EventHandler(this.cbFields_SelectedIndexChanged);
            // 
            // bRemoveCondition
            // 
            this.bRemoveCondition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bRemoveCondition.Location = new System.Drawing.Point(1378, 600);
            this.bRemoveCondition.Name = "bRemoveCondition";
            this.bRemoveCondition.Size = new System.Drawing.Size(127, 40);
            this.bRemoveCondition.TabIndex = 2;
            this.bRemoveCondition.Text = "Удалить";
            this.bRemoveCondition.UseVisualStyleBackColor = true;
            this.bRemoveCondition.Click += new System.EventHandler(this.bRemoveCondition_Click);
            // 
            // bAddCondition
            // 
            this.bAddCondition.ForeColor = System.Drawing.Color.SeaGreen;
            this.bAddCondition.Location = new System.Drawing.Point(1245, 600);
            this.bAddCondition.Name = "bAddCondition";
            this.bAddCondition.Size = new System.Drawing.Size(127, 40);
            this.bAddCondition.TabIndex = 1;
            this.bAddCondition.Text = "Добавить";
            this.bAddCondition.UseVisualStyleBackColor = true;
            this.bAddCondition.Click += new System.EventHandler(this.bAddCondition_Click);
            // 
            // lvConditions
            // 
            this.lvConditions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fieldNameColumn,
            this.CriterionColumn,
            this.filedValueColumn,
            this.ligamentColumn});
            this.lvConditions.Location = new System.Drawing.Point(7, 7);
            this.lvConditions.Name = "lvConditions";
            this.lvConditions.Size = new System.Drawing.Size(1498, 496);
            this.lvConditions.TabIndex = 0;
            this.lvConditions.UseCompatibleStateImageBehavior = false;
            this.lvConditions.View = System.Windows.Forms.View.Details;
            // 
            // fieldNameColumn
            // 
            this.fieldNameColumn.Text = "Имя поля";
            this.fieldNameColumn.Width = 324;
            // 
            // CriterionColumn
            // 
            this.CriterionColumn.Text = "Критерий";
            this.CriterionColumn.Width = 295;
            // 
            // filedValueColumn
            // 
            this.filedValueColumn.Text = "Значение";
            this.filedValueColumn.Width = 307;
            // 
            // ligamentColumn
            // 
            this.ligamentColumn.Text = "Связка";
            this.ligamentColumn.Width = 294;
            // 
            // tpOrder
            // 
            this.tpOrder.Controls.Add(this.bRemoveAllFieldsFromSorted);
            this.tpOrder.Controls.Add(this.bRemoveFieldFromSorted);
            this.tpOrder.Controls.Add(this.bAddAllFieldsToSorted);
            this.tpOrder.Controls.Add(this.bAddFieldToSorted);
            this.tpOrder.Controls.Add(this.gbSortedFields);
            this.tpOrder.Controls.Add(this.gbFieldsForSort);
            this.tpOrder.Location = new System.Drawing.Point(4, 27);
            this.tpOrder.Name = "tpOrder";
            this.tpOrder.Size = new System.Drawing.Size(1511, 650);
            this.tpOrder.TabIndex = 2;
            this.tpOrder.Text = "Порядок";
            this.tpOrder.UseVisualStyleBackColor = true;
            // 
            // bRemoveAllFieldsFromSorted
            // 
            this.bRemoveAllFieldsFromSorted.Location = new System.Drawing.Point(566, 367);
            this.bRemoveAllFieldsFromSorted.Name = "bRemoveAllFieldsFromSorted";
            this.bRemoveAllFieldsFromSorted.Size = new System.Drawing.Size(50, 31);
            this.bRemoveAllFieldsFromSorted.TabIndex = 11;
            this.bRemoveAllFieldsFromSorted.Text = "<<";
            this.bRemoveAllFieldsFromSorted.UseVisualStyleBackColor = true;
            this.bRemoveAllFieldsFromSorted.Click += new System.EventHandler(this.bRemoveAllFieldsFromSorted_Click);
            // 
            // bRemoveFieldFromSorted
            // 
            this.bRemoveFieldFromSorted.Location = new System.Drawing.Point(566, 317);
            this.bRemoveFieldFromSorted.Name = "bRemoveFieldFromSorted";
            this.bRemoveFieldFromSorted.Size = new System.Drawing.Size(50, 31);
            this.bRemoveFieldFromSorted.TabIndex = 10;
            this.bRemoveFieldFromSorted.Text = "<";
            this.bRemoveFieldFromSorted.UseVisualStyleBackColor = true;
            this.bRemoveFieldFromSorted.Click += new System.EventHandler(this.bRemoveFieldFromSorted_Click);
            // 
            // bAddAllFieldsToSorted
            // 
            this.bAddAllFieldsToSorted.Location = new System.Drawing.Point(566, 269);
            this.bAddAllFieldsToSorted.Name = "bAddAllFieldsToSorted";
            this.bAddAllFieldsToSorted.Size = new System.Drawing.Size(50, 31);
            this.bAddAllFieldsToSorted.TabIndex = 9;
            this.bAddAllFieldsToSorted.Text = ">>";
            this.bAddAllFieldsToSorted.UseVisualStyleBackColor = true;
            this.bAddAllFieldsToSorted.Click += new System.EventHandler(this.bAddAllFieldsToSorted_Click);
            // 
            // bAddFieldToSorted
            // 
            this.bAddFieldToSorted.Location = new System.Drawing.Point(566, 221);
            this.bAddFieldToSorted.Name = "bAddFieldToSorted";
            this.bAddFieldToSorted.Size = new System.Drawing.Size(50, 31);
            this.bAddFieldToSorted.TabIndex = 8;
            this.bAddFieldToSorted.Text = ">";
            this.bAddFieldToSorted.UseVisualStyleBackColor = true;
            this.bAddFieldToSorted.Click += new System.EventHandler(this.bAddFieldToSorted_Click);
            // 
            // gbSortedFields
            // 
            this.gbSortedFields.Controls.Add(this.groupBox1);
            this.gbSortedFields.Controls.Add(this.gbOrder);
            this.gbSortedFields.Controls.Add(this.lbSortedFields);
            this.gbSortedFields.Location = new System.Drawing.Point(622, 7);
            this.gbSortedFields.Name = "gbSortedFields";
            this.gbSortedFields.Size = new System.Drawing.Size(886, 640);
            this.gbSortedFields.TabIndex = 7;
            this.gbSortedFields.TabStop = false;
            this.gbSortedFields.Text = "Последовательность сортировки";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bUpFieldInSorted);
            this.groupBox1.Controls.Add(this.bDownFieldInSorted);
            this.groupBox1.Location = new System.Drawing.Point(552, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Порядок последовательности";
            // 
            // bUpFieldInSorted
            // 
            this.bUpFieldInSorted.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bUpFieldInSorted.ForeColor = System.Drawing.Color.Fuchsia;
            this.bUpFieldInSorted.Location = new System.Drawing.Point(39, 32);
            this.bUpFieldInSorted.Name = "bUpFieldInSorted";
            this.bUpFieldInSorted.Size = new System.Drawing.Size(50, 46);
            this.bUpFieldInSorted.TabIndex = 12;
            this.bUpFieldInSorted.Text = "↑";
            this.bUpFieldInSorted.UseVisualStyleBackColor = true;
            this.bUpFieldInSorted.Click += new System.EventHandler(this.bUpFieldInSorted_Click);
            // 
            // bDownFieldInSorted
            // 
            this.bDownFieldInSorted.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bDownFieldInSorted.ForeColor = System.Drawing.Color.Fuchsia;
            this.bDownFieldInSorted.Location = new System.Drawing.Point(102, 32);
            this.bDownFieldInSorted.Name = "bDownFieldInSorted";
            this.bDownFieldInSorted.Size = new System.Drawing.Size(50, 46);
            this.bDownFieldInSorted.TabIndex = 13;
            this.bDownFieldInSorted.Text = "↓";
            this.bDownFieldInSorted.UseVisualStyleBackColor = true;
            this.bDownFieldInSorted.Click += new System.EventHandler(this.bDownFieldInSorted_Click);
            // 
            // gbOrder
            // 
            this.gbOrder.Controls.Add(this.rbDecreasingOrder);
            this.gbOrder.Controls.Add(this.rbIncreasingOrder);
            this.gbOrder.Location = new System.Drawing.Point(552, 160);
            this.gbOrder.Name = "gbOrder";
            this.gbOrder.Size = new System.Drawing.Size(328, 85);
            this.gbOrder.TabIndex = 12;
            this.gbOrder.TabStop = false;
            this.gbOrder.Text = "Порядок сортировки";
            // 
            // rbDecreasingOrder
            // 
            this.rbDecreasingOrder.AutoSize = true;
            this.rbDecreasingOrder.Location = new System.Drawing.Point(16, 52);
            this.rbDecreasingOrder.Name = "rbDecreasingOrder";
            this.rbDecreasingOrder.Size = new System.Drawing.Size(113, 22);
            this.rbDecreasingOrder.TabIndex = 1;
            this.rbDecreasingOrder.TabStop = true;
            this.rbDecreasingOrder.Text = "Убывающий";
            this.rbDecreasingOrder.UseVisualStyleBackColor = true;
            this.rbDecreasingOrder.CheckedChanged += new System.EventHandler(this.rbDecreasingOrder_CheckedChanged);
            // 
            // rbIncreasingOrder
            // 
            this.rbIncreasingOrder.AutoSize = true;
            this.rbIncreasingOrder.Location = new System.Drawing.Point(16, 24);
            this.rbIncreasingOrder.Name = "rbIncreasingOrder";
            this.rbIncreasingOrder.Size = new System.Drawing.Size(133, 22);
            this.rbIncreasingOrder.TabIndex = 0;
            this.rbIncreasingOrder.TabStop = true;
            this.rbIncreasingOrder.Text = "Возрастающий";
            this.rbIncreasingOrder.UseVisualStyleBackColor = true;
            this.rbIncreasingOrder.CheckedChanged += new System.EventHandler(this.rbIncreasingOrder_CheckedChanged);
            // 
            // lbSortedFields
            // 
            this.lbSortedFields.FormattingEnabled = true;
            this.lbSortedFields.ItemHeight = 18;
            this.lbSortedFields.Location = new System.Drawing.Point(3, 20);
            this.lbSortedFields.Name = "lbSortedFields";
            this.lbSortedFields.Size = new System.Drawing.Size(543, 616);
            this.lbSortedFields.TabIndex = 1;
            this.lbSortedFields.SelectedIndexChanged += new System.EventHandler(this.lbSortedFields_SelectedIndexChanged);
            // 
            // gbFieldsForSort
            // 
            this.gbFieldsForSort.Controls.Add(this.lbAllFieldsForSort);
            this.gbFieldsForSort.Location = new System.Drawing.Point(6, 6);
            this.gbFieldsForSort.Name = "gbFieldsForSort";
            this.gbFieldsForSort.Size = new System.Drawing.Size(554, 641);
            this.gbFieldsForSort.TabIndex = 6;
            this.gbFieldsForSort.TabStop = false;
            this.gbFieldsForSort.Text = "Все поля";
            // 
            // lbAllFieldsForSort
            // 
            this.lbAllFieldsForSort.FormattingEnabled = true;
            this.lbAllFieldsForSort.ItemHeight = 18;
            this.lbAllFieldsForSort.Location = new System.Drawing.Point(3, 20);
            this.lbAllFieldsForSort.Name = "lbAllFieldsForSort";
            this.lbAllFieldsForSort.Size = new System.Drawing.Size(545, 616);
            this.lbAllFieldsForSort.TabIndex = 0;
            // 
            // tpResult
            // 
            this.tpResult.Controls.Add(this.lvResult);
            this.tpResult.Location = new System.Drawing.Point(4, 27);
            this.tpResult.Name = "tpResult";
            this.tpResult.Size = new System.Drawing.Size(1511, 650);
            this.tpResult.TabIndex = 3;
            this.tpResult.Text = "Результат";
            this.tpResult.UseVisualStyleBackColor = true;
            // 
            // lvResult
            // 
            this.lvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResult.Location = new System.Drawing.Point(0, 0);
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(1511, 650);
            this.lvResult.TabIndex = 0;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            this.lvResult.View = System.Windows.Forms.View.Details;
            // 
            // bShowQuery
            // 
            this.bShowQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bShowQuery.ForeColor = System.Drawing.Color.SteelBlue;
            this.bShowQuery.Location = new System.Drawing.Point(1059, 699);
            this.bShowQuery.Name = "bShowQuery";
            this.bShowQuery.Size = new System.Drawing.Size(164, 34);
            this.bShowQuery.TabIndex = 1;
            this.bShowQuery.Text = "Просмотр SQL";
            this.bShowQuery.UseVisualStyleBackColor = true;
            this.bShowQuery.Click += new System.EventHandler(this.bShowQuery_Click);
            // 
            // bDoQuery
            // 
            this.bDoQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bDoQuery.ForeColor = System.Drawing.Color.Green;
            this.bDoQuery.Location = new System.Drawing.Point(1229, 699);
            this.bDoQuery.Name = "bDoQuery";
            this.bDoQuery.Size = new System.Drawing.Size(174, 34);
            this.bDoQuery.TabIndex = 2;
            this.bDoQuery.Text = "Выполнить запрос";
            this.bDoQuery.UseVisualStyleBackColor = true;
            this.bDoQuery.Click += new System.EventHandler(this.bDoQuery_Click);
            // 
            // bCancel
            // 
            this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancel.ForeColor = System.Drawing.Color.Red;
            this.bCancel.Location = new System.Drawing.Point(1409, 699);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(118, 34);
            this.bCancel.TabIndex = 3;
            this.bCancel.Text = "Очистить";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1646, 745);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bDoQuery);
            this.Controls.Add(this.bShowQuery);
            this.Controls.Add(this.tcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Создать запрос";
            this.tcMain.ResumeLayout(false);
            this.tpFields.ResumeLayout(false);
            this.gbSelectedFileds.ResumeLayout(false);
            this.gbAllFields.ResumeLayout(false);
            this.tpConditions.ResumeLayout(false);
            this.gbLigament.ResumeLayout(false);
            this.gbFieldValue.ResumeLayout(false);
            this.gbCriterion.ResumeLayout(false);
            this.gbFields.ResumeLayout(false);
            this.tpOrder.ResumeLayout(false);
            this.gbSortedFields.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbOrder.ResumeLayout(false);
            this.gbOrder.PerformLayout();
            this.gbFieldsForSort.ResumeLayout(false);
            this.tpResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpFields;
        private System.Windows.Forms.TabPage tpConditions;
        private System.Windows.Forms.TabPage tpOrder;
        private System.Windows.Forms.TabPage tpResult;
        private System.Windows.Forms.GroupBox gbAllFields;
        private System.Windows.Forms.ListBox lbSelectedFields;
        private System.Windows.Forms.ListBox lbAllFields;
        private System.Windows.Forms.Button bRemoveAllFields;
        private System.Windows.Forms.Button bRemoveField;
        private System.Windows.Forms.Button bSelectAllIFields;
        private System.Windows.Forms.Button bSelectField;
        private System.Windows.Forms.GroupBox gbSelectedFileds;
        private System.Windows.Forms.Button bShowQuery;
        private System.Windows.Forms.Button bDoQuery;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bRemoveCondition;
        private System.Windows.Forms.Button bAddCondition;
        private System.Windows.Forms.GroupBox gbFields;
        private System.Windows.Forms.ComboBox cbFields;
        private System.Windows.Forms.GroupBox gbLigament;
        private System.Windows.Forms.ComboBox cbLigament;
        private System.Windows.Forms.GroupBox gbFieldValue;
        private System.Windows.Forms.ComboBox cbFieldValue;
        private System.Windows.Forms.GroupBox gbCriterion;
        private System.Windows.Forms.ComboBox cbCriterion;
        private System.Windows.Forms.Button bDownFieldInSorted;
        private System.Windows.Forms.Button bUpFieldInSorted;
        private System.Windows.Forms.Button bRemoveAllFieldsFromSorted;
        private System.Windows.Forms.Button bRemoveFieldFromSorted;
        private System.Windows.Forms.Button bAddAllFieldsToSorted;
        private System.Windows.Forms.Button bAddFieldToSorted;
        private System.Windows.Forms.GroupBox gbSortedFields;
        private System.Windows.Forms.ListBox lbSortedFields;
        private System.Windows.Forms.GroupBox gbFieldsForSort;
        private System.Windows.Forms.ListBox lbAllFieldsForSort;
        private System.Windows.Forms.GroupBox gbOrder;
        private System.Windows.Forms.RadioButton rbDecreasingOrder;
        private System.Windows.Forms.RadioButton rbIncreasingOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvResult;
        private System.Windows.Forms.ListView lvConditions;
        private System.Windows.Forms.ColumnHeader fieldNameColumn;
        private System.Windows.Forms.ColumnHeader CriterionColumn;
        private System.Windows.Forms.ColumnHeader filedValueColumn;
        private System.Windows.Forms.ColumnHeader ligamentColumn;
    }
}

