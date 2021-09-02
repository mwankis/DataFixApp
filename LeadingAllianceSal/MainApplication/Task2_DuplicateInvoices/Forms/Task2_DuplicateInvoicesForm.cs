using BusinessLogic;
using MainApplication.Task2_DuplicateInvoices.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MainApplication.Task2_DuplicateInvoices.Forms
{
    public partial class Task2_DuplicateInvoicesForm : Form
    {
        private List<InvoiceModel> _dataRecords;

        private IOrganizationService _organizationService;

        public Task2_DuplicateInvoicesForm(IOrganizationService organizationService)
        {
            InitializeComponent();
            _organizationService = organizationService;
        }

        private void applyForTodayInvoices(object sender, EventArgs e)
        {
            var isChecked = dateFilterCheckBox.Checked;
            if (isChecked)
            {
                fromDate.Visible = false;
                dateTimeFrom.Visible = false;
            }
            else
            {
                fromDate.Visible = true;
                dateTimeFrom.Visible = true;
            }
        }

        private void applyChanges_Click(object sender, EventArgs e)
        {
            if (_organizationService == null || _dataRecords == null)
            {
                applicationTabs.SelectedIndex = 1;
                errorList.Items.Add("No crm connection please navigate to Connect To CRM tab, enter all required fields " +
                    "and click test connection");
                errorList.Items.Add("Or click fetch items first and then click apply changes");
                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
                return;
            }
            if (_dataRecords.Count == 0)
            {
                errorList.Items.Add("No items where returned");
                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
                return;
            }

            applicationTabs.SelectedIndex = 1;
            try
            {
                int recordCount = 0;
                foreach (var entityList in _dataRecords)
                {
                    if (entityList.EntityList.Count > 0)
                    {
                        entityList.EntityList.RemoveAt(0);
                        foreach (var entity in entityList.EntityList)
                        {
                            var operationResult = DynamicsService.DeactivateEntity(_organizationService, entity, 1, 2);
                            if (!operationResult.Succeded)
                            {
                                applicationTabs.SelectedIndex = 2;
                                errorList.Items.Add("Failed to deactivate record with id: " + entity.Id);
                                errorList.Items.Add(operationResult.ErrorMessage);
                                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
                            }
                            else
                            {
                                recordCount++;
                                errorList.Items.Add("Record successfully deactivated. Id: " + entity.Id + ". Record: " + recordCount + " of " + _dataRecords.Count);
                                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                applicationTabs.SelectedIndex = 1;
                errorList.Items.Add("Error occurred while executing applyChanges_Click() method. " + ex.Message);
                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
            }
        }

        private void fetchBtn_Click(object sender, EventArgs e)
        {
            // Get duplicate invoices that have the same customer, customer card, invoice number, invoice date and created date
            dataRecordsGridView.Rows.Clear();
            dataRecordsGridView.Refresh();
            _dataRecords = new List<InvoiceModel>();
            var dateFrom = dateTimeFrom.Value;
            var columns = new string[] { "new_awardedpoints", "customerid", "new_invoicedate", "new_customercardid", "createdon", "name", "new_invoiceno" };
            var query = new QueryExpression("invoice")
            {
                ColumnSet = new ColumnSet(columns)
            };
            query.AddOrder("customerid", OrderType.Ascending);
            query.AddOrder("createdon", OrderType.Ascending);
            var isChecked = dateFilterCheckBox.Checked;
            if (isChecked)
            {
                query.Criteria.AddCondition("createdon", ConditionOperator.Today);
            }
            else
            {
                query.Criteria.AddCondition("createdon", ConditionOperator.OnOrAfter, dateFrom);
            }
            query.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            var operationResult = DynamicsService.RetrieveAllRecords(_organizationService, query);

            if (operationResult.Succeded)
            {
                recordCount.Text = "" + operationResult.EntityList.Count;

                AddRecordsToDictionary(operationResult.EntityList);

                AddRecordsToDataGridView();

                FormatCellsColor();
            }
            else
            {
                applicationTabs.SelectedIndex = 1;
                errorList.Items.Add(operationResult.ErrorMessage);
                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
            }
        }

        private void AddRecordsToDataGridView()
        {
            try
            {
                int colourCount = 0;
                foreach (var dataEntry in _dataRecords)
                {
                    foreach (var entity in dataEntry.EntityList)
                    {
                        var customer = entity.GetAttributeValue<EntityReference>("customerid");
                        var card = entity.GetAttributeValue<EntityReference>("new_customercardid");
                        var invoiceDate = entity.GetAttributeValue<DateTime>("new_invoicedate");
                        var createdonDate = entity.GetAttributeValue<DateTime>("createdon");
                        var invoiceNo = entity.GetAttributeValue<string>("new_invoiceno");
                        var invoiceName = entity.GetAttributeValue<string>("name");

                        DataGridViewRow row = (DataGridViewRow)dataRecordsGridView.Rows[0].Clone();

                        row.Cells[0].Value = invoiceName;
                        row.Cells[1].Value = customer.Id.ToString();
                        row.Cells[2].Value = card.Id.ToString();
                        row.Cells[3].Value = invoiceNo;
                        row.Cells[4].Value = invoiceDate.ToString();
                        row.Cells[5].Value = createdonDate.ToString();
                        if (colourCount % 2 == 0)
                        {
                            row.Cells[6].Value = "grey";
                        }


                        dataRecordsGridView.Rows.Add(row);
                    }
                    colourCount++;
                }
            }
            catch (Exception ex)
            {
                applicationTabs.SelectedIndex = 1;
                errorList.Items.Add("Error occurred while executing AddRecordsToDataGridView() method. " + ex.Message);
                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
            }

        }

        private void FormatCellsColor()
        {
            try
            {
                foreach (DataGridViewRow row in dataRecordsGridView.Rows)
                {
                    var rowCell = row.Cells[6];
                    if (rowCell.Value != null)
                    {
                        string rowColour = row.Cells[5].Value.ToString();
                        if (rowColour == "grey")
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                            row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                applicationTabs.SelectedIndex = 1;
                errorList.Items.Add("Error occurred while executing FormatCellsColor() method. " + ex.Message);
                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
            }

        }

        private void AddRecordsToDictionary(List<Entity> entityCollection)
        {
            try
            {

                foreach (var entity in entityCollection)
                {
                    if (entity.Attributes.ContainsKey("customerid")
                        && entity.Attributes.ContainsKey("new_invoicedate")
                        && entity.Attributes.ContainsKey("createdon")
                        && entity.Attributes.ContainsKey("new_invoiceno")
                        && entity.Attributes.ContainsKey("new_customercardid"))
                    {
                        var customer = entity.GetAttributeValue<EntityReference>("customerid");
                        var card = entity.GetAttributeValue<EntityReference>("new_customercardid");
                        var invoiceDate = entity.GetAttributeValue<DateTime>("new_invoicedate");
                        var createdonDate = entity.GetAttributeValue<DateTime>("createdon");
                        var invoiceNo = entity.GetAttributeValue<string>("new_invoiceno");
                        var key = new DictionaryKey
                        {
                            Customer = customer.Id,
                            CustomerCard = card.Id,
                            CreatedDate = createdonDate,
                            InvoiceDate = invoiceDate,
                            InvoiceNumber = invoiceNo
                        };

                        var curData = GetList(key);
                        if (curData != null)
                        {
                            curData.EntityList.Add(entity);
                        }
                        else
                        {
                            var dataEntry = new InvoiceModel();
                            dataEntry.EntityList.Add(entity);
                            dataEntry.DictionaryKey = key;
                            _dataRecords.Add(dataEntry);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                applicationTabs.SelectedIndex = 1;
                errorList.Items.Add("Error occurred while executing AddRecordsToDictionary() method. " + ex.Message);
                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
            }

        }

        private InvoiceModel GetList(DictionaryKey key)
        {
            foreach (var record in _dataRecords)
            {
                if (record.DictionaryKey.CustomerCard.Equals(key.CustomerCard)
                    && record.DictionaryKey.Customer.Equals(key.Customer)
                    && record.DictionaryKey.InvoiceDate.Equals(key.InvoiceDate)
                    && record.DictionaryKey.CreatedDate.Equals(key.CreatedDate)
                    && record.DictionaryKey.InvoiceNumber.Equals(key.InvoiceNumber))
                {
                    return record;
                }
            }

            return null;
        }

    }
}


