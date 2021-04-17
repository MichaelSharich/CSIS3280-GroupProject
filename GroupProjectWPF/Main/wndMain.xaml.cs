using GroupProjectWPF.Search;
using GroupProjectWPF.Items;
using System;
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

namespace GroupProjectWPF.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        #region attributes
        /// <summary>
        /// Connection to the database
        /// </summary>
        clsDataAccess db;

        /// <summary>
        /// Connection to the Mains logic
        /// </summary>
        clsMainLogic ml;

        /// <summary>
        /// Holds the interaction with the database
        /// </summary>
        clsMainSQL sMS;

        /// <summary>
        /// Class that holds the search functionality
        /// </summary>
        wndSearch searchWin;

        /// <summary>
        /// Class that holds the update functionality. Not working
        /// </summary>
        //wndItems itemsWin;

        //Grants access to the list of invoices
        List<Invoice> invoices;

        #endregion
        /// <summary>
        /// Initializes the window
        /// </summary>
        public wndMain()
        {
            InitializeComponent();

            db = new clsDataAccess();
            ml = new clsMainLogic();
            sMS = new clsMainSQL();

            searchWin = new wndSearch();
            //itemsWin = new wndItems();
            invoices = new List<Invoice>();
        }

        /// <summary>
        /// Sends the user to the search window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //wndSearch SearchWnd = new wndSearch();
                searchWin.Activate();
                this.Hide();
                searchWin.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Sends the user to the update items window. Can't get this to work for some reason
        /// </summary>
        /// <param name="sender"></param>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // wndItems winItem = new wndItems();
                // winItem.Activate();
                //this.Hide();
                // winItem.ShowDialog();
                // this.Show();
                // winItem.Close();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handle the error.
        /// </summary>
        /// <param name="sClass">The class in which the error occurred in.</param>
        /// <param name="sMethod">The method in which the error occurred in.</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                //Would write to a file or database here.
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Accesses the create functionality to make a new invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Accesses the Edit functionality to edit an existing invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Accesses the Delete functionality to delete an invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
