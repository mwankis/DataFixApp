using Microsoft.Xrm.Sdk;
using System;
using System.Windows.Forms;

namespace MainApplication.Task5_ZeroAwardedPoints.Forms
{
    public partial class Task5_ZeroAwardedPointsForm : Form
    {
        private readonly IOrganizationService _organizationService;

        public Task5_ZeroAwardedPointsForm(IOrganizationService organizationService)
        {
            InitializeComponent();
            _organizationService = organizationService;
        }

        private void getDynamicsDataBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
