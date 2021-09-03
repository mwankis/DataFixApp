using BusinessLogic;
using MainApplication.Task4_MissingOpeningInvoices.Models.Api;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace MainApplication.Task4_MissingOpeningInvoices.BusinessLogic
{
    public static class CrmAdddeductLogic
    {

        public static string CreateAdddeduct(IOrganizationService organizationService,
           DateTime fromDate, DateTime toDate, ApiPoint apiPoint)
        {
            try
            {
                var getAdddeduct = GetAdddeduct(organizationService, fromDate, toDate, apiPoint);
                if (!string.IsNullOrEmpty(getAdddeduct.ErrorMessage))
                {
                    return $"Failed to fecth deduct for point: {apiPoint.ClientId}. Error :{getAdddeduct.ErrorMessage}";
                }

                if (getAdddeduct.EntityList.Count == 0)
                {
                   var createResult = CreateAddDeduct(organizationService, apiPoint);
                   return createResult;
                }
                return $"Adddeduct record exists. Client: {apiPoint.ClientId} | Date: {apiPoint.Reason}";
            }
            catch (Exception ex)
            {
                return $"Failed to create an adddeduct. Error message: {ex.Message}";
            }
        }

        private static string CreateAddDeduct(IOrganizationService organizationService, ApiPoint apiPoint)
        {
            try
            {
                var entity = new Entity("new_adddeduct");
                var adddeductId = organizationService.Create(entity);
                return $"Create Adddeduct with id: {adddeductId}. Points details => Client: {apiPoint.ClientId} | Date: {apiPoint.Reason} ";
            }
            catch (Exception ex)
            {
                return $"Failed to create Adddeduct. Points details => Client: {apiPoint.ClientId} | Date: {apiPoint.Reason}." +
                    $" Error: {ex.Message} ";
            }
        }

        public static OperationResult GetAdddeduct(IOrganizationService organizationService,
            DateTime fromDate, DateTime toDate, ApiPoint apiPoint)
        {
            var query = new QueryExpression("new_adddeduct")
            {

            };

            var getCrmRecords = DynamicsService.GetEntityCollection(organizationService, query);

            return getCrmRecords;
        }
    }
}
