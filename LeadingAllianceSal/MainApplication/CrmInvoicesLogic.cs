//using BusinessLogic;
//using MainApplication.Task3.Models.Api;
//using MainApplication.Task3.Models.Crm;
//using Microsoft.Xrm.Sdk;
//using Microsoft.Xrm.Sdk.Query;
//using System;
//using System.Collections.Generic;

//namespace MainApplication.Task3.ApplicationLogic
//{
//    public static class CrmInvoicesLogic
//    {
//        public static string UpsertCrmInvoice(IOrganizationService orgService, ApiInvoice apiInvoice, Entity crmInvoice)
//        {
//            try
//            {
//                if (crmInvoice != null)
//                {
//                    var updateResponse = UpdateCrmInvoices(orgService, apiInvoice, crmInvoice);
//                    return updateResponse;
//                }
//                else
//                {
//                    var createdInvoiceResult = CreateCrmInvoices(orgService,  apiInvoice);
//                    return createdInvoiceResult;
//                }
//            }
//            catch (Exception ex)
//            {
//                return $"Something went wrong trying to upsert for invoice. Error message: {ex.Message}"; ;
//            }
//        }


//        public static string UpdateCrmInvoices(IOrganizationService orgService, ApiInvoice apiInvoice, Entity crmInvoice)
//        {
//            try
//            {
//                var updateCRmRecord = Task3LegacyCode.UpdateCrmInvoice(orgService, apiInvoice, crmInvoice);
//                return updateCRmRecord;
//            }
//            catch (Exception ex)
//            {
//                var errorMsg = $"Failed to update crm invoice with Id: {crmInvoice.Id}. Error Msg: {ex.Message}";
//                return errorMsg;
//            }
//        }


//        public static string CreateCrmInvoices(IOrganizationService orgService, ApiInvoice apiInvoice)
//        {
//            try
//            {
//                var createInvoice = Task3LegacyCode.CreateCrmInvoice(orgService, apiInvoice);
//                return createInvoice;
//            }
//            catch (Exception ex)
//            {
//                var errorMsg = $"Error Msg: {ex.Message}";
//                return errorMsg;
//            }

//        }


//        public static CrmResponse GetCrmInvoices(IOrganizationService orgService, DateTime fromDate, DateTime toDate)
//        {
//            var crmResponse = new CrmResponse();
//            try
//            {
//                var query = new QueryExpression()
//                {
//                    EntityName = "invoice",
//                    ColumnSet = new ColumnSet(true)                    
//                };
//                query.Criteria.AddCondition("createdon", ConditionOperator.OnOrAfter, fromDate);
//                query.Criteria.AddCondition("createdon", ConditionOperator.OnOrBefore, toDate);


//                var fetchRecordsResponse = DynamicsService.RetrieveAllRecords(orgService, query);
//                if (string.IsNullOrEmpty(fetchRecordsResponse.ErrorMessage))
//                {
//                    crmResponse.Entities = fetchRecordsResponse.EntityList;
//                    return crmResponse;
//                }
//                crmResponse.ErrorMessage = fetchRecordsResponse.ErrorMessage;
//                return crmResponse;

//            }
//            catch (Exception ex)
//            {
//                crmResponse.ErrorMessage = "Failed to fecth cr, entities. Error Message: " + ex.Message;
//                return crmResponse;
//            }          
            
//        }


//        public static CrmResponse GetCrmInvoice(List<Entity> entities, ApiInvoice apiInvoice)
//        {
//            var crmResponse = new CrmResponse();
//            string invoiceNo = string.Empty;
//            try
//            {
//                var invoiceInfo = GetApiInvoiceInfo(apiInvoice);
//                invoiceNo = invoiceInfo.Item1;
//                string giftVoucher = invoiceInfo.Item2;
//                foreach (var entity in entities)
//                {
//                    if (entity.Attributes.Keys.Contains("new_invoiceno") && entity.Attributes.Keys.Contains("new_giftvoucher"))
//                    {
//                        var invoiceNum = entity.GetAttributeValue<string>("new_invoiceno");
//                        var giftVoucherVal = entity.GetAttributeValue<string>("new_giftvoucher");
//                        if (invoiceNo.Equals(invoiceNum, StringComparison.CurrentCultureIgnoreCase)
//                            && giftVoucherVal.Equals(giftVoucher, StringComparison.CurrentCultureIgnoreCase))
//                        {
//                            crmResponse.Entity = entity;
//                            return crmResponse;
//                        }
//                    }
//                }
//                return crmResponse;
//            }
//            catch (Exception ex)
//            {
//                crmResponse.ErrorMessage = "Something went wrong fetching incoive with invoiceNumber: "+invoiceNo + " .ErrorMessage: "+ex.Message;
//                return crmResponse;
//            }
           
//        }


//        private static Tuple<string, string> GetApiInvoiceInfo(ApiInvoice apiInvoice)
//        {
//            return null;
//        }

//    }
//}
