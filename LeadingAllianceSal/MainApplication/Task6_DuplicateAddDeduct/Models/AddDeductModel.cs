using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace MainApplication.Task6_DuplicateAddDeduct.Models
{
    public class AddDeductModel
    {
        public DictionaryKey DictionaryKey { get; set; }

        public List<Entity> EntityList { get; set; } = new List<Entity>();
    }
}
