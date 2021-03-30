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
        private string sConnectionString;

        public clsSearchSQL()
        {
            sConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =|DataDirectory|\Store.accdb";
        }

        public DataSet GetInvoices()
        {
           
                String sSQL = "SELECT * from Invoices";
                DataSet ds = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
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
            String cmdText = "SELECT * FROM Invoices WHERE InvoiceID=" + invoiceID;

            using (OleDbConnection con = new OleDbConnection(sConnectionString))
            {
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(cmdText))
                {
                    cmd.Connection = con;
                    OleDbDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string str = string.Join(Environment.NewLine, rdr.GetString(0).ToString());
                        Console.WriteLine(rdr.GetString(0).ToString());
                        Console.WriteLine(rdr.GetString(0));
                        Console.WriteLine(str);
                        Console.WriteLine(rdr.GetString(0));

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
            try
            {
                String sSQL = "SELECT ItemPrice from Items where ItemName LIKE *" + item + "*";
                DataSet ds = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
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
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name);
            }
        }
    }
}
