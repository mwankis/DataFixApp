namespace Task1_DuplicateUpgrades
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
            this.showPassword = new System.Windows.Forms.Button();
            this.organisationName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.crmServer = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fetchDataTab = new System.Windows.Forms.TabPage();
            this.recordCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.applyChanges = new System.Windows.Forms.Button();
            this.fetchBtn = new System.Windows.Forms.Button();
            this.errorTab = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorList = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.recordsList = new System.Windows.Forms.ListBox();
            this.applicationTabs.SuspendLayout();
            this.connectionTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.fetchDataTab.SuspendLayout();
            this.errorTab.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.applicationTabs.Location = new System.Drawing.Point(3, 12);
            this.applicationTabs.Name = "applicationTabs";
            this.applicationTabs.SelectedIndex = 0;
            this.applicationTabs.Size = new System.Drawing.Size(905, 435);
            this.applicationTabs.TabIndex = 3;
            // 
            // connectionTab
            // 
            this.connectionTab.Controls.Add(this.connectionStatus);
            this.connectionTab.Controls.Add(this.testConnectionBtn);
            this.connectionTab.Controls.Add(this.groupBox1);
            this.connectionTab.Location = new System.Drawing.Point(4, 22);
            this.connectionTab.Name = "connectionTab";
            this.connectionTab.Padding = new System.Windows.Forms.Padding(3);
            this.connectionTab.Size = new System.Drawing.Size(897, 409);
            this.connectionTab.TabIndex = 3;
            this.connectionTab.Text = "Connect To CRM";
            this.connectionTab.UseVisualStyleBackColor = true;
            // 
            // connectionStatus
            // 
            this.connectionStatus.AutoSize = true;
            this.connectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionStatus.Location = new System.Drawing.Point(33, 256);
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(108, 16);
            this.connectionStatus.TabIndex = 17;
            this.connectionStatus.Text = "Not connected";
            // 
            // testConnectionBtn
            // 
            this.testConnectionBtn.Location = new System.Drawing.Point(595, 247);
            this.testConnectionBtn.Name = "testConnectionBtn";
            this.testConnectionBtn.Size = new System.Drawing.Size(117, 23);
            this.testConnectionBtn.TabIndex = 9;
            this.testConnectionBtn.Text = "Test Connection";
            this.testConnectionBtn.UseVisualStyleBackColor = true;
            this.testConnectionBtn.Click += new System.EventHandler(this.testConnectionBtn_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.showPassword);
            this.groupBox1.Controls.Add(this.organisationName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.crmServer);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.userName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(33, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 196);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Details";
            // 
            // showPassword
            // 
            this.showPassword.Location = new System.Drawing.Point(562, 132);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(106, 23);
            this.showPassword.TabIndex = 18;
            this.showPassword.Text = "Show Password";
            this.showPassword.UseVisualStyleBackColor = true;
            this.showPassword.Click += new System.EventHandler(this.showPassword_Click);
            // 
            // organisationName
            // 
            this.organisationName.Location = new System.Drawing.Point(466, 31);
            this.organisationName.Name = "organisationName";
            this.organisationName.Size = new System.Drawing.Size(202, 20);
            this.organisationName.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(362, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "OrganisationName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Crm Server";
            // 
            // crmServer
            // 
            this.crmServer.Location = new System.Drawing.Point(101, 25);
            this.crmServer.Name = "crmServer";
            this.crmServer.Size = new System.Drawing.Size(231, 20);
            this.crmServer.TabIndex = 13;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(466, 106);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(202, 20);
            this.password.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(359, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Password";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(101, 102);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(231, 20);
            this.userName.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Username";
            // 
            // fetchDataTab
            // 
            this.fetchDataTab.Controls.Add(this.recordsList);
            this.fetchDataTab.Controls.Add(this.recordCount);
            this.fetchDataTab.Controls.Add(this.label7);
            this.fetchDataTab.Controls.Add(this.label1);
            this.fetchDataTab.Controls.Add(this.dateTimeFrom);
            this.fetchDataTab.Controls.Add(this.applyChanges);
            this.fetchDataTab.Controls.Add(this.fetchBtn);
            this.fetchDataTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchDataTab.Location = new System.Drawing.Point(4, 22);
            this.fetchDataTab.Name = "fetchDataTab";
            this.fetchDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.fetchDataTab.Size = new System.Drawing.Size(897, 409);
            this.fetchDataTab.TabIndex = 0;
            this.fetchDataTab.Text = "Fetch Data && Apply Changes";
            this.fetchDataTab.UseVisualStyleBackColor = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "From";
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.Location = new System.Drawing.Point(162, 14);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(209, 22);
            this.dateTimeFrom.TabIndex = 4;
            // 
            // applyChanges
            // 
            this.applyChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyChanges.Location = new System.Drawing.Point(780, 6);
            this.applyChanges.Name = "applyChanges";
            this.applyChanges.Size = new System.Drawing.Size(111, 32);
            this.applyChanges.TabIndex = 2;
            this.applyChanges.Text = "Apply Changes";
            this.applyChanges.UseVisualStyleBackColor = true;
            // 
            // fetchBtn
            // 
            this.fetchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchBtn.Location = new System.Drawing.Point(654, 6);
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
            this.errorTab.Size = new System.Drawing.Size(897, 409);
            this.errorTab.TabIndex = 2;
            this.errorTab.Text = "Error Messages";
            this.errorTab.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.errorList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(897, 409);
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
            this.errorList.Size = new System.Drawing.Size(889, 384);
            this.errorList.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.applicationTabs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 450);
            this.panel1.TabIndex = 4;
            // 
            // recordsList
            // 
            this.recordsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recordsList.FormattingEnabled = true;
            this.recordsList.ItemHeight = 16;
            this.recordsList.Location = new System.Drawing.Point(10, 56);
            this.recordsList.Name = "recordsList";
            this.recordsList.Size = new System.Drawing.Size(881, 340);
            this.recordsList.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Task1_DuplicateUpgrades";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.applicationTabs.ResumeLayout(false);
            this.connectionTab.ResumeLayout(false);
            this.connectionTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.fetchDataTab.ResumeLayout(false);
            this.fetchDataTab.PerformLayout();
            this.errorTab.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl applicationTabs;
        private System.Windows.Forms.TabPage fetchDataTab;
        private System.Windows.Forms.Button fetchBtn;
        private System.Windows.Forms.TabPage errorTab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button applyChanges;
        private System.Windows.Forms.DateTimePicker dateTimeFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage connectionTab;
        private System.Windows.Forms.Button testConnectionBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox crmServer;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox organisationName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label connectionStatus;
        private System.Windows.Forms.Button showPassword;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox errorList;
        private System.Windows.Forms.Label recordCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox recordsList;
    }
}

