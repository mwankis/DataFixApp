using System;
using System.Collections.Generic;

namespace MainApplication.Task5_ZeroAwardedPoints.Models
{
    public class ApiZeroPointsResponse
    {
        public string ErrorMessage { get; set; }

        public ApiPoints ApiPoint { get; set; }

        public List<ApiPoints> ApiPoints { get; set; } = new List<ApiPoints>();
    }

    public class ApiPoints
    {
        public decimal ClientId { get; set; }

        public decimal Points { get; set; }

        public string Reason { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
