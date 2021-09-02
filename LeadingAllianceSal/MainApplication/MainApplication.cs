using BusinessLogic;
using MainApplication.Configs.Models;
using MainApplication.Constants;
using MainApplication.Helpers;
using MainApplication.Task1.Forms;
using MainApplication.Task3.Forms;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;
using System.Drawing;
using System.Windows.Forms;
using MainApplication.Task2_DuplicateInvoices.Forms;
using MainApplication.Task5_ZeroAwardedPoints.Forms;
using MainApplication.Task4_MissingOpeningInvoices.Forms;

namespace MainApplication
{
    public partial class MainApplication : Form
    {
        private IOrganizationService _organizationService;

        public MainApplication()
        {
            InitializeComponent();
        }

        private void showPassword_Click(object sender, EventArgs e)
        {
            if (!showPassword.Text.Equals("Hide Password"))
            {
                showPassword.Text = "Hide Password";
                password.PasswordChar = '\0';
            }
            else
            {
                showPassword.Text = "Show Password";
                password.PasswordChar = '*';
            }
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

        private void task1Btn_Click(object sender, EventArgs e)
        {          
            var form = new Task1_Form(_organizationService);
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }


        private void task3Btn_Click(object sender, EventArgs e)
        {
            var form = new Task3_Form(_organizationService);
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void task2Btn_Click(object sender, EventArgs e)
        {
            var form = new Task2_DuplicateInvoicesForm(_organizationService);
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void task4Btn_Click(object sender, EventArgs e)
        {
            var form = new Task4_MissingOpeningInvoicesForm(_organizationService);
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void task5Btn_Click(object sender, EventArgs e)
        {
            var form = new Task5_ZeroAwardedPointsForm(_organizationService);
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void loadAppSettingsValues(object sender, EventArgs e)
        {
            var isChecked = loadAppSettings.Checked;
            if (isChecked)
            {
                var appsettingsFileName = ApplicationConstants.ApplicationSettingsFileName;
                var appSettings = ApplicationSettingsHelper.GetModelFromJsonFile<ApplicationSettings>(appsettingsFileName); 
                soapUrl.Text = appSettings.DynamicsConnections.Url;
                userName.Text = appSettings.DynamicsConnections.Username;
                password.Text = appSettings.DynamicsConnections.Password;
            }
            else
            {
                soapUrl.Text = string.Empty;
                userName.Text = string.Empty; 
                password.Text = string.Empty;
            }
        }       
    }
}
