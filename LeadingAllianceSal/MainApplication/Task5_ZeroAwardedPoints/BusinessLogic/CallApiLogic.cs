using MainApplication.Helpers;
using MainApplication.Task5_ZeroAwardedPoints.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainApplication.Task5_ZeroAwardedPoints.BusinessLogic
{
    public static class CallApiLogic
    {
        public static ApiZeroPointsResponse GetApiPoints(DateTime fromDate, DateTime toDate)
        {
            var apiZeroPointsResponse = new ApiZeroPointsResponse();
            try
            {
                var apiResponse = CallApiUtil.GetApiRecords<List<ApiInvoice>>(fromDate, "GetNewInvoices");
                if (string.IsNullOrEmpty(apiResponse.ErrorMessage))
                {
                    var apiInvoices = apiResponse.ResponseBody as List<ApiInvoice>;
                    apiZeroPointsResponse.ApiInvoices = apiInvoices.Where(x => x.Date <= toDate).ToList();
                }
                apiZeroPointsResponse.ErrorMessage = apiResponse.ErrorMessage;
                return apiZeroPointsResponse;
            }
            catch (Exception ex)
            {
                apiZeroPointsResponse.ErrorMessage = $"Failed to get api points; Error :{ex.Message}";
                return apiZeroPointsResponse;
            }
        }
    }
}
