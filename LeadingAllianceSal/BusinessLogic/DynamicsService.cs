using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace BusinessLogic
{
    public static class DynamicsService
    {
        
        public static OperationResult GetEntityCollection(IOrganizationService orgService, QueryExpression query)
        {
            var response = new OperationResult();
            if (orgService == null)
            {
                response.Succeded = false;
                response.ErrorMessage = "No crm connection please navigate to Connect To CRM tab, enter all required fields " +
                    "and click test connection";
                return response;
            }
            try
            {
                var entityCollection = orgService.RetrieveMultiple(query);
                response.EntityList = entityCollection.Entities.ToList();
                return response;
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                response.Succeded = false;
                response.ErrorMessage = "Something went wrong. " + ex.Message;
                return response;
            }
            catch (Exception ex)
            {
                response.Succeded = false;
                response.ErrorMessage = "Something went wrong. " + ex.Message;
                return response;
            }
            
        }        

        public static OperationResult RetrieveAllRecords(IOrganizationService orgService, QueryExpression query)
        {
            var response = new OperationResult();

            if (orgService == null)
            {
                response.Succeded = false;
                response.ErrorMessage = "No crm connection please navigate to Connect To CRM tab, enter all required fields " +
                    "and click test connection";
                return response;
            }

            try
            {
                var pageNumber = 1;
                var pagingCookie = string.Empty;
                var result = new List<Entity>();
                EntityCollection resp;
                do
                {
                    if (pageNumber != 1)
                    {
                        query.PageInfo.PageNumber = pageNumber;
                        query.PageInfo.PagingCookie = pagingCookie;
                    }
                    resp = orgService.RetrieveMultiple(query);
                    if (resp.MoreRecords)
                    {
                        pageNumber++;
                        pagingCookie = resp.PagingCookie;
                    }
                    result.AddRange(resp.Entities);
                }
                while (resp.MoreRecords);

                response.EntityList = result;
                return response;
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                response.Succeded = false;
                response.ErrorMessage = "Something went wrong. " + ex.Message;
                return response;
            }
            catch (Exception ex)
            {
                response.Succeded = false;
                response.ErrorMessage = "Something went wrong. " + ex.Message;
                return response;
            }

        }

        public static OperationResult GetEntity(IOrganizationService orgService, string entityName, Guid id, string [] columns )
        {
            var response = new OperationResult();
            if (orgService == null)
            {
                response.Succeded = false;
                response.ErrorMessage = "No crm connection please navigate to Connect To CRM tab, enter all required fields " +
                    "and click test connection";
                return response;
            }
            try
            {
                var entity = orgService.Retrieve(entityName, id, new ColumnSet(columns));
                response.Entity = entity;
                return response;
            }

            catch (FaultException<OrganizationServiceFault> ex)
            {
                response.Succeded = false;
                response.ErrorMessage = "Something went wrong. " + ex.Message;
                return response;
            }
            catch (Exception ex)
            {
                response.Succeded = false;
                response.ErrorMessage = "Something went wrong. " + ex.Message;
                return response;
            }
           
        }

        public static OperationResult UpdateEntity(IOrganizationService orgService, Entity entity)
        {
            var response = new OperationResult();
            if (orgService == null)
            {
                response.Succeded = false;
                response.ErrorMessage = "No crm connection please navigate to Connect To CRM tab, enter all required fields " +
                    "and click test connection";
                return response;
            }
            try
            {
                orgService.Update(entity);
                return response;
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                response.Succeded = false;
                response.ErrorMessage = "Something went wrong. " + ex.Message;
                return response;
            }
            catch (Exception ex)
            {
                response.Succeded = false;
                response.ErrorMessage = "Something went wrong. " + ex.Message;
                return response;
            }            
        }

        public static OperationResult DeactivateEntity(IOrganizationService orgService, Entity entity, int state, int status)
        {
            var response = new OperationResult();
            if (orgService == null)
            {
                response.Succeded = false;
                response.ErrorMessage = "No crm connection please navigate to Connect To CRM tab, enter all required fields " +
                    "and click test connection";
                return response;
            }

            try
            {
                var req = new SetStateRequest
                {
                    EntityMoniker = entity.ToEntityReference(),
                    State = new OptionSetValue(state),
                    Status = new OptionSetValue(status)
                 };
               
                orgService.Update(entity);
                return response;
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                response.Succeded = false;
                response.ErrorMessage = "Something went wrong. " + ex.Message;
                return response;
            }
            catch (Exception ex)
            {
                response.Succeded = false;
                response.ErrorMessage = "Something went wrong. " + ex.Message;
                return response;
            }
        }
    }
}
