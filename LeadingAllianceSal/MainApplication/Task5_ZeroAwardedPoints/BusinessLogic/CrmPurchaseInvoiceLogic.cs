using BusinessLogic;
using MainApplication.Task5_ZeroAwardedPoints.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace MainApplication.Task5_ZeroAwardedPoints.BusinessLogic
{
    public static class CrmPurchaseInvoiceLogic
    {
        public static OperationResult GetCrmPurchaseInvoice(IOrganizationService organizationService,
            DateTime fromDate, DateTime toDate)
        {
            var query = new QueryExpression();
            var purchaseInvoices = DynamicsService.RetrieveAllRecords(organizationService, query);
            return purchaseInvoices;
        }

        public static string UpdatePurchaseInvoice(IOrganizationService organizationService,
          Entity entity, ApiPoints apiPoint)
        {
            try
            {
                var updateEntity = new Entity(entity.LogicalName)
                {
                    Id = entity.Id
                };
                organizationService.Update(updateEntity);
                return $"Invoice with id {entity.Id} updated successfully";
            }
            catch (Exception ex)
            {
                return $"Failed to update invoice with id: {entity.Id}. Error message: {ex.Message}";
            }
          
           
        }

    }
}
