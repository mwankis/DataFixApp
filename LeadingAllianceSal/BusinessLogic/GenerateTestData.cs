using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public static class GenerateTestData
    {
        public static OperationResult GetTestData()
        {
            var response = new OperationResult();
            var dataList = new List<Entity>();
            var entity = new Entity("new_upgrade");
            entity["new_customerid"] = new EntityReference("new_customer", Guid.NewGuid());
            entity["new_cardid"] = new EntityReference("new_card", Guid.NewGuid());
            entity["new_date"] = DateTime.Parse("2019/08/09  11:44:00");
            entity["createdon"] = DateTime.Parse("2019/08/09  18:30:33");
            entity["new_name"] = "Test name";
            dataList.Add(entity);

            var entity2 = new Entity("new_upgrade");
            entity2["new_customerid"] = new EntityReference("new_customer", Guid.NewGuid());
            entity2["new_cardid"] = new EntityReference("new_card", Guid.NewGuid());
            entity2["new_date"] = DateTime.Parse("2019/04/09  12:44:00");
            entity2["createdon"] = DateTime.Parse("2019/08/09  19:30:33");
            entity2["new_name"] = "Test two";
            dataList.Add(entity2);

            var entity3 = new Entity("new_upgrade");
            entity3["new_customerid"] = new EntityReference("new_customer", Guid.NewGuid());
            entity3["new_cardid"] = new EntityReference("new_card", Guid.NewGuid());
            entity3["new_date"] = DateTime.Parse("2019/10/10  11:44:00");
            entity3["createdon"] = DateTime.Parse("2019/10/09  23:30:33");
            entity3["new_name"] = "Test three";
            dataList.Add(entity3);

            var entity4 = new Entity("new_upgrade");
            entity4["new_customerid"] = new EntityReference("new_customer", Guid.NewGuid());
            entity4["new_cardid"] = new EntityReference("new_card", Guid.NewGuid());
            entity4["new_date"] = DateTime.Parse("2019/04/09  11:44:00");
            entity4["createdon"] = DateTime.Parse("2019/06/09  21:30:33");
            entity4["new_name"] = "Test four";
            dataList.Add(entity4);

            var entity5 = new Entity("new_upgrade");
            entity5["new_customerid"] = new EntityReference("new_customer", Guid.NewGuid());
            entity5["new_cardid"] = new EntityReference("new_card", Guid.NewGuid());
            entity5["new_date"] = DateTime.Parse("2019/03/09  10:44:00");
            entity5["createdon"] = DateTime.Parse("2019/07/09  17:30:33");
            entity5["new_name"] = "Test five";
            dataList.Add(entity4);
            var actualList = new List<Entity>();
            Random rn = new Random();
            for (int i = 0; i < 10; i++)
            {
                int index = rn.Next(0, 4);
                actualList.Add(dataList[index]);
            }
            response.EntityList = actualList;
            return response;
        }
    }
}
