using MainApplication.Helpers;
using MainApplication.Task4_MissingOpeningInvoices.Models.Api;
using System;
using System.Collections.Generic;

namespace MainApplication.Task4_MissingOpeningInvoices.BusinessLogic
{
    public static class ApiPointsLogic
    {
        public static ApiPointsResponse GetApiPoints(DateTime dateFrom, DateTime dateTo)
        {
            var apiPointsResponse = new ApiPointsResponse();
            try
            {
                var apiResponse = CallApiUtil.GetApiRecords<List<ApiPoint>> (dateFrom, "GetPoints");
                if (string.IsNullOrEmpty(apiResponse.ErrorMessage))
                {
                    apiPointsResponse.ApiPoints = apiResponse.ResponseBody as List<ApiPoint>;
                }
                apiPointsResponse.ErrorMessage = apiResponse.ErrorMessage;
                return apiPointsResponse;
            }
            catch (Exception ex)
            {
                apiPointsResponse.ErrorMessage = $"Something went wrong fetching points. {ex.Message}";
                return apiPointsResponse;
            }
        }
    }
}
