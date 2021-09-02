using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace Task3_MissingOpeningInvoices.CrmModels
{
    public class CrmResponse
    {
        public List<Entity> Entities { get; set; } = new List<Entity>();

        public Entity Entity { get; set; }

        public string ErrorMessage { get; set; }

        public string OutputMessage { get; set; }

    }
}
