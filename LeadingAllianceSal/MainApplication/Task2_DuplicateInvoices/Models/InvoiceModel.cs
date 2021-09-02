using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;

namespace MainApplication.Task2_DuplicateInvoices.Models
{

    public class InvoiceModel
    {
        public DictionaryKey DictionaryKey { get; set; }

        public List<Entity> EntityList { get; set; } = new List<Entity>();
    }

    //customer, customer card, invoice number, invoice date and created date
    public class DictionaryKey
    {
        public Guid Customer { get; set; }

        public Guid CustomerCard { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
