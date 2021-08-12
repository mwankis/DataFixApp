using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.ServiceModel.Description;

namespace BusinessLogic
{
    public static class ConnectToCRM
    {
        public static DynamicsConnectionResult ConnectToMSCRM(string UserName, string Password, string SoapOrgServiceUri)
        {

            // url : https://XYZORG.api.crm5.dynamics.com/XRMServices/2011/Organization.svc
            try
            {
                ClientCredentials credentials = new ClientCredentials();
                credentials.UserName.UserName = UserName;
                credentials.UserName.Password = Password;
                Uri serviceUri = new Uri(SoapOrgServiceUri);
                OrganizationServiceProxy proxy = new OrganizationServiceProxy(serviceUri, null, credentials, null);
                proxy.EnableProxyTypes();
                var service = (IOrganizationService)proxy;

                var organizationService = new DynamicsConnectionResult
                {
                    OrganizationService = service
                };

                return organizationService;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while connecting to CRM " + ex.Message);
                var organizationService = new DynamicsConnectionResult
                {
                    ErrorMessage = ex.Message
                };

                return organizationService;
            }
        }
    }
}

