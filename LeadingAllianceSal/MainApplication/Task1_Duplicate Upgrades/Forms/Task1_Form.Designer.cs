namespace MainApplication.Task1.Forms
{
    partial class Task1_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.applicationTabs = new System.Windows.Forms.TabControl();
            this.fetchDataTab = new System.Windows.Forms.TabPage();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.loadTestData = new System.Windows.Forms.Button();
            this.dateFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.dataRecordsGridView = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fromDate = new System.Windows.Forms.Label();
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.applyChanges = new System.Windows.Forms.Button();
            this.fetchBtn = new System.Windows.Forms.Button();
            this.errorTab = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorList = new System.Windows.Forms.ListBox();
            this.applicationTabs.SuspendLayout();
            this.fetchDataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataRecordsGridView)).BeginInit();
            this.errorTab.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // applicationTabs
            // 
            this.applicationTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applicationTabs.Controls.Add(this.fetchDataTab);
            this.applicationTabs.Controls.Add(this.errorTab);
            this.applicationTabs.Location = new System.Drawing.Point(2, 1);
            this.applicationTabs.Name = "applicationTabs";
            this.applicationTabs.SelectedIndex = 0;
            this.applicationTabs.Size = new System.Drawing.Size(1128, 433);
            this.applicationTabs.TabIndex = 4;
            // 
            // fetchDataTab
            // 
            this.fetchDataTab.Controls.Add(this.dateTo);
            this.fetchDataTab.Controls.Add(this.label1);
            this.fetchDataTab.Controls.Add(this.loadTestData);
            this.fetchDataTab.Controls.Add(this.dateFilterCheckBox);
            this.fetchDataTab.Controls.Add(this.dataRecordsGridView);
            this.fetchDataTab.Controls.Add(this.recordCount);
            this.fetchDataTab.Controls.Add(this.label7);
            this.fetchDataTab.Controls.Add(this.fromDate);
            this.fetchDataTab.Controls.Add(this.dateTimeFrom);
            this.fetchDataTab.Controls.Add(this.applyChanges);
            this.fetchDataTab.Controls.Add(this.fetchBtn);
            this.fetchDataTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchDataTab.Location = new System.Drawing.Point(4, 22);
            this.fetchDataTab.Name = "fetchDataTab";
            this.fetchDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.fetchDataTab.Size = new System.Drawing.Size(1120, 407);
            this.fetchDataTab.TabIndex = 0;
            this.fetchDataTab.Text = "Fetch Data && Apply Changes";
            this.fetchDataTab.UseVisualStyleBackColor = true;
            // 
            // dateTo
            // 
            this.dateTo.Location = new System.Drawing.Point(741, 11);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(145, 22);
            this.dateTo.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(710, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "To";
            // 
            // loadTestData
            // 
            this.loadTestData.Location = new System.Drawing.Point(206, 11);
            this.loadTestData.Margin = new System.Windows.Forms.Padding(2);
            this.loadTestData.Name = "loadTestData";
            this.loadTestData.Size = new System.Drawing.Size(102, 26);
            this.loadTestData.TabIndex = 12;
            this.loadTestData.Text = "Load Test Data";
            this.loadTestData.UseVisualStyleBackColor = true;
            // 
            // dateFilterCheckBox
            // 
            this.dateFilterCheckBox.AutoSize = true;
            this.dateFilterCheckBox.Location = new System.Drawing.Point(338, 13);
            this.dateFilterCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.dateFilterCheckBox.Name = "dateFilterCheckBox";
            this.dateFilterCheckBox.Size = new System.Drawing.Size(113, 20);
            this.dateFilterCheckBox.TabIndex = 11;
            this.dateFilterCheckBox.Text = "Filter with Date";
            this.dateFilterCheckBox.UseVisualStyleBackColor = true;
            this.dateFilterCheckBox.CheckedChanged += new System.EventHandler(this.onDateFilterCheckBoxChange);
            // 
            // dataRecordsGridView
            // 
            this.dataRecordsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataRecordsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataRecordsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataRecordsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.CustomerId,
            this.CardId,
            this.NewDate,
            this.CreatedOn,
            this.Colour});
            this.dataRecordsGridView.Location = new System.Drawing.Point(5, 43);
            this.dataRecordsGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dataRecordsGridView.Name = "dataRecordsGridView";
            this.dataRecordsGridView.RowTemplate.Height = 24;
            this.dataRecordsGridView.Size = new System.Drawing.Size(1108, 360);
            this.dataRecordsGridView.TabIndex = 10;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            // 
            // CustomerId
            // 
            this.CustomerId.HeaderText = "CustomerId";
            this.CustomerId.Name = "CustomerId";
            this.CustomerId.ReadOnly = true;
            // 
            // CardId
            // 
            this.CardId.HeaderText = "CardId";
            this.CardId.Name = "CardId";
            this.CardId.ReadOnly = true;
            // 
            // NewDate
            // 
            this.NewDate.HeaderText = "New Date";
            this.NewDate.Name = "NewDate";
            this.NewDate.ReadOnly = true;
            // 
            // CreatedOn
            // 
            this.CreatedOn.HeaderText = "CreatedOn";
            this.CreatedOn.Name = "CreatedOn";
            this.CreatedOn.ReadOnly = true;
            // 
            // Colour
            // 
            this.Colour.HeaderText = "Colour";
            this.Colour.Name = "Colour";
            this.Colour.ReadOnly = true;
            this.Colour.Visible = false;
            // 
            // recordCount
            // 
            this.recordCount.AutoSize = true;
            this.recordCount.Location = new System.Drawing.Point(59, 16);
            this.recordCount.Name = "recordCount";
            this.recordCount.Size = new System.Drawing.Size(15, 16);
            this.recordCount.TabIndex = 9;
            this.recordCount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Count";
            // 
            // fromDate
            // 
            this.fromDate.AutoSize = true;
            this.fromDate.Location = new System.Drawing.Point(452, 14);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(39, 16);
            this.fromDate.TabIndex = 5;
            this.fromDate.Text = "From";
            this.fromDate.Visible = false;
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.Location = new System.Drawing.Point(495, 10);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(209, 22);
            this.dateTimeFrom.TabIndex = 4;
            this.dateTimeFrom.Visible = false;
            // 
            // applyChanges
            // 
            this.applyChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyChanges.Location = new System.Drawing.Point(1005, 4);
            this.applyChanges.Name = "applyChanges";
            this.applyChanges.Size = new System.Drawing.Size(111, 32);
            this.applyChanges.TabIndex = 2;
            this.applyChanges.Text = "Apply Changes";
            this.applyChanges.UseVisualStyleBackColor = true;
            this.applyChanges.Click += new System.EventHandler(this.applyChanges_Click);
            // 
            // fetchBtn
            // 
            this.fetchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchBtn.Location = new System.Drawing.Point(892, 7);
            this.fetchBtn.Name = "fetchBtn";
            this.fetchBtn.Size = new System.Drawing.Size(107, 30);
            this.fetchBtn.TabIndex = 0;
            this.fetchBtn.Text = "Fetch Records";
            this.fetchBtn.UseVisualStyleBackColor = true;
            this.fetchBtn.Click += new System.EventHandler(this.fetchBtn_Click);
            // 
            // errorTab
            // 
            this.errorTab.Controls.Add(this.panel2);
            this.errorTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorTab.Location = new System.Drawing.Point(4, 22);
            this.errorTab.Name = "errorTab";
            this.errorTab.Size = new System.Drawing.Size(1120, 407);
            this.errorTab.TabIndex = 2;
            this.errorTab.Text = "Progress Status";
            this.errorTab.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.errorList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1120, 407);
            this.panel2.TabIndex = 1;
            // 
            // errorList
            // 
            this.errorList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorList.FormattingEnabled = true;
            this.errorList.ItemHeight = 20;
            this.errorList.Location = new System.Drawing.Point(5, 13);
            this.errorList.Name = "errorList";
            this.errorList.Size = new System.Drawing.Size(1112, 324);
            this.errorList.TabIndex = 0;
            // 
            // Task1_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 446);
            this.Controls.Add(this.applicationTabs);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.Text = "Task1 - Duplicate Upgrades";
            this.applicationTabs.ResumeLayout(false);
            this.fetchDataTab.ResumeLayout(false);
            this.fetchDataTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataRecordsGridView)).EndInit();
            this.errorTab.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl applicationTabs;
        private System.Windows.Forms.TabPage fetchDataTab;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadTestData;
        private System.Windows.Forms.CheckBox dateFilterCheckBox;
        private System.Windows.Forms.DataGridView dataRecordsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colour;
        private System.Windows.Forms.Label recordCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label fromDate;
        private System.Windows.Forms.DateTimePicker dateTimeFrom;
        private System.Windows.Forms.Button applyChanges;
        private System.Windows.Forms.Button fetchBtn;
        private System.Windows.Forms.TabPage errorTab;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox errorList;
    }
}