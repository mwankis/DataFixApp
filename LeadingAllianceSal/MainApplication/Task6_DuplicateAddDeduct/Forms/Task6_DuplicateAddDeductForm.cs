using BusinessLogic;
using MainApplication.Task6_DuplicateAddDeduct.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MainApplication.Task6_DuplicateAddDeduct.Forms
{
    public partial class Task6_DuplicateAddDeductForm : Form
    {
        private readonly IOrganizationService _organizationService;

        private List<AddDeductModel> _dataRecords;

        public Task6_DuplicateAddDeductForm(IOrganizationService organizationService)
        {
            InitializeComponent();
            _organizationService = organizationService;
        }
        
        private void fetchBtn_Click(object sender, EventArgs e)
        {
            dataRecordsGridView.Rows.Clear();
            dataRecordsGridView.Refresh();
            _dataRecords = new List<AddDeductModel>();
            var dateFrom = dateTimeFrom.Value;
            var dateFromTo = dateTo.Value;
            var query = new QueryExpression("new_adddeduct")
            {
                ColumnSet = new ColumnSet(true)
            };
            query.AddOrder("new_customerid", OrderType.Ascending);
            query.AddOrder("new_date", OrderType.Ascending);
            var isChecked = dateFilterCheckBox.Checked;
            if (isChecked)
            {
                query.Criteria.AddCondition("createdon", ConditionOperator.OnOrAfter, dateFrom);
                query.Criteria.AddCondition("createdon", ConditionOperator.OnOrBefore, dateFromTo);
            }
            query.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            query.Criteria.AddCondition("new_name", ConditionOperator.Equal, "Upgrade");
            query.Criteria.AddCondition("new_reason", ConditionOperator.Equal, "Upgrade");
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
                int curRecordCount = 0;
                foreach (var entityList in _dataRecords)
                {
                    if (entityList.EntityList.Count > 0)
                    {
                        var oldestRecord = GetOldestRecord(entityList.EntityList);
                        entityList.EntityList.Remove(oldestRecord);
                        foreach (var entity in entityList.EntityList)
                        {
                            curRecordCount++;
                            var operationResult = DynamicsService.DeactivateEntity(_organizationService, entity, 1, 2);
                            var status = $"Processing record: {curRecordCount} of { _dataRecords.Count}";
                            if (!operationResult.Succeded)
                            {
                                errorList.Items.Add($"{status}. Failed to deactivate record with id: {entity.Id}");
                                errorList.Items.Add(operationResult.ErrorMessage);
                                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
                            }
                            else
                            {
                                errorList.Items.Add($"{status}. Record successfully deactivated. Id: {entity.Id}");
                                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
                            }

                            var addDedductInvoice = GetAdddeductInvoice(entity.Id);
                            if (addDedductInvoice != null)
                            {
                                var deactivateAdddeductInvoiceResult = DynamicsService.DeactivateEntity(_organizationService, addDedductInvoice, 3, 100003);
                                if (!operationResult.Succeded)
                                {
                                    errorList.Items.Add($"{status}. Failed to deactivate AdddeductInvoice with id: {addDedductInvoice.Id}");
                                    errorList.Items.Add(operationResult.ErrorMessage);
                                    errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
                                }
                                else
                                {
                                    errorList.Items.Add($"{status}. AdddeductInvoice successfully deactivated. Id: {addDedductInvoice.Id}");
                                    errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
                                }
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

        private Entity GetAdddeductInvoice(Guid adddeductId)
        {
            var query = new QueryExpression("invoice");
            query.Criteria.AddCondition("new_adddeductid", ConditionOperator.Equal, adddeductId);
            query.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
            var entityCollection = _organizationService.RetrieveMultiple(query);
            if (entityCollection.Entities.Count > 0)
            {
                return entityCollection.Entities[0];
            }

            return null;
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
                        string rowColour = row.Cells[6].Value.ToString();
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
                    if (entity.Attributes.ContainsKey("new_customerid")
                        && entity.Attributes.ContainsKey("new_points")
                        //&& entity.Attributes.ContainsKey("new_additiondeduction")
                        && entity.Attributes.ContainsKey("new_date"))
                    {
                        var customer = entity.GetAttributeValue<EntityReference>("new_customerid");
                        var points = entity.GetAttributeValue<int>("new_points");
                        var date = entity.GetAttributeValue<DateTime>("new_date");
                        // var additionDeduction = entity.GetAttributeValue<DateTime>("new_additiondeduction");
                        var key = new DictionaryKey
                        {
                            Points = points,
                            CustomerId = customer.Id,
                            Date = date
                        };

                        var curData = GetList(key);
                        if (curData != null)
                        {
                            curData.EntityList.Add(entity);
                        }
                        else
                        {
                            var dataEntry = new AddDeductModel();
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

        private AddDeductModel GetList(DictionaryKey key)
        {
            foreach (var record in _dataRecords)
            {
                if (record.DictionaryKey.Points.Equals(key.Points) && record.DictionaryKey.CustomerId.Equals(key.CustomerId)
                    && record.DictionaryKey.Date.Date.Equals(key.Date.Date))
                {
                    return record;
                }
            }

            return null;
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
                        var customer = entity.GetAttributeValue<EntityReference>("new_customerid");
                        var points = entity.GetAttributeValue<int>("new_points");
                        var date = entity.GetAttributeValue<DateTime>("new_date");
                        var name = entity.GetAttributeValue<string>("new_name");
                        var reason = entity.GetAttributeValue<string>("new_reason");
                        var createdon = entity.GetAttributeValue<DateTime>("createdon");

                        DataGridViewRow row = (DataGridViewRow)dataRecordsGridView.Rows[0].Clone();

                        row.Cells[0].Value = name;
                        row.Cells[1].Value = customer.Id.ToString();
                        row.Cells[2].Value = $"{points}";
                        row.Cells[3].Value = reason;
                        row.Cells[4].Value = date.ToString();
                        row.Cells[5].Value = createdon.ToString();
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

        private Entity GetOldestRecord(List<Entity> entityList)
        {
            var curId = Guid.Empty;
            try
            {
                var tempOldest = entityList[0];
                foreach (var entity in entityList)
                {
                    curId = entity.Id;
                    var curDate = entity.GetAttributeValue<DateTime>("createdon");
                    var tempOldestDate = tempOldest.GetAttributeValue<DateTime>("createdon");
                    if (tempOldestDate > curDate)
                    {
                        tempOldest = entity;
                    }
                }
                return tempOldest;
            }
            catch (Exception ex)
            {
                applicationTabs.SelectedIndex = 1;
                errorList.Items.Add("Error occurred while executing GetOldestRecord() method. Id: " + curId + ". " + ex.Message);
                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
                return null;
            }

        }

        private void dateFilterChange(object sender, EventArgs e)
        {
            var isChecked = dateFilterCheckBox.Checked;
            if (isChecked)
            {
                fromDate.Visible = true;
                dateTimeFrom.Visible = true;
                label1.Visible = true;
                dateTo.Visible = true;
            }
            else
            {
                fromDate.Visible = false;
                dateTimeFrom.Visible = false;
                label1.Visible = false;
                dateTo.Visible = false;
            }
        }
    }
}

