namespace Task2_DuplicateInvoices
{
    partial class Form1
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
            this.connectionTab = new System.Windows.Forms.TabPage();
            this.connectionStatus = new System.Windows.Forms.Label();
            this.testConnectionBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.soapUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.showPassword = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fetchDataTab = new System.Windows.Forms.TabPage();
            this.dateFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.dataRecordsGridView = new System.Windows.Forms.DataGridView();
            this.recordCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fromDate = new System.Windows.Forms.Label();
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.applyChanges = new System.Windows.Forms.Button();
            this.fetchBtn = new System.Windows.Forms.Button();
            this.errorTab = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorList = new System.Windows.Forms.ListBox();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applicationTabs.SuspendLayout();
            this.connectionTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.applicationTabs.Controls.Add(this.connectionTab);
            this.applicationTabs.Controls.Add(this.fetchDataTab);
            this.applicationTabs.Controls.Add(this.errorTab);
            this.applicationTabs.Location = new System.Drawing.Point(13, 5);
            this.applicationTabs.Margin = new System.Windows.Forms.Padding(4);
            this.applicationTabs.Name = "applicationTabs";
            this.applicationTabs.SelectedIndex = 0;
            this.applicationTabs.Size = new System.Drawing.Size(1238, 535);
            this.applicationTabs.TabIndex = 4;
            // 
            // connectionTab
            // 
            this.connectionTab.Controls.Add(this.connectionStatus);
            this.connectionTab.Controls.Add(this.testConnectionBtn);
            this.connectionTab.Controls.Add(this.groupBox1);
            this.connectionTab.Location = new System.Drawing.Point(4, 25);
            this.connectionTab.Margin = new System.Windows.Forms.Padding(4);
            this.connectionTab.Name = "connectionTab";
            this.connectionTab.Padding = new System.Windows.Forms.Padding(4);
            this.connectionTab.Size = new System.Drawing.Size(1230, 506);
            this.connectionTab.TabIndex = 3;
            this.connectionTab.Text = "Connect To CRM";
            this.connectionTab.UseVisualStyleBackColor = true;
            // 
            // connectionStatus
            // 
            this.connectionStatus.AutoSize = true;
            this.connectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionStatus.Location = new System.Drawing.Point(40, 353);
            this.connectionStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(130, 20);
            this.connectionStatus.TabIndex = 17;
            this.connectionStatus.Text = "Not connected";
            // 
            // testConnectionBtn
            // 
            this.testConnectionBtn.Location = new System.Drawing.Point(793, 304);
            this.testConnectionBtn.Margin = new System.Windows.Forms.Padding(4);
            this.testConnectionBtn.Name = "testConnectionBtn";
            this.testConnectionBtn.Size = new System.Drawing.Size(156, 28);
            this.testConnectionBtn.TabIndex = 9;
            this.testConnectionBtn.Text = "Test Connection";
            this.testConnectionBtn.UseVisualStyleBackColor = true;
            this.testConnectionBtn.Click += new System.EventHandler(this.testConnectionBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.soapUrl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.showPassword);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.userName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(44, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(905, 241);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Details";
            // 
            // soapUrl
            // 
            this.soapUrl.Location = new System.Drawing.Point(134, 50);
            this.soapUrl.Name = "soapUrl";
            this.soapUrl.Size = new System.Drawing.Size(755, 22);
            this.soapUrl.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Crm SoapUrl";
            // 
            // showPassword
            // 
            this.showPassword.Location = new System.Drawing.Point(749, 162);
            this.showPassword.Margin = new System.Windows.Forms.Padding(4);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(141, 28);
            this.showPassword.TabIndex = 18;
            this.showPassword.Text = "Show Password";
            this.showPassword.UseVisualStyleBackColor = true;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(621, 130);
            this.password.Margin = new System.Windows.Forms.Padding(4);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(268, 22);
            this.password.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(479, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Password";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(135, 126);
            this.userName.Margin = new System.Windows.Forms.Padding(4);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(307, 22);
            this.userName.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Username";
            // 
            // fetchDataTab
            // 
            this.fetchDataTab.Controls.Add(this.dateFilterCheckBox);
            this.fetchDataTab.Controls.Add(this.dataRecordsGridView);
            this.fetchDataTab.Controls.Add(this.recordCount);
            this.fetchDataTab.Controls.Add(this.label7);
            this.fetchDataTab.Controls.Add(this.fromDate);
            this.fetchDataTab.Controls.Add(this.dateTimeFrom);
            this.fetchDataTab.Controls.Add(this.applyChanges);
            this.fetchDataTab.Controls.Add(this.fetchBtn);
            this.fetchDataTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchDataTab.Location = new System.Drawing.Point(4, 25);
            this.fetchDataTab.Margin = new System.Windows.Forms.Padding(4);
            this.fetchDataTab.Name = "fetchDataTab";
            this.fetchDataTab.Padding = new System.Windows.Forms.Padding(4);
            this.fetchDataTab.Size = new System.Drawing.Size(1230, 506);
            this.fetchDataTab.TabIndex = 0;
            this.fetchDataTab.Text = "Fetch Data && Apply Changes";
            this.fetchDataTab.UseVisualStyleBackColor = true;
            // 
            // dateFilterCheckBox
            // 
            this.dateFilterCheckBox.AutoSize = true;
            this.dateFilterCheckBox.Checked = true;
            this.dateFilterCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dateFilterCheckBox.Location = new System.Drawing.Point(166, 16);
            this.dateFilterCheckBox.Name = "dateFilterCheckBox";
            this.dateFilterCheckBox.Size = new System.Drawing.Size(273, 24);
            this.dateFilterCheckBox.TabIndex = 11;
            this.dateFilterCheckBox.Text = "Apply For Invoice Created Today";
            this.dateFilterCheckBox.UseVisualStyleBackColor = true;
            this.dateFilterCheckBox.CheckedChanged += new System.EventHandler(this.applyForTodayInvoices);
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
            this.InvoiceNumber,
            this.NewDate,
            this.CreatedOn,
            this.Colour});
            this.dataRecordsGridView.Location = new System.Drawing.Point(7, 53);
            this.dataRecordsGridView.Name = "dataRecordsGridView";
            this.dataRecordsGridView.RowTemplate.Height = 24;
            this.dataRecordsGridView.Size = new System.Drawing.Size(1223, 446);
            this.dataRecordsGridView.TabIndex = 10;
            // 
            // recordCount
            // 
            this.recordCount.AutoSize = true;
            this.recordCount.Location = new System.Drawing.Point(79, 20);
            this.recordCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.recordCount.Name = "recordCount";
            this.recordCount.Size = new System.Drawing.Size(18, 20);
            this.recordCount.TabIndex = 9;
            this.recordCount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Count";
            // 
            // fromDate
            // 
            this.fromDate.AutoSize = true;
            this.fromDate.Location = new System.Drawing.Point(499, 17);
            this.fromDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(48, 20);
            this.fromDate.TabIndex = 5;
            this.fromDate.Text = "From";
            this.fromDate.Visible = false;
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.Location = new System.Drawing.Point(569, 12);
            this.dateTimeFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(277, 26);
            this.dateTimeFrom.TabIndex = 4;
            this.dateTimeFrom.Visible = false;
            // 
            // applyChanges
            // 
            this.applyChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyChanges.Location = new System.Drawing.Point(1070, 5);
            this.applyChanges.Margin = new System.Windows.Forms.Padding(4);
            this.applyChanges.Name = "applyChanges";
            this.applyChanges.Size = new System.Drawing.Size(148, 39);
            this.applyChanges.TabIndex = 2;
            this.applyChanges.Text = "Apply Changes";
            this.applyChanges.UseVisualStyleBackColor = true;
            this.applyChanges.Click += new System.EventHandler(this.applyChanges_Click);
            // 
            // fetchBtn
            // 
            this.fetchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchBtn.Location = new System.Drawing.Point(914, 5);
            this.fetchBtn.Margin = new System.Windows.Forms.Padding(4);
            this.fetchBtn.Name = "fetchBtn";
            this.fetchBtn.Size = new System.Drawing.Size(143, 37);
            this.fetchBtn.TabIndex = 0;
            this.fetchBtn.Text = "Fetch Records";
            this.fetchBtn.UseVisualStyleBackColor = true;
            this.fetchBtn.Click += new System.EventHandler(this.fetchBtn_Click);
            // 
            // errorTab
            // 
            this.errorTab.Controls.Add(this.panel2);
            this.errorTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorTab.Location = new System.Drawing.Point(4, 25);
            this.errorTab.Margin = new System.Windows.Forms.Padding(4);
            this.errorTab.Name = "errorTab";
            this.errorTab.Size = new System.Drawing.Size(1230, 506);
            this.errorTab.TabIndex = 2;
            this.errorTab.Text = "Error Messages";
            this.errorTab.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.errorList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1230, 506);
            this.panel2.TabIndex = 1;
            // 
            // errorList
            // 
            this.errorList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorList.FormattingEnabled = true;
            this.errorList.ItemHeight = 25;
            this.errorList.Location = new System.Drawing.Point(7, 16);
            this.errorList.Margin = new System.Windows.Forms.Padding(4);
            this.errorList.Name = "errorList";
            this.errorList.Size = new System.Drawing.Size(1218, 454);
            this.errorList.TabIndex = 0;
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
            // InvoiceNumber
            // 
            this.InvoiceNumber.HeaderText = "Invoice Number";
            this.InvoiceNumber.Name = "InvoiceNumber";
            // 
            // NewDate
            // 
            this.NewDate.HeaderText = "Invoice Date";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 553);
            this.Controls.Add(this.applicationTabs);
            //this.Name = "Form1";
            this.Text = "Task2_DuplicateInvoices";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.applicationTabs.ResumeLayout(false);
            this.connectionTab.ResumeLayout(false);
            this.connectionTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.fetchDataTab.ResumeLayout(false);
            this.fetchDataTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataRecordsGridView)).EndInit();
            this.errorTab.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl applicationTabs;
        private System.Windows.Forms.TabPage connectionTab;
        private System.Windows.Forms.Label connectionStatus;
        private System.Windows.Forms.Button testConnectionBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox soapUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button showPassword;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage fetchDataTab;
        private System.Windows.Forms.CheckBox dateFilterCheckBox;
        private System.Windows.Forms.DataGridView dataRecordsGridView;
        private System.Windows.Forms.Label recordCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label fromDate;
        private System.Windows.Forms.DateTimePicker dateTimeFrom;
        private System.Windows.Forms.Button applyChanges;
        private System.Windows.Forms.Button fetchBtn;
        private System.Windows.Forms.TabPage errorTab;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox errorList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colour;
    }
}

