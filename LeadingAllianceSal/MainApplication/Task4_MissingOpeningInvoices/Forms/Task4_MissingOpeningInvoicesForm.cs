using Microsoft.Xrm.Sdk;
using System;
using System.Windows.Forms;

namespace MainApplication.Task4_MissingOpeningInvoices.Forms
{
    public partial class Task4_MissingOpeningInvoicesForm : Form
    {
        private readonly IOrganizationService _organizationService;

        public Task4_MissingOpeningInvoicesForm(IOrganizationService organizationService)
        {
            InitializeComponent();
            _organizationService = organizationService;
        }

        private void callApiBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
