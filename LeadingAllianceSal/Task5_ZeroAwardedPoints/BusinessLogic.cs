using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Task5_ZeroAwardedPoints
{
    public static class BusinessLogic
    {
        public static List<UpdatedInvoice> getUpdatedInvoice(DateTime fromDate)
        {

            var updateRequest = (HttpWebRequest)HttpWebRequest.Create(_serviceURL + "GetInvoiceUpdatedPoints");
            updateRequest.ContentType = "application/json; charset=utf-8";
            updateRequest.Accept = "application/json";
            updateRequest.Method = "Post";
            updateRequest.Headers.Add(_userName, _password);
            dynamic updateobjectToSend = new ExpandoObject();
            updateobjectToSend.UpdatedOn = fromDate.ToString();
            updateobjectToSend.CustomerID = 0;

            using (var writer = new StreamWriter(updateRequest.GetRequestStream()))
            {
                writer.Write(JsonConvert.SerializeObject(updateobjectToSend));
                writer.Flush();
            }

            WebResponse updateresponse = updateRequest.GetResponse();
            List<UpdatedInvoice> lstUpdatedInvoiceModel;
            using (var res = new StreamReader(updateresponse.GetResponseStream()))
            {
                string resultJson = res.ReadToEnd();
                Log.logger.logResponse(resultJson);
                lstUpdatedInvoiceModel = JsonConvert.DeserializeObject<List<UpdatedInvoice>>(resultJson);
            }
            return lstUpdatedInvoiceModel;
        }

        public List<PointsModel> getPoints(DateTime fromDate)
        {
            int retry = 0;

            try
            {
                var updateRequest = (HttpWebRequest)HttpWebRequest.Create(_serviceURL + "GetPoints");
                updateRequest.ContentType = "application/json; charset=utf-8";
                updateRequest.Accept = "application/json";
                updateRequest.Method = "Post";
                updateRequest.Headers.Add(_userName, _password);
                dynamic updateobjectToSend = new ExpandoObject();
                updateobjectToSend.UpdatedOn = fromDate.ToString();

                using (var writer = new StreamWriter(updateRequest.GetRequestStream()))
                {
                    writer.Write(JsonConvert.SerializeObject(updateobjectToSend));
                    writer.Flush();
                }

                WebResponse updateresponse = updateRequest.GetResponse();
                List<PointsModel> lstPointsModel;
                using (var res = new StreamReader(updateresponse.GetResponseStream()))
                {
                    string resultJson = res.ReadToEnd();
                    lstPointsModel = JsonConvert.DeserializeObject<List<PointsModel>>(resultJson);
                }
                retry = 3;
                return lstPointsModel;
            }
            catch (Exception)
            {
                retry++;
                if (retry >= 3)
                    throw;
            }

            return null;
        }

    }
}

