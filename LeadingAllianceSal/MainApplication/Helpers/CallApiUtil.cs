using MainApplication.Configs.Models;
using MainApplication.Constants;
using MainApplication.Models;
using Newtonsoft.Json;
using System;
using System.Dynamic;
using System.IO;
using System.Net;

namespace MainApplication.Helpers
{
    public static class CallApiUtil
    {
        public static ApiResponse GetApiRecords<T>(DateTime dateFrom, string endPoint)
        {
            var apiResponse = new ApiResponse();
            try
            {
                var appsettingsFileName = ApplicationConstants.ApplicationSettingsFileName;
                var appSettings = ApplicationSettingsHelper.GetModelFromJsonFile<ApplicationSettings>(appsettingsFileName);

                var sdUrl = appSettings.Task3ApiDetails.SdURL;
                var sdUser = appSettings.Task3ApiDetails.SdUser;
                var sdPassowrd = appSettings.Task3ApiDetails.SdPassword;

                var updateRequest = (HttpWebRequest)HttpWebRequest.Create(sdUrl + endPoint);
                updateRequest.ContentType = "application/json; charset=utf-8";
                updateRequest.Accept = "application/json";
                updateRequest.Method = "Post";
                updateRequest.Headers.Add(sdUser, sdPassowrd);
                dynamic updateobjectToSend = new ExpandoObject();
                updateobjectToSend.UpdatedOn = dateFrom.ToString("MM/dd/yyyy"); // hh:mm tt"); //

                using (var writer = new StreamWriter(updateRequest.GetRequestStream()))
                {
                    writer.Write(JsonConvert.SerializeObject(updateobjectToSend));
                    writer.Flush();
                }
                WebResponse updateresponse = updateRequest.GetResponse();

                using (var res = new StreamReader(updateresponse.GetResponseStream()))
                {
                    string jsonResult = res.ReadToEnd();

                    var apiResponseBody = JsonConvert.DeserializeObject<T>(jsonResult);
                    apiResponse.ResponseBody = apiResponseBody;
                    return apiResponse;
                }
            }
            catch (Exception ex)
            {
                apiResponse.ErrorMessage = "Failed to fecth invoices from api. Error message: " + ex.Message;
                return apiResponse;
            }

        }
    }
}
