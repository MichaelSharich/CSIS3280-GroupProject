using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectWPF.Search
{
    class clsSearchSQL
    {
        private string StoreConnectionString;

        public clsSearchSQL()
        {
            StoreConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =|DataDirectory|\Store.accdb";
        }

        public DataSet GetWhereX(String x)
        {
            String sSQL = "SELECT * from Invoices where " + x;
            DataSet ds = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(StoreConnectionString))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                {
                    //Open connection
                    conn.Open();

                    //Add the inforamation for the SelectCommand
                    adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                    adapter.SelectCommand.CommandTimeout = 0;

                    //Fill up DataSet with data
                    adapter.Fill(ds);

                }
            }

            //Return DataSet
            return ds;

        }

        public DataSet GetIDWhereX(String x)
        {
            String sSQL = "SELECT InvoiceID from Invoices where " + x;
            DataSet ds = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(StoreConnectionString))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                {
                    //Open connection
                    conn.Open();

                    //Add the inforamation for the SelectCommand
                    adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                    adapter.SelectCommand.CommandTimeout = 0;

                    //Fill up DataSet with data
                    adapter.Fill(ds);

                }
            }

            //Return DataSet
            return ds;

        }

        public DataSet GetInvoices()
        {
           
                String sSQL = "SELECT * from Invoices";
                DataSet ds = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(StoreConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        //Open connection
                        conn.Open();

                        //Add the inforamation for the SelectCommand
                        adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Fill up DataSet with data
                        adapter.Fill(ds);

                    }
                }

                //Return DataSet
                return ds;
            
            
        }

        public List<String> GetInvoiceItems(int invoiceID)
        {
            List<String> items = new List<string>();
            String str = "";
            String cmdText = "SELECT ItemName FROM (Items INNER JOIN Invoices ON Items.ItemID = Invoices.ItemID) WHERE InvoiceID=" + invoiceID;

            using (OleDbConnection con = new OleDbConnection(StoreConnectionString))
            {
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(cmdText))
                {
                    cmd.Connection = con;
                    OleDbDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        str = rdr["ItemName"].ToString();
                       items.Add(str);
                    }
                    
                    rdr.Close();
                }
                con.Close();
            }

            return items;
        }

        public double GetItemPrice(String item)
        {
           // try
           // {
                String sSQL = "SELECT ItemPrice from Items where ItemID =" +  item ;
                DataSet ds = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(StoreConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        //Open connection
                        conn.Open();

                        //Add the inforamation for the SelectCommand
                        adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Fill up DataSet with data
                        adapter.Fill(ds);

                    }
                }

                double price = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                //Return DataSet
                return price;
            //}
            //catch (Exception ex)
            //{
               // throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name);
           // }
        }
    }
}
