using MainApplication.Helpers;
using MainApplication.Task5_ZeroAwardedPoints.Models;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;

namespace MainApplication.Task5_ZeroAwardedPoints.BusinessLogic
{
    public static class CallApiLogic
    {
        public static ApiZeroPointsResponse GetApiPoints(DateTime fromDate, DateTime toDate, Entity invoice)
        {
            var apiZeroPointsResponse = new ApiZeroPointsResponse();
            try
            {
                var apiResponse = CallApiUtil.GetApiRecords<List<ApiPoints>>(fromDate, "GetNewInvoices");
                if (string.IsNullOrEmpty(apiResponse.ErrorMessage))
                {
                    apiZeroPointsResponse.ApiPoints = apiResponse.ResponseBody as List<ApiPoints>;
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
