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
        public void CreateInvoice()
        {

        }

        /// <summary>
        /// This SQL is used to Edit an invoice's information 
        /// Will use: UPDATE Invoices SET [part of invoice] WHERE [related] = [user submitted data]
        /// </summary>
        public void EditInvoice()
        {

        }

        /// <summary>
        /// This SQL is used to delete an invoice from the database
        /// Will use: DELETE From Invoices WHERE InvoiceNum = [user submitted int]
        /// </summary>
        public void DeleteInvoice(int inNum)
        {

        }

    }
}
