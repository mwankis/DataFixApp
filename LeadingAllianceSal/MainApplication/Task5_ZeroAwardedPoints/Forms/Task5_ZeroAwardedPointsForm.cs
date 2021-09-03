using MainApplication.Task5_ZeroAwardedPoints.BusinessLogic;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainApplication.Task5_ZeroAwardedPoints.Forms
{
    public partial class Task5_ZeroAwardedPointsForm : Form
    {
        private readonly IOrganizationService _organizationService;

        private List<Entity> _crmInvoices;

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
            
        }

        private void updateCrmInvoicesBtn_Click(object sender, EventArgs e)
        {
            if (_crmInvoices.Count == 0)
            {
                MessageBox.Show("There are no crm invoices click get crm invoices first");
            }
            var fromDate = dateTimeFrom.Value;
            var toDate = dateTo.Value;
            foreach (var entity in _crmInvoices)
            {
                var invoicesResponse = CallApiLogic.GetApiPoints(fromDate, toDate, entity);
                if (invoicesResponse.ApiPoint == null)
                {
                    CrmPurchaseInvoiceLogic.UpdatePurchaseInvoice(_organizationService, entity, invoicesResponse.ApiPoint);
                }

            }
        }
    }
}
