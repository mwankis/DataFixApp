using Microsoft.Xrm.Sdk;
using System;

namespace Task1_DuplicateUpgrades
{
    public class DictionaryKey
    {
        public Guid Customer { get; set; }

        public Guid Card { get; set; }

        public DateTime DateTime { get; set; }
    }
}
