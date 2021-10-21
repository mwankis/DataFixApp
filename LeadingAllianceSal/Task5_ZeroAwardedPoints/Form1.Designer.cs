namespace Task5_ZeroAwardedPoints
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
            this.fetchBtn = new System.Windows.Forms.Button();
            this.applyChanges = new System.Windows.Forms.Button();
            this.applicationTabs = new System.Windows.Forms.TabControl();
            this.fetchDataTab = new System.Windows.Forms.TabPage();
            this.applyChangesTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorTab = new System.Windows.Forms.TabPage();
            this.applicationTabs.SuspendLayout();
            this.fetchDataTab.SuspendLayout();
            this.applyChangesTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // fetchBtn
            // 
            this.fetchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchBtn.Location = new System.Drawing.Point(6, 6);
            this.fetchBtn.Name = "fetchBtn";
            this.fetchBtn.Size = new System.Drawing.Size(142, 37);
            this.fetchBtn.TabIndex = 0;
            this.fetchBtn.Text = "Fetch Records";
            this.fetchBtn.UseVisualStyleBackColor = true;
            this.fetchBtn.Click += new System.EventHandler(this.fetchBtn_Click);
            // 
            // applyChanges
            // 
            this.applyChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyChanges.Location = new System.Drawing.Point(18, 6);
            this.applyChanges.Name = "applyChanges";
            this.applyChanges.Size = new System.Drawing.Size(131, 37);
            this.applyChanges.TabIndex = 1;
            this.applyChanges.Text = "Apply Changes";
            this.applyChanges.UseVisualStyleBackColor = true;
            // 
            // applicationTabs
            // 
            this.applicationTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applicationTabs.Controls.Add(this.fetchDataTab);
            this.applicationTabs.Controls.Add(this.applyChangesTab);
            this.applicationTabs.Controls.Add(this.errorTab);
            this.applicationTabs.Location = new System.Drawing.Point(80, 18);
            this.applicationTabs.Name = "applicationTabs";
            this.applicationTabs.SelectedIndex = 0;
            this.applicationTabs.Size = new System.Drawing.Size(602, 94);
            this.applicationTabs.TabIndex = 2;
            // 
            // fetchDataTab
            // 
            this.fetchDataTab.Controls.Add(this.fetchBtn);
            this.fetchDataTab.Location = new System.Drawing.Point(4, 33);
            this.fetchDataTab.Name = "fetchDataTab";
            this.fetchDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.fetchDataTab.Size = new System.Drawing.Size(594, 57);
            this.fetchDataTab.TabIndex = 0;
            this.fetchDataTab.Text = "Fetch Data";
            this.fetchDataTab.UseVisualStyleBackColor = true;
            // 
            // applyChangesTab
            // 
            this.applyChangesTab.Controls.Add(this.applyChanges);
            this.applyChangesTab.Location = new System.Drawing.Point(4, 33);
            this.applyChangesTab.Name = "applyChangesTab";
            this.applyChangesTab.Padding = new System.Windows.Forms.Padding(3);
            this.applyChangesTab.Size = new System.Drawing.Size(594, 57);
            this.applyChangesTab.TabIndex = 1;
            this.applyChangesTab.Text = "Apply Changes ";
            this.applyChangesTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(55, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 316);
            this.panel1.TabIndex = 3;
            // 
            // errorTab
            // 
            this.errorTab.Location = new System.Drawing.Point(4, 33);
            this.errorTab.Name = "errorTab";
            this.errorTab.Size = new System.Drawing.Size(594, 57);
            this.errorTab.TabIndex = 2;
            this.errorTab.Text = "Error";
            this.errorTab.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 491);
            this.Controls.Add(this.applicationTabs);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Task1_DuplicateUpgrades";
            this.applicationTabs.ResumeLayout(false);
            this.fetchDataTab.ResumeLayout(false);
            this.applyChangesTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button fetchBtn;
        private System.Windows.Forms.Button applyChanges;
        private System.Windows.Forms.TabControl applicationTabs;
        private System.Windows.Forms.TabPage fetchDataTab;
        private System.Windows.Forms.TabPage applyChangesTab;
        private System.Windows.Forms.TabPage errorTab;
        private System.Windows.Forms.Panel panel1;
    }
}

