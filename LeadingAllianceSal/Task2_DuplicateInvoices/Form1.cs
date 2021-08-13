using BusinessLogic;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Task2_DuplicateInvoices
{
    public partial class Form1 : Form
    {
        private List<InvoiceModel> _dataRecords;

        private IOrganizationService _organizationService;

        public Form1()
        {
            InitializeComponent();
        }

        private void testConnectionBtn_Click(object sender, EventArgs e)
        {
            string userNameValue = userName.Text;
            string passwordValue = password.Text;
            var soapUrlEndpoint = soapUrl.Text;

            var getOrganizationService = ConnectToCRM.ConnectToMSCRM(userNameValue, passwordValue, soapUrlEndpoint);
            _organizationService = getOrganizationService.OrganizationService;

            try
            {
                if (string.IsNullOrEmpty(getOrganizationService.ErrorMessage))
                {
                    Guid userid = ((WhoAmIResponse)_organizationService.Execute(new WhoAmIRequest())).UserId;
                    if (!userid.Equals(Guid.Empty))
                    {
                        connectionStatus.Text = "Connected successfully";
                        connectionStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        connectionStatus.Text = "Failed to connect";
                        connectionStatus.ForeColor = Color.Red;
                    }
                }
                else
                {
                    connectionStatus.Text = getOrganizationService.ErrorMessage;
                    connectionStatus.ForeColor = Color.Red;
                }

            }
            catch (Exception ex)
            {
                connectionStatus.Text = "Failed to connect. Error Message: " + ex.Message;
                connectionStatus.ForeColor = Color.Red;
            }
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
    }
}
