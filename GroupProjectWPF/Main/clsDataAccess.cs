using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectWPF.Main
{ 
    class clsDataAccess
    {
        //Connection string
        private string sConnectionString;

        public clsDataAccess()
        {
            sConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\store.accdb";
        }

        public DataSet ExecuteSqlStatement(string sSql, ref int iRetVal)
        {
            try
            {
                DataSet ds = new DataSet();

                using(OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        //Open connection
                        conn.Open();

                        //Add the inforamation for the SelectCommand
                        adapter.SelectCommand = new OleDbCommand(sSql, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Fill up DataSet with data
                        adapter.Fill(ds);

                    }
                }

                //Set the number of values returned
                iRetVal = ds.Tables[0].Rows.Count;

                //Return DataSet
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name);
            }
        }

        public string ExecuteScalarSQL(string sSQL)
        {
            try
            {
                object obj;

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        conn.Open();

                        adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        obj = adapter.SelectCommand.ExecuteScalar();
                    }
                }

                if(obj == null)
                {
                    return "";
                }
                else
                {
                    return obj.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name);
            }

        }

        public int ExecuteNonQuery(string sSQL)
        {
            try
            {
                int iNumRows;

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    conn.Open();

                    OleDbCommand cmd = new OleDbCommand(sSQL, conn);
                    cmd.CommandTimeout = 0;

                    iNumRows = cmd.ExecuteNonQuery();
                }

                return iNumRows;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name);
            }
        }
    }
}
