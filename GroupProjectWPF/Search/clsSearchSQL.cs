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
    /// <summary>
    /// class clsSearchSQL - Provides sql access query accessability
    /// 
    ///             Fields:
    ///                 private string StoreConnectionString;
    /// </summary>
    class clsSearchSQL
    {
        // Used to store connection string to sql database
        private string StoreConnectionString;

        /// <summary>
        /// public clsSearchSQL() - Set connection string with accessor and data source
        /// </summary>
        public clsSearchSQL()
        {
            // Set connection string with accessor and data source
            StoreConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =|DataDirectory|\Store.accdb";
        }

        /// <summary>
        /// public DataSet GetInvoices() - Connect to access db and fill a dataset with values from the query
        /// </summary>
        /// <returns></returns>
        public DataSet GetInvoices()
        {
                //Query to be executed on SQL db
                String sSQL = "SELECT * from Invoices";
                //Dataset to store returned data
                DataSet ds = new DataSet();
                
                //Establish connection
                using (OleDbConnection conn = new OleDbConnection(StoreConnectionString))
                {
                    // Create adapter
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

        /// <summary>
        /// public List<String> GetInvoiceItems(int invoiceID)
        /// 
        ///             Run SQL query to get all the items on an invoice
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <returns></returns>
        public List<String> GetInvoiceItems(int invoiceID)
        {
            try
            {
                //Items list to return
                List<String> items = new List<string>();
                //str for some reason
                String str = "";
                //SQL query to find ItemName
                String cmdText = "SELECT ItemName FROM (Items INNER JOIN Invoices ON Items.ItemID = Invoices.ItemID) WHERE InvoiceID=" + invoiceID;

                using (OleDbConnection con = new OleDbConnection(StoreConnectionString))
                {
                    con.Open();
                    using (OleDbCommand cmd = new OleDbCommand(cmdText))
                    {
                        cmd.Connection = con;
                        //Create reader for parsing data
                        OleDbDataReader rdr = cmd.ExecuteReader();
                        //While reader can read
                        while (rdr.Read())
                        {
                            //Get item name and add it to items array
                            str = rdr["ItemName"].ToString();
                            items.Add(str);
                        }

                        rdr.Close();
                    }
                    con.Close();
                }

                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                            "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// public double GetItemPrice(String item) :
        /// 
        ///             Get item price for specific item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public double GetItemPrice(String item)
        {
            try {
                // SQL query to execute
                String sSQL = "SELECT ItemPrice from Items where ItemID =" +  item ;
                // Dataset for storing returned information
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

                // Set price
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
