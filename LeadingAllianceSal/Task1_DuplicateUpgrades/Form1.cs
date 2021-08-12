using BusinessLogic;
using Microsoft.Crm.Sdk.Messages;
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
            var query = new QueryExpression("new_upgrade")
            {
                ColumnSet = new ColumnSet(true)
            };
            query.AddOrder("new_customerid", OrderType.Ascending);
            query.AddOrder("new_date", OrderType.Ascending);
            if (dateFrom != null)
            {
                query.Criteria.AddCondition("createdon", ConditionOperator.OnOrAfter, dateFrom);
            }


            var operationResult = DynamicsService.RetrieveAllRecords(_organizationService, query);

            if (operationResult.Succeded)
            {
                recordCount.Text = "" + operationResult.EntityList.Count;

                AddRecordsToDictionary(operationResult.EntityList);

                AddRecordsToDataGridView();

                FormatCellsColor();
            }
            else
            {
                errorList.Items.Add(operationResult.ErrorMessage);
                errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
            }          

        }

        private void FormatCellsColor()
        {
            foreach (DataGridViewRow row in dataRecordsGridView.Rows)
            {
                var rowCell = row.Cells[5];
                if (rowCell.Value != null)
                {
                    string rowColour = row.Cells[5].Value.ToString();
                    if (rowColour == "grey")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                    }
                }

            }
        }

        private void AddRecordsToDictionary(List<Entity> entityCollection)
        {
            foreach (var entity in entityCollection)
            {
                if (entity.Attributes.ContainsKey("new_customerid")
                    && entity.Attributes.ContainsKey("new_cardid")
                    && entity.Attributes.ContainsKey("new_date"))
                {
                    var customer = entity.GetAttributeValue<EntityReference>("new_customerid");
                    var card = entity.GetAttributeValue<EntityReference>("new_cardid");
                    var date = entity.GetAttributeValue<DateTime>("new_date");
                    var key = new DictionaryKey
                    {
                        Customer = customer.Id,
                        Card = card.Id,
                        DateTime = date
                    };

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
        }

        private void AddRecordsToDataGridView()
        {
            int colourCount = 0;
            foreach (var dataEntry in _dataRecords.Values)
            {
                foreach (var entity in dataEntry)
                {
                    var customer = entity.GetAttributeValue<EntityReference>("new_customerid");
                    var card = entity.GetAttributeValue<EntityReference>("new_cardid");
                    var date = entity.GetAttributeValue<DateTime>("new_date");
                    var name = entity.GetAttributeValue<string>("new_name");
                    var createdon = entity.GetAttributeValue<DateTime>("createdon");

                    DataGridViewRow row = (DataGridViewRow)dataRecordsGridView.Rows[0].Clone();

                    row.Cells[0].Value = name;
                    row.Cells[1].Value = customer.Id.ToString();
                    row.Cells[2].Value = card.Id.ToString();
                    row.Cells[3].Value = date.ToString();
                    row.Cells[4].Value = createdon.ToString();
                    if (colourCount % 2 == 0)
                    {
                        row.Cells[5].Value = "grey";
                    }


                    dataRecordsGridView.Rows.Add(row);
                }
                colourCount++;
            }
        }

        private void applyChanges_Click(object sender, EventArgs e)
        {
            foreach (var entityList in _dataRecords.Values)
            {
                if (entityList.Count > 0)
                {
                    var oldestRecord = GetOldestRecord(entityList);
                    entityList.Remove(oldestRecord);
                    foreach (var entity in entityList)
                    {
                        var operationResult = DynamicsService.DeactivateEntity(_organizationService, entity, 1, 2);
                        if (!operationResult.Succeded)
                        {
                            errorList.Items.Add("Failed to deactivate record with id: "+ entity.Id);
                            errorList.Items.Add(operationResult.ErrorMessage);
                            errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
                        }
                        else
                        {
                           errorList.Items.Add("Record successfully deactivated. Id: " + entity.Id);
                           errorList.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
                        }                      
                    }
                }
            }
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
            string userNameValue = userName.Text;
            string passwordValue = password.Text;
            var soapUrlEndpoint = soapUrl.Text;  
            
            var getOrganizationService = ConnectToCRM.ConnectToMSCRM(userNameValue, passwordValue, soapUrlEndpoint);
            _organizationService = getOrganizationService.OrganizationService;

            try
            {
                if (string.IsNullOrEmpty(getOrganizationService.ErrorMessage))
                {
                    Guid userid = ((WhoAmIResponse)_organizationService.Execute(new WhoAmIRequest())).UserId;
                    if (!userid.Equals(Guid.Empty))
                    {
                        connectionStatus.Text = "Connected successfully";
                        connectionStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        connectionStatus.Text = "Failed to connect";
                        connectionStatus.ForeColor = Color.Red;
                    }
                }
                else
                {
                    connectionStatus.Text = getOrganizationService.ErrorMessage;
                    connectionStatus.ForeColor = Color.Red;
                }
               
            }
            catch (Exception ex)
            {
                connectionStatus.Text = "Failed to connect. Error Message: "+ex.Message;
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
