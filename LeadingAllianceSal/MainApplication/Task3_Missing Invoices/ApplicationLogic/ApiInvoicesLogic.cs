using MainApplication.Configs.Models;
using MainApplication.Constants;
using MainApplication.Helpers;
using MainApplication.Task3.Models.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;

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

        public static ApiInvoiceResponse GetApiInvoicesCopy(DateTime dateFrom, DateTime toDate)
        {
            var apiResponse = new ApiInvoiceResponse();
            try
            {
                var appsettingsFileName = ApplicationConstants.ApplicationSettingsFileName;
                var appSettings = ApplicationSettingsHelper.GetModelFromJsonFile<ApplicationSettings>(appsettingsFileName);

                var sdUrl = appSettings.Task3ApiDetails.SdURL;
                var sdUser = appSettings.Task3ApiDetails.SdUser;
                var sdPassowrd = appSettings.Task3ApiDetails.SdPassword;

                var updateRequest = (HttpWebRequest)HttpWebRequest.Create(sdUrl + "GetNewInvoices");
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

                    var newInvoices = JsonConvert.DeserializeObject<List<ApiInvoice>>(jsonResult);
                    newInvoices = newInvoices.Where(x => x.Date <= toDate).ToList();
                    apiResponse.Invoices = newInvoices;
                    return apiResponse;
                }
            }
            catch (Exception ex)
            {
                apiResponse.ErrorMessage = "Failed to fecth invoices from api. Error message: " + ex.Message;
                return apiResponse;
            }

        }

        //public static Guid CreateInvoice(Invoice row, decimal onCredit, decimal cash, decimal loyaltyPoints, decimal vatUsd, decimal discountUsd, out Guid contact,
        //   out Guid customercardid, IOrganizationService service, IEnumerable<LoyaltyTier> tiers, out LoyaltyTier tier,
        //   out bool cardType, SqlConnection con, string connectionstring, int reties, out bool found, Entity Promotion)
        //{

        //    DateTime invoiceDate = DateTime.Parse(row.Date.ToString());
        //    DateTime invoicetime = DateTime.Parse(row.Time);
        //    string invoiceNum = Convert.ToInt32(row.InvoiceNo).ToString();
        //    string loyaltyCardId = row.cust_cardid;
        //    string clientId = row.ClientId.ToString();
        //    //  Entity Promotion = _syncManager.GetPromotionByDolphinId(row.PromoId);
        //    decimal loyaltyPointsExchangeRate = decimal.Parse(row.VatUSD.ToString());
        //    found = false;
        //    tier = null;
        //    contact = Guid.Empty;
        //    customercardid = Guid.Empty;
        //    cardType = false;

        //    // MW checking if it is found or not
        //    var invoiceId = GetInvoiceId(invoiceNum, service, row.GiftVoucher);
        //    if (invoiceId != Guid.Empty)
        //    {
        //        found = true;
        //        return invoiceId;
        //    }
        //    try
        //    {
        //        var entity = new Entity("invoice");
        //        //_log.Info("$$$0");
        //        entity["new_invoicedate"] = new DateTime(invoiceDate.Year, invoiceDate.Month, invoiceDate.Day,
        //            invoicetime.Hour, invoicetime.Minute, invoicetime.Second);
        //        //_log.Info("$$$1");

        //        entity["new_invoiceno"] = string.IsNullOrEmpty(invoiceNum) ? "" : invoiceNum;
        //        entity["new_salesman"] = string.IsNullOrEmpty(row.Salesman) ? "" : row.Salesman;
        //        //_log.Info("$$$2");
        //        entity["new_clientid"] = string.IsNullOrEmpty(clientId) ? "" : clientId;
        //        entity["new_popid"] = string.IsNullOrEmpty(loyaltyCardId) ? "" : loyaltyCardId;
        //        entity["new_giftvoucher"] = row.GiftVoucher;

        //        //11-05-2017 Promocode change
        //        entity["new_promocode"] = string.IsNullOrEmpty(row.promotionCode) ? "" : row.promotionCode;

        //        if (Promotion != null)
        //        {
        //            entity["new_promoid"] = new EntityReference(Promotion.LogicalName, Promotion.Id);
        //        }
        //        entity["new_extrapoints"] = (int)(row.ExtraPoints ?? 0);
        //        entity["new_points"] = (int)(row.PointsNbr ?? 0);
        //        entity["new_awardedpoints"] = ((row.PointsNbr ?? 0) + (row.ExtraPoints ?? 0));




        //        if (clientId != "")
        //        {
        //            string loyaltyTierId;
        //            string promoCode;
        //            GetContact(loyaltyCardId, out contact, out customercardid, out loyaltyTierId, out cardType, out promoCode, con,
        //                connectionstring, reties);
        //            if (contact != Guid.Empty && loyaltyTierId != "" && customercardid != Guid.Empty)
        //            {
        //                tier = tiers.FirstOrDefault(c => c.LoyaltyTierId.ToString() == loyaltyTierId);


        //                entity["customerid"] = new EntityReference("contact", contact);
        //                entity["new_customercardid"] = new EntityReference("new_customercard", customercardid);
        //                if (loyaltyCardId.Contains("MB"))
        //                    entity["new_mobiletransaction"] = true;
        //            }
        //            else
        //            {
        //                _log.Info("No CARD  FOUND. CLIENTID=" + clientId);
        //                return Guid.Empty;
        //            }

        //            //11-05-2017 Promocode change
        //            if (contact != Guid.Empty && !string.IsNullOrEmpty(promoCode))
        //            {
        //                _log.Info("contact promo code: " + promoCode);
        //                _log.Info("invoice promo code: " + row.promotionCode);
        //                if (promoCode == row.promotionCode)
        //                {
        //                    //set promo code as used on contact
        //                    try
        //                    {
        //                        _log.Info("updating contact");
        //                        var contactEntity = new Entity("contact");
        //                        contactEntity.Id = contact;
        //                        contactEntity["new_used"] = true;
        //                        service.Update(contactEntity);

        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        _log.Error("Error setting promocode used on contact: " + contact + " - code: " + promoCode);
        //                        _log.Error(ex.Message);
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            _log.Info("client is null in invoice with id=" + invoiceNum);

        //            return Guid.Empty;
        //        }
        //        // _log.Info("$$$6.5");

        //        var source = GetSource(row.POS, service);
        //        if (source != Guid.Empty)
        //        {
        //            //_log.Info("$$$7");
        //            entity["new_sourceid"] = new EntityReference("new_source", source);
        //        }
        //        //_log.Info("$$$8");

        //        entity["name"] = string.IsNullOrEmpty(invoiceNum) ? "" : invoiceNum;
        //        entity["pricelevelid"] = new EntityReference("pricelevel", new Guid(_lbpPriceListId));
        //        //_log.Info("$$$9");
        //        entity["new_totalvat"] = new Money(vatUsd);
        //        entity["discountamount"] = new Money(discountUsd);
        //        entity["new_cash"] = new Money(cash);
        //        //_log.Info("$$$10");
        //        entity["new_credit"] = new Money(onCredit);



        //        //if (loyaltyPointsExchangeRate != 0)
        //        //{
        //        //    //_log.Info("$$$12");

        //        //    entity["new_loyaltypoints"] = loyaltyPoints;
        //        //    entity["new_loyaltypointsexchangerate"] = new Money(loyaltyPointsExchangeRate);
        //        //}
        //        //if (cardType)
        //        //{
        //        //    //_log.Info("$$$11");


        //        //    //_log.Info("$$$11");

        //        //    //TD:MM
        //        //    if (loyaltyPointsExchangeRate != 0)
        //        //    {
        //        //        //_log.Info("$$$12");

        //        //        entity["new_loyaltypoints"] = loyaltyPoints;
        //        //        entity["new_loyaltypointsexchangerate"] = new Money(loyaltyPointsExchangeRate);
        //        //    }
        //        //}
        //        _log.Info("$$$13");
        //        return service.Create(entity);
        //    }
        //    catch (FaultException<OrganizationServiceFault> ex)
        //    {
        //        _log.Error("Fialed to Create Invoice with number=" + invoiceNum);
        //        _log.Error(ex.Message);
        //        return Guid.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.Error("Fialed to Create Invoice with number=" + invoiceNum);
        //        _log.Error(ex.Message);
        //        return Guid.Empty;
        //    }
        //}


        ////private static Guid GetInvoiceId(string invoiceNo, IOrganizationService service, int giftVoucher)
        ////{
        ////    var query = new QueryExpression("invoice");
        ////    query.Criteria.AddCondition("new_invoiceno", ConditionOperator.Equal, invoiceNo);
        ////    query.Criteria.AddCondition("new_giftvoucher", ConditionOperator.Equal, giftVoucher);

        ////    var entitys = service.RetrieveMultiple(query);
        ////    if (entitys.Entities.Count > 0)
        ////    {
        ////        return entitys.Entities[0].Id;
        ////    }
        ////    return Guid.Empty;
        ////}

        //public static Guid UpdateInvoice(Invoice row, decimal onCredit, decimal cash, decimal loyaltyPoints, decimal vatUsd, decimal discountUsd, out Guid contact,
        //   out Guid customercardid, IOrganizationService service, IEnumerable<LoyaltyTier> tiers, out LoyaltyTier tier,
        //   out bool cardType, SqlConnection con, string connectionstring, int reties, out bool found, Entity Promotion)
        //{

        //    DateTime invoiceDate = DateTime.Parse(row.Date.ToString());
        //    DateTime invoicetime = DateTime.Parse(row.Time);
        //    string invoiceNum = Convert.ToInt32(row.InvoiceNo).ToString();
        //    string loyaltyCardId = row.cust_cardid;
        //    string clientId = row.ClientId.ToString();
        //    //  Entity Promotion = _syncManager.GetPromotionByDolphinId(row.PromoId);
        //    decimal loyaltyPointsExchangeRate = decimal.Parse(row.VatUSD.ToString());
        //    found = false;
        //    tier = null;
        //    contact = Guid.Empty;
        //    customercardid = Guid.Empty;
        //    cardType = false;
        //    var entity = GetInvoice(invoiceNum, service, row.GiftVoucher);
        //    if (entity == null)
        //    {
        //        return Guid.Empty;
        //    }
        //    try
        //    {
        //        _log.Info("Updating Invoice with number=" + invoiceNum);

        //        //11-05-2017 Promocode change
        //        //entity["new_promocode"] = string.IsNullOrEmpty(row.promotionCode) ? "" : row.promotionCode;

        //        //if (Promotion != null)
        //        //{
        //        //    entity["new_promoid"] = new EntityReference(Promotion.LogicalName, Promotion.Id);
        //        //}
        //        entity["new_extrapoints"] = (int)(row.ExtraPoints ?? 0);
        //        entity["new_points"] = (int)(row.PointsNbr ?? 0);
        //        entity["new_awardedpoints"] = ((row.PointsNbr ?? 0) + (row.ExtraPoints ?? 0));


        //        service.Update(entity);
        //        return entity.Id;
        //    }
        //    catch (FaultException<OrganizationServiceFault> ex)
        //    {
        //        _log.Error("Fialed to Updating Invoice with number=" + invoiceNum);
        //        _log.Error(ex.Message);
        //        return Guid.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.Error("Fialed to Updating Invoice with number=" + invoiceNum);
        //        _log.Error(ex.Message);
        //        return Guid.Empty;
        //    }
        //}
    }
}
