using MainApplication.Helpers;
using MainApplication.Task5_ZeroAwardedPoints.BusinessLogic;
using MainApplication.Task5_ZeroAwardedPoints.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainApplication.Task5_ZeroAwardedPoints.Forms
{
    public partial class Task5_ZeroAwardedPointsForm : Form
    {
        private readonly IOrganizationService _organizationService;

        private List<Entity> _crmInvoices = new List<Entity>();

        private List<ApiInvoice> _apiInvoices = new List<ApiInvoice>();

        public Task5_ZeroAwardedPointsForm(IOrganizationService organizationService)
        {
            InitializeComponent();
            _organizationService = organizationService;
        }

        private void getDynamicsDataBtn_Click(object sender, EventArgs e)
        {
            var fromDate = dateTimeFrom.Value;
            var toDate = dateTo.Value;

            var getCrmPurchaseInvoice = CrmPurchaseInvoiceLogic.GetCrmPurchaseInvoice(_organizationService, fromDate, toDate);
            _crmInvoices = getCrmPurchaseInvoice.EntityList;
            recordsCount.Text = $"Crm Invoices: {_crmInvoices.Count}  || Api Invoices: {_apiInvoices.Count}";
            AddCrmInvoicesToGrid();
        }

        private void AddCrmInvoicesToGrid()
        {
            try
            {
                foreach (var entity in _crmInvoices)
                {
                    var invoiceNo = entity.GetAttributeValue<string>("new_invoiceno");
                    var clientId = entity.GetAttributeValue<string>("new_clientid");
                    var invoiceDate = entity.GetAttributeValue<DateTime>("new_invoicedate");
                    var points = entity.GetAttributeValue<string>("new_awardedpoints");
                    var createdon = entity.GetAttributeValue<DateTime>("createdon");

                    DataGridViewRow row = (DataGridViewRow)crmInvoicesGridView.Rows[0].Clone();
                    row.Cells[0].Value = invoiceNo;
                    row.Cells[1].Value = clientId;
                    row.Cells[2].Value = points;
                    row.Cells[3].Value = invoiceDate.ToString();
                    row.Cells[4].Value = createdon.ToString();                   
                    crmInvoicesGridView.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                applicationTabs.SelectedIndex = 1;
                errorList.Items.Add("Error occurred while executing AddRecordsToDataGridView() method. " + ex.Message);
                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
            }
        }

        private void GetApiInvoicesBtn_Click(object sender, EventArgs e)
        {
            var fromDate = dateTimeFrom.Value;
            var toDate = dateTo.Value;
            var invoicesResponse = CallApiLogic.GetApiPoints(fromDate, toDate);
            if (string.IsNullOrEmpty(invoicesResponse.ErrorMessage))
            {
                _apiInvoices = invoicesResponse.ApiInvoices;
                recordsCount.Text = $"Crm Invoices: {_crmInvoices.Count}  || Api Invoices: {_apiInvoices.Count}";
            }
            else
            {
                GeneralHelper.LogStatus(errorList, $"{invoicesResponse.ErrorMessage}");
            }
        }

        private void AddApiInvoicesToGrid()
        {
            try
            {
                foreach (var apiInvoice in _apiInvoices)
                {
                    var invoiceNo = apiInvoice.InvoiceNo.ToString();
                    var clientId = apiInvoice.ClientId.ToString();
                    var invoiceDate = apiInvoice.Date.ToString();
                    var points = apiInvoice.PointsNbr;

                    DataGridViewRow row = (DataGridViewRow)crmInvoicesGridView.Rows[0].Clone();
                    row.Cells[0].Value = invoiceNo;
                    row.Cells[1].Value = clientId;
                    row.Cells[2].Value = points;
                    row.Cells[3].Value = invoiceDate.ToString();
                    crmInvoicesGridView.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                applicationTabs.SelectedIndex = 1;
                errorList.Items.Add("Error occurred while executing AddRecordsToDataGridView() method. " + ex.Message);
                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
            }
        }

        private void updateCrmInvoicesBtn_Click(object sender, EventArgs e)
        {
            if (_crmInvoices.Count == 0 )
            {
                MessageBox.Show("There are no crm invoices click get crm invoices first");
                return;
            }

            if (_apiInvoices.Count == 0)
            {
                MessageBox.Show("There are no api invoices click get crm invoices first");
                return;
            }

            applicationTabs.SelectedIndex = 1;
            try
            {
                int recordCount = 0;
                foreach (var crmInvoice in _crmInvoices)
                {
                    recordCount++;
                    var status = $"Processing {recordCount} of {_crmInvoices.Count}.";
                    var apiInvoice = CrmPurchaseInvoiceLogic.GetApiInvoice(_apiInvoices, crmInvoice);
                    if (apiInvoice != null)
                    {
                        var updateResult = CrmPurchaseInvoiceLogic.UpdatePurchaseInvoice(_organizationService,
                            crmInvoice, apiInvoice);
                        GeneralHelper.LogStatus(errorList, $"Invoice with id: {crmInvoice.Id} successfully updated", status);
                    }
                    else
                    {
                        GeneralHelper.LogStatus(errorList, $"No api invoice for Crm Invoice with id: {crmInvoice.Id}", status);
                    }
                }

            }
            catch (Exception ex)
            {
                GeneralHelper.LogStatus(errorList, $"Something went wrong. Error Message: {ex.Message}");
            }

        }

       
    }
}
