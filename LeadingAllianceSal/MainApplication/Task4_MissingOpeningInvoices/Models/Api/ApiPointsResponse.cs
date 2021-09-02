using System;
using System.Collections.Generic;

namespace MainApplication.Task4_MissingOpeningInvoices.Models.Api
{
    public class ApiPointsResponse
    {
        public string ErrorMessage { get; set; }

        public List<ApiPoint> ApiPoints { get; set; } = new List<ApiPoint>();
    }

    public class ApiPoint
    {
        public decimal ClientId { get; set; }

        public decimal Points { get; set; }

        public string Reason { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
