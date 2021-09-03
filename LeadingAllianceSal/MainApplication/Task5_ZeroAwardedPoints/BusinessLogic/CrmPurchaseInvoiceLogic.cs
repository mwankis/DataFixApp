using BusinessLogic;
using MainApplication.Task5_ZeroAwardedPoints.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;

namespace MainApplication.Task5_ZeroAwardedPoints.BusinessLogic
{
    public static class CrmPurchaseInvoiceLogic
    {
        public static OperationResult GetCrmPurchaseInvoice(IOrganizationService organizationService,
            DateTime fromDate, DateTime toDate)
        {
            var query = new QueryExpression("invoice");
            query.ColumnSet.AddColumns("new_awardedpoints", "createdon", "new_invoiceno", "new_clientid", "new_invoicedate");
            query.Criteria.AddCondition("new_awardedpoints", ConditionOperator.Equal, 0);

            //Qu MW which field should be used to filter here. new_invoicedate???
            query.Criteria.AddCondition("createdon", ConditionOperator.OnOrAfter, fromDate);
            query.Criteria.AddCondition("createdon", ConditionOperator.OnOrBefore, toDate);

            var purchaseInvoices = DynamicsService.RetrieveAllRecords(organizationService, query);
            return purchaseInvoices;
        }

        public static string UpdatePurchaseInvoice(IOrganizationService organizationService,
          Entity entity, ApiInvoice apiInvoice)
        {
            try
            {
                var updateEntity = new Entity(entity.LogicalName)
                {
                    Id = entity.Id
                };
                // QA- from previous code=> is this correct calculation for to get the awardedpoints
                //entity["new_extrapoints"] = (int)(row.ExtraPoints ?? 0);
                //entity["new_points"] = (int)(row.PointsNbr ?? 0);
                updateEntity["new_awardedpoints"] = ((apiInvoice.PointsNbr ?? 0) + (apiInvoice.ExtraPoints ?? 0));
                organizationService.Update(updateEntity);
                return $"Invoice with id {entity.Id} updated successfully";
            }
            catch (Exception ex)
            {
                return $"Failed to update invoice with id: {entity.Id}. Error message: {ex.Message}";
            }          
           
        }

        public static ApiInvoice GetApiInvoice(List<ApiInvoice> ApiInvoices, Entity invoice)
        {
            //QU confirm data types on new_clientid
            var invoiceNo = invoice.GetAttributeValue<string>("new_invoiceno");
            var clientId = invoice.GetAttributeValue<string>("new_clientid");
            var invoiceDate = invoice.GetAttributeValue<DateTime>("new_invoicedate");
            var apiInvoice = ApiInvoices.Find(x => 
            x.InvoiceNo.Equals(invoiceNo)
            && x.ClientId.Equals(clientId)
            && x.Date.Date.Equals(invoiceDate.Date));
            return apiInvoice;
        }

    }
}
