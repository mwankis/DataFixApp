using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace MainApplication.Task1.Models
{
    public class UpgradeModel
    {
        public DictionaryKey DictionaryKey { get; set; }

        public List<Entity> EntityList { get; set; } = new List<Entity>();
    }
}
