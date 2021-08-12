using BusinessLogic;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Task1_DuplicateUpgrades
{
    public partial class Form1 : Form
    {
        private Dictionary<DictionaryKey, List<Entity>> _dataRecords; 

        private IOrganizationService _organizationService;

        public Form1()
        {
            InitializeComponent();
        }       

        private void fetchBtn_Click(object sender, EventArgs e)
        {
            _dataRecords = new Dictionary<DictionaryKey, List<Entity>>();
            var dateFrom = dateTimeFrom.Value;

            // Instantiate QueryExpression query
            var query = new QueryExpression("account");

            // Add columns to query.ColumnSet
            query.ColumnSet.AddColumns("name", "primarycontactid", "telephone1", "accountid");
            query.AddOrder("new_customerid", OrderType.Ascending);
            query.AddOrder("new_Date", OrderType.Ascending);
            if (dateFrom != null)
            {
              query.Criteria.AddCondition("createdon", ConditionOperator.OnOrBefore, dateFrom);
            }
            // Define filter query.Criteria


            var entityCollection = DynamicsService.RetrieveAllRecords(_organizationService, query);
            recordCount.Text = "" + entityCollection.Count;
            foreach (var entity in entityCollection)
            {
                //customer, customer card, and upgrade date new_customerid
                //new_customerid, new_CardId, and new_Date
                if (entity.Attributes.ContainsKey("new_customerid")
                    && entity.Attributes.ContainsKey("new_CardId")
                    && entity.Attributes.ContainsKey("new_Date"))
                {
                    var customer = entity.GetAttributeValue<EntityReference>("new_customerid");
                    var card = entity.GetAttributeValue<EntityReference>("new_CardId");
                    var date = entity.GetAttributeValue<DateTime>("new_Date");
                    var key = new DictionaryKey
                    {
                        Customer = customer.Id,
                        Card = card.Id,
                        DateTime = date               };
                  
                    if (_dataRecords.ContainsKey(key))
                    {
                        _dataRecords[key].Add(entity);
                    }
                    else
                    {
                        var dataRecord = new List<Entity>();
                        dataRecord.Add(entity);
                        _dataRecords.Add(key, dataRecord);
                    }
                }

            }
            recordsList.Items.Clear();
            var keyRecord = "name |   createdon | date | customer | card";
            recordsList.Items.Add(keyRecord);
            foreach (var dataEntry in _dataRecords.Values)
            {
                foreach (var entity in dataEntry)
                {
                    var customer = entity.GetAttributeValue<EntityReference>("new_customerid");
                    var card = entity.GetAttributeValue<EntityReference>("new_CardId");
                    var date = entity.GetAttributeValue<DateTime>("new_Date");
                    var name = entity.GetAttributeValue<string>("new_name");
                    var createdon = entity.GetAttributeValue<DateTime>("createdon");

                    var item = name + "|  " + createdon + "| " + date + "| " + customer.Id.ToString() + "| " + card.Id.ToString() ;
                    recordsList.Items.Add("________________________________________________________________________________");

                }
                recordsList.Items.Add("================================================================================================");
            }

        }       

        private void applyChanges_Click(object sender, EventArgs e)
        {
            //foreach (var entityList in _dataRecords.Values)
            //{
            //    if (entityList.Count > 0)
            //    {
            //        var oldestRecord = GetOldestRecord(entityList);
            //        entityList.Remove(oldestRecord);
            //        foreach (var entity in entityList)
            //        {
            //            DynamicsService.DeactivateEntity(_organizationService, entity, 0, 0);
            //            var query = new QueryExpression("invoice");
            //            var invoiceList = DynamicsService.GetEntityCollection(_organizationService,query);
            //            foreach (var invoice in invoiceList)
            //            {
            //                DynamicsService.DeactivateEntity(_organizationService, invoice, 0, 0);
            //            }
            //        }
            //    }
            //}
        }

        private Entity GetOldestRecord(List<Entity> entityList)
        {
            var tempOldest = entityList[0];
            foreach (var entity in entityList)
            {
                var curDate = entity.GetAttributeValue<DateTime>("createdon");
                var tempOldestDate = tempOldest.GetAttributeValue<DateTime>("createdon");
                if (tempOldestDate > curDate)
                {
                    tempOldest = entity;
                }
            }
            return tempOldest;
        }
       

        private void testConnectionBtn_Click_1(object sender, EventArgs e)
        {           
            string crmServerName = crmServer.Text;
            string crmOrganizationName = organisationName.Text;
            string userNameVlue = userName.Text;
            string passwordValue = password.Text;
            _organizationService = OrganisationService.GetCrmOrgService(
             crmServerName, crmOrganizationName,
             userNameVlue, passwordValue);
            var loggedInUser = DynamicsService.TestConnection(_organizationService);
            if (!string.IsNullOrEmpty(loggedInUser))
            {
                connectionStatus.Text = "Connected as : "+ loggedInUser;
                connectionStatus.ForeColor = Color.Green;
            }
            else
            {
                connectionStatus.Text = "Failed to connect";
                connectionStatus.ForeColor = Color.Red;
            }
        }

        private void showPassword_Click(object sender, EventArgs e)
        {
            if (!showPassword.Text.Equals("Hide Password"))
            {
                showPassword.Text = "Hide Password";
                password.PasswordChar = '\0';
            }
            else
            {
                showPassword.Text = "Show Password";
                password.PasswordChar = '*';
            }
           
        }
    }
}
