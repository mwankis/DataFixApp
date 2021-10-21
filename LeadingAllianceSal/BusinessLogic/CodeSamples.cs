//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BusinessLogic
//{
//    class CodeSamples
//    {
//        private void button1_Click(object sender, EventArgs e)
//        {
//            //dataGridView1.DataSource = null;
//            DataTable dataTable = (DataTable)dataGridView1.DataSource;

//            for (int i = 0; i < 15; i++)
//            {
//                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
//                row.Cells[0].Value = "Test " + i;
//                if (i % 2 == 0)
//                {
//                    row.Cells[1].Value = "grey";
//                }
//                dataGridView1.Rows.Add(row);


//            }

//            foreach (DataGridViewRow row in dataGridView1.Rows)
//            {
//                var rowCell = row.Cells[1];
//                if (rowCell.Value != null)
//                {
//                    string rowColour = row.Cells[1].Value.ToString();
//                    if (rowColour == "grey")
//                    {
//                        row.DefaultCellStyle.BackColor = Color.LightGray;
//                        row.DefaultCellStyle.ForeColor = Color.DarkBlue;
//                    }
//                }

//            }
//        }

//        private void button2_Click(object sender, EventArgs e)
//        {
//            dataGridView1.Rows.Clear();
//            dataGridView1.Refresh();
//        }
//    }
//}
//var query = new QueryExpression("invoice");
//var invoiceList = DynamicsService.GetEntityCollection(_organizationService, query);
//foreach (var invoice in invoiceList)
//{
//    DynamicsService.DeactivateEntity(_organizationService, invoice, 0, 0);
//}