using MainApplication.Helpers;
using MainApplication.Task4_MissingOpeningInvoices.BusinessLogic;
using MainApplication.Task4_MissingOpeningInvoices.Models.Api;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainApplication.Task4_MissingOpeningInvoices.Forms
{
    public partial class Task4_MissingOpeningInvoicesForm : Form
    {
        private readonly IOrganizationService _organizationService;

        private List<ApiPoint> _apiPoints;

        private List<Entity>  _crmaddDeducts;

        public Task4_MissingOpeningInvoicesForm(IOrganizationService organizationService)
        {
            InitializeComponent();
            _organizationService = organizationService;
        }

        private void callApiBtn_Click(object sender, EventArgs e)
        {
            var fromDate = dateTimeFrom.Value;
            var to = dateTo.Value;
            var apiPointsResponse = ApiPointsLogic.GetApiPoints(fromDate, to);
            if (string.IsNullOrEmpty(apiPointsResponse.ErrorMessage))
            {
                _apiPoints = apiPointsResponse.ApiPoints;
                AddApiPointsToGrid();
            }
            else
            {
                applicationTabs.SelectedIndex = 2;
                GeneralHelper.LogStatus(errorList, apiPointsResponse.ErrorMessage);
            }
        }

        private void AddApiPointsToGrid()
        {
            try
            {
                foreach (var apiPoint in _apiPoints)
                {
                    var reason = apiPoint.Reason.ToString();
                    var clientId = apiPoint.ClientId.ToString();
                    var updateDate = apiPoint.UpdatedOn.ToString();
                    var points = apiPoint.Points;

                    DataGridViewRow row = (DataGridViewRow)crmInvoicesGridView.Rows[0].Clone();
                    row.Cells[0].Value = clientId;
                    row.Cells[1].Value = points;
                    row.Cells[2].Value = reason;
                    row.Cells[3].Value = updateDate.ToString();
                    crmInvoicesGridView.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                applicationTabs.SelectedIndex = 2;
                GeneralHelper.LogStatus(errorList, "Error occurred while executing AddRecordsToDataGridView() method. " + ex.Message);
            }
        }

        private void getDynamicsDataBtn_Click(object sender, EventArgs e)
        {
            var fromDate = dateTimeFrom.Value;
            var toDate = dateTo.Value;

            var crmResponse = CrmAdddeductLogic.GetAdddeducts(_organizationService, fromDate, toDate);
            if (string.IsNullOrEmpty(crmResponse.ErrorMessage))
            {
                _crmaddDeducts = crmResponse.EntityList;
                AddCrmAdddeductToGrid();
            }
            else
            {
                applicationTabs.SelectedIndex = 2;
                GeneralHelper.LogStatus(errorList, crmResponse.ErrorMessage);
            }

        }


        private void AddCrmAdddeductToGrid()
        {
            try
            {
                foreach (var entity in _crmaddDeducts)
                {
                    var customerid = entity.GetAttributeValue<EntityReference>("new_customerid");
                    var reason = entity.GetAttributeValue<string>("new_reason");
                    var additiondeduction = entity.GetAttributeValue<bool>("new_additiondeduction");
                    var points = entity.GetAttributeValue<string>("new_points");
                    var date = entity.GetAttributeValue<DateTime>("new_date");
                    var createdon = entity.GetAttributeValue<DateTime>("createdon");

                    DataGridViewRow row = (DataGridViewRow)crmInvoicesGridView.Rows[0].Clone();
                    row.Cells[0].Value = customerid.Id;
                    row.Cells[1].Value = reason;
                    row.Cells[2].Value = points;
                    row.Cells[3].Value = $"{additiondeduction}";
                    row.Cells[4].Value = date.ToString();
                    row.Cells[5].Value = createdon.ToString();
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

        private void synchronizeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var recordCount = 0;
                foreach (var apiPoint in _apiPoints)
                {
                    recordCount++;
                    var statusCount = $"Processing {recordCount} of {_apiPoints.Count}";
                    var apiPointResponse = CrmAdddeductLogic.GetAdddeduct(_crmaddDeducts, apiPoint);
                    if (apiPointResponse == null)
                    {
                        CrmAdddeductLogic.CreateAddDeduct(_organizationService, apiPoint);
                    }
                    else
                    {
                        GeneralHelper.LogStatus(errorList, "Api point already exists", statusCount);
                    }
                }
            }
            catch (Exception ex)
            {
                GeneralHelper.LogStatus(errorList, ex.Message);
            }
        }
    }
}
