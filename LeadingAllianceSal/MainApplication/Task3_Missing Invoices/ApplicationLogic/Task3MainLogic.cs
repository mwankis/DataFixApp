using MainApplication.Task3.Models.Api;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainApplication.Task3.ApplicationLogic
{
    public static class Task3MainLogic
    {
        public static void SynchronizeInvoices(IOrganizationService orgService,
           TabControl applicationTabs,
           ListBox errorList,
           List<Entity> crmInvoices,
           List<ApiInvoice> apiInvoices)
        {
            try
            {
                int processingCount = 0;
                foreach (var apiInvoice in apiInvoices)
                {
                    processingCount++;
                    var getCrmInvoiceResponse = CrmInvoicesLogic.GetCrmInvoice(crmInvoices, apiInvoice);
                    if (string.IsNullOrEmpty(getCrmInvoiceResponse.ErrorMessage))
                    {
                        var crmInvoice = getCrmInvoiceResponse.Entity;
                        if (crmInvoice == null)
                        {
                            var upsertInvoiceResult = CrmInvoicesLogic.CreateInvoice(orgService, apiInvoice);
                            if (string.IsNullOrEmpty(getCrmInvoiceResponse.ErrorMessage))
                            {
                                errorList.Items.Add($"Processing record: {processingCount}/{apiInvoices.Count}. {upsertInvoiceResult}");
                                applicationTabs.SelectedIndex = 2;
                                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");

                            }

                        }
                        else
                        {
                            errorList.Items.Add($"Processing record: {processingCount}/{apiInvoices.Count}. " +
                                $"No action required invoice: { apiInvoice.InvoiceNo} already exists");
                            applicationTabs.SelectedIndex = 2;
                            errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
                        }


                    }
                    else
                    {
                        errorList.Items.Add(getCrmInvoiceResponse.ErrorMessage);
                        applicationTabs.SelectedIndex = 2;
                        errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");

                    }

                }
            }
            catch (Exception ex)
            {
                errorList.Items.Add($"Something went wrong while synchronizing invoices. Error msg: {ex.Message}");
                applicationTabs.SelectedIndex = 2;
                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
            }

        }
    }
}
