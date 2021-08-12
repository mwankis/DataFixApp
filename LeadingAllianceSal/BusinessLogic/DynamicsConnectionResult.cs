using Microsoft.Xrm.Sdk;

namespace BusinessLogic
{
    public class DynamicsConnectionResult
    {
        public string ErrorMessage { get; set; }

        public IOrganizationService OrganizationService { get; set; }
    }
}
