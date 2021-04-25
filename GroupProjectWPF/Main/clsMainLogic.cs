using GroupProjectWPF.Search;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace GroupProjectWPF.Main
{
    class clsMainLogic
    {
        /// <summary>
        /// Holds the interaction with the database
        /// </summary>
        clsMainSQL sMS;

        /// <summary>
        /// Connection to the database
        /// </summary>
        clsDataAccess db;

        /// <summary>
        /// Will be used to delete an invoice from the database
        /// </summary>
        /// <param name="sInvoiceId"></param>
        public void DeleteInvoice(int sInvoiceId)
        {

        }

    }
}
