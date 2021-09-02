using MainApplication.Task3.ApplicationLogic;
using MainApplication.Task3.Models.Api;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainApplication.Task3.Forms
{
    public partial class Task3_Form : Form
    {
        private IOrganizationService _organizationService;

        private List<ApiInvoice> _apiInvoices;

        private List<Entity> _crmInvoices;

        public Task3_Form(IOrganizationService organizationService)
        {
            InitializeComponent();
            _organizationService = organizationService;
        }

        private void callApiBtn_Click(object sender, System.EventArgs e)
        {
            var fromDate = dateTimeFrom.Value;
            var toDate = dateTimeFrom.Value;
            var apiCallResponse = ApiInvoicesLogic.GetApiInvoices(fromDate, toDate);
            if (string.IsNullOrEmpty(apiCallResponse.ErrorMessage))
            {
                _apiInvoices = apiCallResponse.Invoices;
                invoiceCnt.Text = $"Api Incoives: {_apiInvoices.Count.ToString()}   Crm Incoives: {_crmInvoices.Count.ToString()}";
                LoadApiInvoiceGrid();
            }
            else
            {
                errorList.Items.Add(apiCallResponse.ErrorMessage);
                applicationTabs.SelectedIndex = 2;
                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");

            }
        } 
        
        private void LoadApiInvoiceGrid()
        {
            apiInvoicesGridView.Rows.Clear();
            apiInvoicesGridView.Refresh();

            foreach (var apiInvoice in _apiInvoices)
            {
                DataGridViewRow row = (DataGridViewRow)apiInvoicesGridView.Rows[0].Clone();
                row.Cells[0].Value = $"{apiInvoice.InvoiceNo}";
                row.Cells[1].Value = $"{apiInvoice.GiftVoucher}";
                row.Cells[2].Value = $"{apiInvoice.Date}";
                row.Cells[3].Value = $"{apiInvoice.cust_cardid}";
                row.Cells[4].Value = $"{apiInvoice.FirstName}";
                row.Cells[5].Value = $"{apiInvoice.LastName}";
                apiInvoicesGridView.Rows.Add(row);
            }
        }

        private void getDynamicsDataBtn_Click(object sender, System.EventArgs e)
        {
            var fromDate = dateTimeFrom.Value;
            var toDate = dateTimeFrom.Value;
            var crmResponse = CrmInvoicesLogic.GetCrmInvoices(_organizationService, fromDate, toDate);
            if (string.IsNullOrEmpty(crmResponse.ErrorMessage))
            {
               _crmInvoices = crmResponse.Entities;
               invoiceCnt.Text = $"Api Incoives: {_apiInvoices.Count.ToString()}     |      Crm Incoives: {_crmInvoices.Count.ToString()}";
               LoadCrmInvoiceGrid();
            }
            else
            {
                errorList.Items.Add(crmResponse.ErrorMessage);
                applicationTabs.SelectedIndex = 2;
                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");

            }

        }

        private void LoadCrmInvoiceGrid()
        {            
            crmInvoicesGridView.Rows.Clear();
            crmInvoicesGridView.Refresh();

            foreach (var crmInvoice in _crmInvoices)
            {
                try
                {
                    var customer = crmInvoice.GetAttributeValue<EntityReference>("customerid");
                    var card = crmInvoice.GetAttributeValue<EntityReference>("new_customercardid");
                    var invoiceDate = crmInvoice.GetAttributeValue<DateTime>("new_invoicedate");
                    var createdonDate = crmInvoice.GetAttributeValue<DateTime>("createdon");
                    var invoiceNo = crmInvoice.GetAttributeValue<string>("new_invoiceno");

                    DataGridViewRow row = (DataGridViewRow)crmInvoicesGridView.Rows[0].Clone();

                    row.Cells[0].Value = invoiceNo;
                    row.Cells[1].Value = customer.Id.ToString();
                    row.Cells[2].Value = card.Id.ToString();
                    row.Cells[3].Value = invoiceDate.ToString();
                    row.Cells[4].Value = createdonDate.ToString();
                    crmInvoicesGridView.Rows.Add(row);
                }
                catch (Exception)
                {

                }
               
            }
        }


        private void synchronizeBtn_Click(object sender, System.EventArgs e)
        {
            if (_apiInvoices.Count == 0)
            {
                MessageBox.Show("No Invoices returned from api, or click Call API and Get Crm Invoices first and click Synchronize button");
                return;
            }

            Task3MainLogic.SynchronizeInvoices(_organizationService, applicationTabs, errorList, _crmInvoices, _apiInvoices);
        }

        private void Task3_Form_Load(object sender, System.EventArgs e)
        {
            invoiceCnt.Text = $"Api Incoives: 0     |    Crm Incoives: 0";

        }
    }
}
