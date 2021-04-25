using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectWPF.Items
{
    class clsItemsSQL
    {
        private string sConnectionString;

        public clsItemsSQL()
        {
            sConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Directory.GetCurrentDirectory() + "\\Store.accdb";
        }
        /// <summary>
        /// This SQL statement gets all the items from the database.
        /// </summary>
        /// <returns>All Items</returns>
        public DataSet getItems()
        {
            // This try catch block, checks for exceptions and then raises them.
            try
            {
                String sSQL1 = "select ItemID, ItemName, ItemPrice, ItemDescription from Items";
                DataSet ds = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        //Open connection
                        conn.Open();

                        //Add the inforamation for the SelectCommand
                        adapter.SelectCommand = new OleDbCommand(sSQL1, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Fill up DataSet with data
                        adapter.Fill(ds);

                    }
                }

                //Return DataSet
                return ds;
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }


        /// <summary>
        /// updates an item from the database.
        /// </summary>
        /// <param name="iDesc"></param>
        /// <param name="iCost"></param>
        /// <param name="iCode"></param>
        /// <returns>Update item</returns>
        public void updateItem(string iDesc, string iCost, string ID)
        {
            // This try catch block, checks for exceptions and then raises them.
            try
            {

                string sSQL3 = "Update Items Set ItemDescription " + iDesc + ", ItemPrice = " + iCost + " where ItemID = " + ID;

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        //Open connection
                        conn.Open();

                        //Add the inforamation for the SelectCommand
                        adapter.SelectCommand = new OleDbCommand(sSQL3, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                    }
                }
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
            
        }

        /// <summary>
        /// Inserts an item into the database.
        /// </summary>
        /// <param name="sItemName"></param>
        /// <param name="sDesc"></param>
        /// <param name="sCost"></param>
        /// <returns>Inserts item</returns>
        public void insertItem(string sItemName, int sCost, string sDesc)
        {
            // This try catch block, checks for exceptions and then raises them.
            try
            {
                string sSQL4 = "Insert into Items (ItemName, ItemPrice, ItemDescription) Values ('" + sItemName + "', + '" + sCost + "', '" + sDesc + "')";

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    conn.Open();

                    OleDbCommand cmd = new OleDbCommand(sSQL4, conn);
                    cmd.CommandTimeout = 0;

                    cmd.ExecuteNonQuery();
                }
              
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
            
        }
       
        /// <summary>
        /// Deletes an item from the database.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int deleteItem(string code)
        {
            // This try catch block, checks for exceptions and then raises them.
            try
            {
                string sSQL5 = " Delete from Items Where ItemID = " + code;
                int iNumRows;

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    conn.Open();

                    OleDbCommand cmd = new OleDbCommand(sSQL5, conn);
                    cmd.CommandTimeout = 0;

                    iNumRows = cmd.ExecuteNonQuery();
                }

                return iNumRows;
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
            
        }
       
    }
}
