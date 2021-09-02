using MainApplication.Task3.Models.Api;
using Microsoft.Xrm.Sdk;
using System;
using System.ServiceModel;

namespace MainApplication.Task3.ApplicationLogic
{
    public static class Task3LegacyCode
    {
        public static string CreateCrmInvoice(IOrganizationService orgService, ApiInvoice row)
        {

            string invoiceNum = string.Empty;
            try
            {
                DateTime invoiceDate = DateTime.Parse(row.Date.ToString());
                DateTime invoicetime = DateTime.Parse(row.Time);
                invoiceNum = Convert.ToInt32(row.InvoiceNo).ToString();
                string loyaltyCardId = row.cust_cardid;
                string clientId = row.ClientId.ToString();
                decimal loyaltyPointsExchangeRate = decimal.Parse(row.VatUSD.ToString());

                var entity = new Entity("invoice");
                entity["new_invoicedate"] = new DateTime(invoiceDate.Year, invoiceDate.Month, invoiceDate.Day,
                    invoicetime.Hour, invoicetime.Minute, invoicetime.Second);

                entity["new_invoiceno"] = string.IsNullOrEmpty(invoiceNum) ? "" : invoiceNum;
                entity["new_salesman"] = string.IsNullOrEmpty(row.Salesman) ? "" : row.Salesman;
                entity["new_clientid"] = string.IsNullOrEmpty(clientId) ? "" : clientId;
                entity["new_popid"] = string.IsNullOrEmpty(loyaltyCardId) ? "" : loyaltyCardId;
                entity["new_giftvoucher"] = row.GiftVoucher;

                entity["new_promocode"] = string.IsNullOrEmpty(row.promotionCode) ? "" : row.promotionCode;

                //if (Promotion != null)
                //{
                //    entity["new_promoid"] = new EntityReference(Promotion.LogicalName, Promotion.Id);
                //}
                entity["new_extrapoints"] = (int)(row.ExtraPoints ?? 0);
                entity["new_points"] = (int)(row.PointsNbr ?? 0);
                entity["new_awardedpoints"] = ((row.PointsNbr ?? 0) + (row.ExtraPoints ?? 0));

                var invoiceId = orgService.Create(entity);
                return $"Succesfully created invoice with id: {invoiceId}"; 
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                return "Fialed to Updating Invoice with number=" + invoiceNum + ". Error: " + ex.Message; ;
            }
            catch (Exception ex)
            {
                return "Fialed to Updating Invoice with number=" + invoiceNum + ". Error: " + ex.Message;
            }

           
        }

        public static string UpdateCrmInvoice(IOrganizationService orgService, ApiInvoice row, Entity crmInvoice)
        {

            string invoiceNum = string.Empty;
            try
            {
                DateTime invoiceDate = DateTime.Parse(row.Date.ToString());
                DateTime invoicetime = DateTime.Parse(row.Time);
                invoiceNum = Convert.ToInt32(row.InvoiceNo).ToString();
                string loyaltyCardId = row.cust_cardid;
                string clientId = row.ClientId.ToString();

                crmInvoice["new_extrapoints"] = (int)(row.ExtraPoints ?? 0);
                crmInvoice["new_points"] = (int)(row.PointsNbr ?? 0);
                crmInvoice["new_awardedpoints"] = ((row.PointsNbr ?? 0) + (row.ExtraPoints ?? 0));
                orgService.Update(crmInvoice);
                return $"Succesfully updated invoice with id: {crmInvoice.Id}";
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                return "Fialed to Updating Invoice with number=" + invoiceNum + ". Error: " + ex.Message; ;
            }
            catch (Exception ex)
            {
                return "Fialed to Updating Invoice with number=" + invoiceNum + ". Error: "+ ex.Message;
            }
        }
    }
}
