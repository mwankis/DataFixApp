using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class OperationResult
    {
        public bool Succeded { get; set; } = true;

        public List<Entity> EntityList { get; set; } = new List<Entity>();

        public Entity Entity { get; set; }

        public string ErrorMessage { get; set; }
    }
}
