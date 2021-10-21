using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;

namespace Task3_MissingOpeningInvoices.ApplicationLogic
{
    public static class ApplicationLogic
    {
        public static List<string> UpSertInvoices(IOrganizationService orgService, DateTime fromDate, DateTime toDate)
        {
            var outcomeMessages = new List<string>();


            var apiInvoicesResponse = ApiInvoicesLogic.GetApiInvoices(fromDate);
            if (string.IsNullOrEmpty(apiInvoicesResponse.ErrorMessage))
            {
                var crmInvoicesResponse = CrmInvoicesLogic.GetCrmInvoices(orgService, fromDate, toDate);
                foreach (var apiInvoice in apiInvoicesResponse.Invoices)
                {
                    var crmInvoiceResponse = CrmInvoicesLogic.GetCrmInvoice(crmInvoicesResponse.Entities, apiInvoice);
                    var upsertInvoiceResponse = CrmInvoicesLogic.UpsertCrmInvoice(orgService, apiInvoice, crmInvoiceResponse.Entity);
                    outcomeMessages.Add(upsertInvoiceResponse);
                }
            }
            else
            {
                outcomeMessages.Add(apiInvoicesResponse.ErrorMessage);
            }

            return outcomeMessages;

        }
    }
}
