namespace MainApplication
{
    partial class MainApplication
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
            this.task1Btn = new System.Windows.Forms.Button();
            this.task2Btn = new System.Windows.Forms.Button();
            this.task3Btn = new System.Windows.Forms.Button();
            this.task4Btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.loadAppSettings = new System.Windows.Forms.CheckBox();
            this.soapUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.showPassword = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.connectionStatus = new System.Windows.Forms.Label();
            this.testConnectionBtn = new System.Windows.Forms.Button();
            this.task5Btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // task1Btn
            // 
            this.task1Btn.Location = new System.Drawing.Point(41, 320);
            this.task1Btn.Name = "task1Btn";
            this.task1Btn.Size = new System.Drawing.Size(104, 50);
            this.task1Btn.TabIndex = 0;
            this.task1Btn.Text = "Task 1 (Duplicate Upgrades)";
            this.task1Btn.UseVisualStyleBackColor = true;
            this.task1Btn.Click += new System.EventHandler(this.task1Btn_Click);
            // 
            // task2Btn
            // 
            this.task2Btn.Location = new System.Drawing.Point(175, 320);
            this.task2Btn.Name = "task2Btn";
            this.task2Btn.Size = new System.Drawing.Size(105, 50);
            this.task2Btn.TabIndex = 1;
            this.task2Btn.Text = "Task 2 (Duplicate Invoices)";
            this.task2Btn.UseVisualStyleBackColor = true;
            this.task2Btn.Click += new System.EventHandler(this.task2Btn_Click);
            // 
            // task3Btn
            // 
            this.task3Btn.Location = new System.Drawing.Point(301, 320);
            this.task3Btn.Name = "task3Btn";
            this.task3Btn.Size = new System.Drawing.Size(129, 50);
            this.task3Btn.TabIndex = 2;
            this.task3Btn.Text = "Task 3 (Missing Invoices)";
            this.task3Btn.UseVisualStyleBackColor = true;
            this.task3Btn.Click += new System.EventHandler(this.task3Btn_Click);
            // 
            // task4Btn
            // 
            this.task4Btn.Location = new System.Drawing.Point(464, 320);
            this.task4Btn.Name = "task4Btn";
            this.task4Btn.Size = new System.Drawing.Size(125, 50);
            this.task4Btn.TabIndex = 3;
            this.task4Btn.Text = "Task 4 (Missing Openning  Invoices)";
            this.task4Btn.UseVisualStyleBackColor = true;
            this.task4Btn.Click += new System.EventHandler(this.task4Btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.loadAppSettings);
            this.groupBox1.Controls.Add(this.soapUrl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.showPassword);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.userName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(41, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 196);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Details";
            // 
            // loadAppSettings
            // 
            this.loadAppSettings.AutoSize = true;
            this.loadAppSettings.Location = new System.Drawing.Point(14, 20);
            this.loadAppSettings.Name = "loadAppSettings";
            this.loadAppSettings.Size = new System.Drawing.Size(136, 17);
            this.loadAppSettings.TabIndex = 21;
            this.loadAppSettings.Text = "Load From AppSettings";
            this.loadAppSettings.UseVisualStyleBackColor = true;
            this.loadAppSettings.CheckedChanged += new System.EventHandler(this.loadAppSettingsValues);
            // 
            // soapUrl
            // 
            this.soapUrl.Location = new System.Drawing.Point(100, 57);
            this.soapUrl.Margin = new System.Windows.Forms.Padding(2);
            this.soapUrl.Name = "soapUrl";
            this.soapUrl.Size = new System.Drawing.Size(567, 20);
            this.soapUrl.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Crm SoapUrl";
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
            // connectionStatus
            // 
            this.connectionStatus.AutoSize = true;
            this.connectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionStatus.Location = new System.Drawing.Point(38, 264);
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(108, 16);
            this.connectionStatus.TabIndex = 19;
            this.connectionStatus.Text = "Not connected";
            // 
            // testConnectionBtn
            // 
            this.testConnectionBtn.Location = new System.Drawing.Point(603, 224);
            this.testConnectionBtn.Name = "testConnectionBtn";
            this.testConnectionBtn.Size = new System.Drawing.Size(117, 23);
            this.testConnectionBtn.TabIndex = 18;
            this.testConnectionBtn.Text = "Test Connection";
            this.testConnectionBtn.UseVisualStyleBackColor = true;
            this.testConnectionBtn.Click += new System.EventHandler(this.testConnectionBtn_Click);
            // 
            // task5Btn
            // 
            this.task5Btn.Location = new System.Drawing.Point(616, 320);
            this.task5Btn.Name = "task5Btn";
            this.task5Btn.Size = new System.Drawing.Size(104, 50);
            this.task5Btn.TabIndex = 20;
            this.task5Btn.Text = "Task 5 (Zero Awarded Points)";
            this.task5Btn.UseVisualStyleBackColor = true;
            this.task5Btn.Click += new System.EventHandler(this.task5Btn_Click);
            // 
            // MainApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 450);
            this.Controls.Add(this.task5Btn);
            this.Controls.Add(this.connectionStatus);
            this.Controls.Add(this.testConnectionBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.task4Btn);
            this.Controls.Add(this.task3Btn);
            this.Controls.Add(this.task2Btn);
            this.Controls.Add(this.task1Btn);
            this.MaximizeBox = false;
            this.Name = "MainApplication";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button task1Btn;
        private System.Windows.Forms.Button task2Btn;
        private System.Windows.Forms.Button task3Btn;
        private System.Windows.Forms.Button task4Btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox soapUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button showPassword;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label connectionStatus;
        private System.Windows.Forms.Button testConnectionBtn;
        private System.Windows.Forms.CheckBox loadAppSettings;
        private System.Windows.Forms.Button task5Btn;
    }
}

