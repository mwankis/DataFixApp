using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.ServiceModel.Description;

namespace BusinessLogic
{
    public static class OrganisationService
    {
        public static IOrganizationService GetCrmOrgService(
            string crmServerName ,
            string crmOrganizationName ,
            string userName ,
            string password )
        {
            try
            {
                

                ClientCredentials credentials = new ClientCredentials();
                credentials.UserName.UserName = userName;
                credentials.UserName.Password = password;
                var serviceUri = new Uri("http://" + crmServerName + "/" + crmOrganizationName + "/XRMServices/2011/Organization.svc");
                OrganizationServiceProxy proxy = new OrganizationServiceProxy(serviceUri, null, credentials, null);
                proxy.EnableProxyTypes();
                var crmService = (IOrganizationService)proxy;
                return crmService;
            }
            catch (Exception ex)
            {
                var errorMsg = ex.Message;
                return null;
            }
            
        }
    }
}
