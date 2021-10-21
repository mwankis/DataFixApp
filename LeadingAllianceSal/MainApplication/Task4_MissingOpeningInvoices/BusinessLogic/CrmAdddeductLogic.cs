using BusinessLogic;
using MainApplication.Task4_MissingOpeningInvoices.Models.Api;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;

namespace MainApplication.Task4_MissingOpeningInvoices.BusinessLogic
{
    public static class CrmAdddeductLogic
    {

        public static string CreateAddDeduct(IOrganizationService organizationService, ApiPoint apiPoint)
        {
            try
            {
                var entity = new Entity("new_adddeduct");

                // add all fields here

                var adddeductId = organizationService.Create(entity);
                return $"Create Adddeduct with id: {adddeductId}. Points details => Client: {apiPoint.ClientId} | Date: {apiPoint.Reason} ";
            }
            catch (Exception ex)
            {
                return $"Failed to create Adddeduct. Points details => Client: {apiPoint.ClientId} | Date: {apiPoint.Reason}." +
                    $" Error: {ex.Message} ";
            }
        }

        public static OperationResult GetAdddeducts(IOrganizationService organizationService,
           DateTime fromDate, DateTime toDate)
        {
            // To Do check this query
            var query = new QueryExpression("new_adddeduct");
            query.Criteria.AddCondition("createdon", ConditionOperator.OnOrBefore, fromDate);
            query.Criteria.AddCondition("createdon", ConditionOperator.OnOrAfter, toDate);

            var getCrmRecords = DynamicsService.GetEntityCollection(organizationService, query);

            return getCrmRecords;
        }

        public static Entity GetAdddeduct(List<Entity> entityList, ApiPoint apiPoint)
        {
            foreach (var entity in entityList)
            {
                if (entity.Attributes.ContainsKey("new_reason"))
                {
                    var customerid = entity.GetAttributeValue<EntityReference>("new_customerid");
                    var reason = entity.GetAttributeValue<string>("new_reason");
                    var points = entity.GetAttributeValue<decimal>("new_points");
                    var date = entity.GetAttributeValue<DateTime>("new_date");
                    if (apiPoint.Reason.Equals(reason, StringComparison.CurrentCultureIgnoreCase)
                        && apiPoint.UpdatedOn.Date.Equals(date.Date)
                        && apiPoint.Points == points)
                    {
                        return entity;
                    }
                }
            }           
            
            return null;
        }
    }
}
