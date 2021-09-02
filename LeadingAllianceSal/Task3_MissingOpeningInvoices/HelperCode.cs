using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_MissingOpeningInvoices
{
    public class HelperCode
    {
        public Guid CreateInvoice(Invoice row, decimal onCredit, decimal cash, decimal loyaltyPoints, decimal vatUsd, decimal discountUsd, out Guid contact,
          out Guid customercardid, IOrganizationService service, IEnumerable<LoyaltyTier> tiers, out LoyaltyTier tier,
          out bool cardType, SqlConnection con, string connectionstring, int reties, out bool found, Entity Promotion)
        {

            DateTime invoiceDate = DateTime.Parse(row.Date.ToString());
            DateTime invoicetime = DateTime.Parse(row.Time);
            string invoiceNum = Convert.ToInt32(row.InvoiceNo).ToString();
            string loyaltyCardId = row.cust_cardid;
            string clientId = row.ClientId.ToString();
            //  Entity Promotion = _syncManager.GetPromotionByDolphinId(row.PromoId);
            decimal loyaltyPointsExchangeRate = decimal.Parse(row.VatUSD.ToString());
            found = false;
            tier = null;
            contact = Guid.Empty;
            customercardid = Guid.Empty;
            cardType = false;
            var invoiceId = GetInvoiceId(invoiceNum, service, row.GiftVoucher);
            if (invoiceId != Guid.Empty)
            {
                found = true;
                return invoiceId;
            }
            try
            {
                var entity = new Entity("invoice");
                //_log.Info("$$$0");
                entity["new_invoicedate"] = new DateTime(invoiceDate.Year, invoiceDate.Month, invoiceDate.Day,
                    invoicetime.Hour, invoicetime.Minute, invoicetime.Second);
                //_log.Info("$$$1");

                entity["new_invoiceno"] = string.IsNullOrEmpty(invoiceNum) ? "" : invoiceNum;
                entity["new_salesman"] = string.IsNullOrEmpty(row.Salesman) ? "" : row.Salesman;
                //_log.Info("$$$2");
                entity["new_clientid"] = string.IsNullOrEmpty(clientId) ? "" : clientId;
                entity["new_popid"] = string.IsNullOrEmpty(loyaltyCardId) ? "" : loyaltyCardId;
                entity["new_giftvoucher"] = row.GiftVoucher;

                //11-05-2017 Promocode change
                entity["new_promocode"] = string.IsNullOrEmpty(row.promotionCode) ? "" : row.promotionCode;

                if (Promotion != null)
                {
                    entity["new_promoid"] = new EntityReference(Promotion.LogicalName, Promotion.Id);
                }
                entity["new_extrapoints"] = (int)(row.ExtraPoints ?? 0);
                entity["new_points"] = (int)(row.PointsNbr ?? 0);
                entity["new_awardedpoints"] = ((row.PointsNbr ?? 0) + (row.ExtraPoints ?? 0));




                if (clientId != "")
                {
                    string loyaltyTierId;
                    string promoCode;
                    GetContact(loyaltyCardId, out contact, out customercardid, out loyaltyTierId, out cardType, out promoCode, con,
                        connectionstring, reties);
                    if (contact != Guid.Empty && loyaltyTierId != "" && customercardid != Guid.Empty)
                    {
                        tier = tiers.FirstOrDefault(c => c.LoyaltyTierId.ToString() == loyaltyTierId);


                        entity["customerid"] = new EntityReference("contact", contact);
                        entity["new_customercardid"] = new EntityReference("new_customercard", customercardid);
                        if (loyaltyCardId.Contains("MB"))
                            entity["new_mobiletransaction"] = true;
                    }
                    else
                    {
                        _log.Info("No CARD  FOUND. CLIENTID=" + clientId);
                        return Guid.Empty;
                    }

                    //11-05-2017 Promocode change
                    if (contact != Guid.Empty && !string.IsNullOrEmpty(promoCode))
                    {
                        _log.Info("contact promo code: " + promoCode);
                        _log.Info("invoice promo code: " + row.promotionCode);
                        if (promoCode == row.promotionCode)
                        {
                            //set promo code as used on contact
                            try
                            {
                                var contactEntity = new Entity("contact");
                                contactEntity.Id = contact;
                                contactEntity["new_used"] = true;
                                service.Update(contactEntity);

                            }
                            catch (Exception ex)
                            {
                                _log.Error("Error setting promocode used on contact: " + contact + " - code: " + promoCode);
                                _log.Error(ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    _log.Info("client is null in invoice with id=" + invoiceNum);

                    return Guid.Empty;
                }
                // _log.Info("$$$6.5");

                var source = GetSource(row.POS, service);
                if (source != Guid.Empty)
                {
                    //_log.Info("$$$7");
                    entity["new_sourceid"] = new EntityReference("new_source", source);
                }
                //_log.Info("$$$8");

                entity["name"] = string.IsNullOrEmpty(invoiceNum) ? "" : invoiceNum;
                entity["pricelevelid"] = new EntityReference("pricelevel", new Guid(_lbpPriceListId));
                //_log.Info("$$$9");
                entity["new_totalvat"] = new Money(vatUsd);
                entity["discountamount"] = new Money(discountUsd);
                entity["new_cash"] = new Money(cash);
                //_log.Info("$$$10");
                entity["new_credit"] = new Money(onCredit);



                //if (loyaltyPointsExchangeRate != 0)
                //{
                //    //_log.Info("$$$12");

                //    entity["new_loyaltypoints"] = loyaltyPoints;
                //    entity["new_loyaltypointsexchangerate"] = new Money(loyaltyPointsExchangeRate);
                //}
                //if (cardType)
                //{
                //    //_log.Info("$$$11");


                //    //_log.Info("$$$11");

                //    //TD:MM
                //    if (loyaltyPointsExchangeRate != 0)
                //    {
                //        //_log.Info("$$$12");

                //        entity["new_loyaltypoints"] = loyaltyPoints;
                //        entity["new_loyaltypointsexchangerate"] = new Money(loyaltyPointsExchangeRate);
                //    }
                //}
                _log.Info("$$$13");
                return service.Create(entity);
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                _log.Error("Fialed to Create Invoice with number=" + invoiceNum);
                _log.Error(ex.Message);
                return Guid.Empty;
            }
            catch (Exception ex)
            {
                _log.Error("Fialed to Create Invoice with number=" + invoiceNum);
                _log.Error(ex.Message);
                return Guid.Empty;
            }
        }
    }
}
