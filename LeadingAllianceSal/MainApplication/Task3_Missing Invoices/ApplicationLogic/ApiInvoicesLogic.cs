using MainApplication.Helpers;
using MainApplication.Task3.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainApplication.Task3.ApplicationLogic
{
    public static class ApiInvoicesLogic
    {
        public static ApiInvoiceResponse GetApiInvoices(DateTime dateFrom, DateTime toDate)
        {
            var apiResponse = new ApiInvoiceResponse();
            try
            {
                var apiInvoiceResponse = CallApiUtil.GetApiRecords<List<ApiInvoice>>(dateFrom, "GetNewInvoices");
                if (!string.IsNullOrEmpty(apiInvoiceResponse.ErrorMessage))
                {
                    apiResponse.ErrorMessage = $"Failed to fecth invoices from api. Error message: {apiInvoiceResponse.ErrorMessage}";
                    return apiResponse;
                }
                var allInvoices = apiInvoiceResponse.ResponseBody as List<ApiInvoice>;

                apiResponse.Invoices = allInvoices.Where(x => x.Date <= toDate).ToList();
                return apiResponse;
            }
            catch (Exception ex)
            {
                apiResponse.ErrorMessage = "Failed to fecth invoices from api. Error message: "+ ex.Message;
                return apiResponse;
            }

        }
               
    }
}
