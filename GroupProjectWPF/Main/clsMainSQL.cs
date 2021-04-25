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

namespace GroupProjectWPF.Main
{
    class clsMainSQL
    {

        clsDataAccess db = new clsDataAccess();

        /// <summary>
        /// This SQL is used to add a new Invoice to the database
        /// Will use: INSERT INTO Invoices
        /// </summary>
        public string CreateInvoice(string sInvoiceID, string sDate, int Price, int OrderItem)
        {
            try
            {
                string sSQL1 = "INSERT INTO Invoices ()";
                return sSQL1;
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }


        /// <summary>
        /// This SQL is used to Edit an invoice's Date
        /// Will use: UPDATE Invoices SET [part of invoice] = [num] WHERE [invoice feature] = [user submitted data]
        /// </summary>
        public string EditTotalCost(string sInvoiceID, string sDate)
        {
            try
            {
                string sSQL1 = "UPDATE Invoices SET TotalPrice = " + sDate
                    + " WHERE InvoiceID = " + sInvoiceID;
                return sSQL1;
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL is used to Edit an invoice's TotalCost 
        /// Will use: UPDATE Invoices SET [part of invoice] = [num] WHERE [invoice feature] = [user submitted data]
        /// </summary>
        public string EditTotalCost(string sInvoiceID, int sTotalCost)
        {
            try
            {
                string sSQL1 = "UPDATE Invoices SET TotalPrice = " + sTotalCost.ToString() 
                    + " WHERE InvoiceID = " + sInvoiceID;
                return sSQL1;
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL is used to delete an invoice from the database
        /// Will use: DELETE From Invoices WHERE InvoiceNum = [user submitted int]
        /// </summary>
        public string DeleteInvoice(int inNum)
        {
            try
            {
                string sSQL1 = "DELETE From Invoices WHERE InvoiceID = " + inNum.ToString();
                return sSQL1;
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

    }
}
