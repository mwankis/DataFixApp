namespace MainApplication.Task5_ZeroAwardedPoints.Forms
{
    partial class Task5_ZeroAwardedPointsForm
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
            this.errorTab = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorList = new System.Windows.Forms.ListBox();
            this.updateCrmInvoicesBtn = new System.Windows.Forms.Button();
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.fromDate = new System.Windows.Forms.Label();
            this.invoiceCnt = new System.Windows.Forms.Label();
            this.apiInvoicesGridView = new System.Windows.Forms.DataGridView();
            this.CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.getDynamicsDataBtn = new System.Windows.Forms.Button();
            this.apiInvoices = new System.Windows.Forms.TabPage();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applicationTabs.SuspendLayout();
            this.errorTab.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.apiInvoicesGridView)).BeginInit();
            this.apiInvoices.SuspendLayout();
            this.SuspendLayout();
            // 
            // applicationTabs
            // 
            this.applicationTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applicationTabs.Controls.Add(this.apiInvoices);
            this.applicationTabs.Controls.Add(this.errorTab);
            this.applicationTabs.Location = new System.Drawing.Point(3, 12);
            this.applicationTabs.Name = "applicationTabs";
            this.applicationTabs.SelectedIndex = 0;
            this.applicationTabs.Size = new System.Drawing.Size(903, 419);
            this.applicationTabs.TabIndex = 6;
            // 
            // errorTab
            // 
            this.errorTab.Controls.Add(this.panel2);
            this.errorTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorTab.Location = new System.Drawing.Point(4, 22);
            this.errorTab.Name = "errorTab";
            this.errorTab.Size = new System.Drawing.Size(895, 393);
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
            this.panel2.Size = new System.Drawing.Size(895, 393);
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
            this.errorList.Size = new System.Drawing.Size(887, 364);
            this.errorList.TabIndex = 0;
            // 
            // updateCrmInvoicesBtn
            // 
            this.updateCrmInvoicesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateCrmInvoicesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateCrmInvoicesBtn.Location = new System.Drawing.Point(730, 7);
            this.updateCrmInvoicesBtn.Name = "updateCrmInvoicesBtn";
            this.updateCrmInvoicesBtn.Size = new System.Drawing.Size(149, 32);
            this.updateCrmInvoicesBtn.TabIndex = 2;
            this.updateCrmInvoicesBtn.Text = "Update Crm Invoices";
            this.updateCrmInvoicesBtn.UseVisualStyleBackColor = true;
            this.updateCrmInvoicesBtn.Click += new System.EventHandler(this.updateCrmInvoicesBtn_Click);
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeFrom.Location = new System.Drawing.Point(103, 13);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(209, 22);
            this.dateTimeFrom.TabIndex = 4;
            // 
            // fromDate
            // 
            this.fromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fromDate.AutoSize = true;
            this.fromDate.Location = new System.Drawing.Point(58, 17);
            this.fromDate.Name = "fromDate";
            this.fromDate.Size = new System.Drawing.Size(0, 16);
            this.fromDate.TabIndex = 5;
            // 
            // invoiceCnt
            // 
            this.invoiceCnt.AutoSize = true;
            this.invoiceCnt.Location = new System.Drawing.Point(7, 15);
            this.invoiceCnt.Name = "invoiceCnt";
            this.invoiceCnt.Size = new System.Drawing.Size(0, 16);
            this.invoiceCnt.TabIndex = 8;
            // 
            // apiInvoicesGridView
            // 
            this.apiInvoicesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.apiInvoicesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.apiInvoicesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apiInvoicesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.apiInvoicesGridView.Location = new System.Drawing.Point(5, 43);
            this.apiInvoicesGridView.Margin = new System.Windows.Forms.Padding(2);
            this.apiInvoicesGridView.Name = "apiInvoicesGridView";
            this.apiInvoicesGridView.RowTemplate.Height = 24;
            this.apiInvoicesGridView.Size = new System.Drawing.Size(885, 346);
            this.apiInvoicesGridView.TabIndex = 10;
            // 
            // CreatedOn
            // 
            this.CreatedOn.HeaderText = "LastName";
            this.CreatedOn.Name = "CreatedOn";
            this.CreatedOn.ReadOnly = true;
            // 
            // NewDate
            // 
            this.NewDate.HeaderText = "FirstName";
            this.NewDate.Name = "NewDate";
            this.NewDate.ReadOnly = true;
            // 
            // CardId
            // 
            this.CardId.HeaderText = "Cust_CardId";
            this.CardId.Name = "CardId";
            this.CardId.ReadOnly = true;
            // 
            // CustomerId
            // 
            this.CustomerId.HeaderText = "Date";
            this.CustomerId.Name = "CustomerId";
            this.CustomerId.ReadOnly = true;
            // 
            // Colour
            // 
            this.Colour.HeaderText = "GiftVoucher";
            this.Colour.Name = "Colour";
            this.Colour.ReadOnly = true;
            this.Colour.Visible = false;
            // 
            // Name
            // 
            this.Name.HeaderText = "InvoiceNo";
            this.Name.Name = "Name";
            // 
            // dateTo
            // 
            this.dateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTo.Location = new System.Drawing.Point(347, 11);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(209, 22);
            this.dateTo.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 12;
            // 
            // getDynamicsDataBtn
            // 
            this.getDynamicsDataBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.getDynamicsDataBtn.Location = new System.Drawing.Point(579, 7);
            this.getDynamicsDataBtn.Name = "getDynamicsDataBtn";
            this.getDynamicsDataBtn.Size = new System.Drawing.Size(127, 32);
            this.getDynamicsDataBtn.TabIndex = 13;
            this.getDynamicsDataBtn.Text = "Get CRM Invoices";
            this.getDynamicsDataBtn.UseVisualStyleBackColor = true;
            this.getDynamicsDataBtn.Click += new System.EventHandler(this.getDynamicsDataBtn_Click);
            // 
            // apiInvoices
            // 
            this.apiInvoices.Controls.Add(this.getDynamicsDataBtn);
            this.apiInvoices.Controls.Add(this.label1);
            this.apiInvoices.Controls.Add(this.dateTo);
            this.apiInvoices.Controls.Add(this.apiInvoicesGridView);
            this.apiInvoices.Controls.Add(this.invoiceCnt);
            this.apiInvoices.Controls.Add(this.fromDate);
            this.apiInvoices.Controls.Add(this.dateTimeFrom);
            this.apiInvoices.Controls.Add(this.updateCrmInvoicesBtn);
            this.apiInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiInvoices.Location = new System.Drawing.Point(4, 22);
            this.apiInvoices.Name = "apiInvoices";
            this.apiInvoices.Padding = new System.Windows.Forms.Padding(3);
            this.apiInvoices.Size = new System.Drawing.Size(895, 393);
            this.apiInvoices.TabIndex = 0;
            this.apiInvoices.Text = "Api Invoices";
            this.apiInvoices.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Task5_ZeroAwardedPointsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 443);
            this.Controls.Add(this.applicationTabs);
            this.Text = "Task5_ZeroAwardedPoints";
            this.applicationTabs.ResumeLayout(false);
            this.errorTab.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.apiInvoicesGridView)).EndInit();
            this.apiInvoices.ResumeLayout(false);
            this.apiInvoices.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl applicationTabs;
        private System.Windows.Forms.TabPage errorTab;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox errorList;
        private System.Windows.Forms.TabPage apiInvoices;
        private System.Windows.Forms.Button getDynamicsDataBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.DataGridView apiInvoicesGridView;
        private System.Windows.Forms.Label invoiceCnt;
        private System.Windows.Forms.Label fromDate;
        private System.Windows.Forms.DateTimePicker dateTimeFrom;
        private System.Windows.Forms.Button updateCrmInvoicesBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colour;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}