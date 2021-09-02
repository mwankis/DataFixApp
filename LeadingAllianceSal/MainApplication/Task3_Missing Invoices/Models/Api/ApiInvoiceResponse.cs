using System;
using System.Collections.Generic;

namespace MainApplication.Task3.Models.Api
{
    public class ApiInvoiceResponse
    {
        public string ErrorMessage { get; set; }

        public List<ApiInvoice> Invoices { get; set; } = new List<ApiInvoice>();
    }


    public class ApiInvoice
    {
        public decimal? InvoiceNo { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int ClientId { get; set; }
        public string cust_cardid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salesman { get; set; }
        public decimal NetTotalUSD { get; set; }
        public decimal VatUSD { get; set; }
        public decimal TotalWithVatUSD { get; set; }
        public decimal DiscountUSD { get; set; }
        public string POS { get; set; }
        public decimal LoyaltyPoints { get; set; }
        public decimal LoyaltyPointsExchangeRate { get; set; }
        public decimal OnCredit { get; set; }
        public decimal Cash { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public decimal TotalDetail { get; set; }
        public string CustomerCategoryCode { get; set; }
        public string CustomerCategoryName { get; set; }
        public object SalesOrderReference { get; set; }
        public int? GiftVoucher { get; set; }
        public string promotionCode { get; set; }
        public decimal? PointsNbr { get; set; }
        public decimal? ExtraPoints { get; set; }

        public int? PromoIdOnHeader { get; set; }
    }
}
