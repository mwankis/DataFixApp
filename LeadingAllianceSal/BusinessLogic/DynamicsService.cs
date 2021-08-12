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
        public static string TestConnection(IOrganizationService orgService)
        {
            if (orgService != null)
            {
                Guid userid = ((WhoAmIResponse)orgService.Execute(new WhoAmIRequest())).UserId;
                var user = orgService.Retrieve("systemuser", userid, new ColumnSet(true));
                if (user.KeyAttributes.Contains("fullname"))
                {
                    return user["fullname"].ToString();
                }
            }
          
            return string.Empty;
        }

        public static List<Entity> GetEntityCollection(IOrganizationService orgService, QueryExpression query)
        {
            try
            {
                var entityCollection = orgService.RetrieveMultiple(query);
                return entityCollection.Entities.ToList();
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                ////_log.Info("******27");
                throw;
            }
            catch (Exception)
            {

                throw;
            }
            
        }        

        public static List<Entity> RetrieveAllRecords(IOrganizationService service, QueryExpression query)
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
                resp = service.RetrieveMultiple(query);
                if (resp.MoreRecords)
                {
                    pageNumber++;
                    pagingCookie = resp.PagingCookie;
                }
                //Add the result from RetrieveMultiple to the List to be returned.
                result.AddRange(resp.Entities);
            }
            while (resp.MoreRecords);

            return result;
        }

        public static Entity GetEntity(IOrganizationService orgService, string entityName, Guid id, string [] columns )
        {
            try
            {
                var entity = orgService.Retrieve(entityName, id, new ColumnSet(columns));
                return entity;
            }

            catch (FaultException<OrganizationServiceFault> ex)
            {
                ////_log.Info("******27");
                throw;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public static bool GetEntity(IOrganizationService orgService, Entity entity)
        {
            try
            {
                orgService.Update(entity);
                return true;
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                ////_log.Info("******27");
                throw;
            }
            catch (Exception ex)
            {
                return true;
            }            
        }

        public static bool DeactivateEntity(IOrganizationService orgService, Entity entity, int state, int status)
        {
            try
            {
                var req = new SetStateRequest
                {
                    EntityMoniker = entity.ToEntityReference(),
                    State = new OptionSetValue(state),
                    Status = new OptionSetValue(status)
                 };
               
                orgService.Update(entity);
                return true;
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                ////_log.Info("******27");
                throw;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
    }
}
