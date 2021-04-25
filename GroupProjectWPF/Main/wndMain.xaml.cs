using GroupProjectWPF.Search;
using GroupProjectWPF.Items;
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
        /// Allows the manipulate invoice group box to operate
        /// and allows the software to check to make sure the table window can be accessed
        /// </summary>
        int manInvoice = 0;

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
        wndItems tableWin;

        //Grants access to the list of invoices
        List<Invoice> invoices;

        #endregion
        /// <summary>
        /// Initializes the window
        /// </summary>
        public wndMain()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                db = new clsDataAccess();
                ml = new clsMainLogic();
                sMS = new clsMainSQL();

                searchWin = new wndSearch();
                tableWin = new wndItems();
                invoices = new List<Invoice>();

                DataSet ds = new DataSet();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Sends the user to the search window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wndSearch searchWnd = new wndSearch();
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
        /// Sends the user to the update items window.
        /// </summary>
        /// <param name="sender"></param>
        private void itemTable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(manInvoice == 0)
                {
                    wndItems tableWin = new wndItems();
                    tableWin.Activate();
                    this.Hide();
                    tableWin.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Please finish creating or editing an invoice to continue "
                        + " to the def table.");
                }
                 
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        /// <summary>
        /// Accesses the create functionality to make a new invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateMain_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                manInvoice = 1;
                gbManipulateInvoice.IsEnabled = true;
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
                manInvoice = 1;
                //FillInvoice();
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Allows for a selected invoice to be deleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               //DeleteInvoice(InvoiceNum);
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Stops the current edit/creation of an invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                manInvoice = 0;
                gbManipulateInvoice.IsEnabled = false;

                txtInvoiceNum.Text = "";
                txtInvoiceDat.Text = "";
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
        /// Restrict User Input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInvoiceNum_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //Only allow numbers to be entered
            if(!((e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                //Allow the user to use the backspace and delete keys
                if(!(e.Key == Key.Back || e.Key == Key.Delete))
                {
                    //No other keys aside from numbers, backspace and delete
                    e.Handled = true;
                }
            }
        }

        private void txtInvoiceDate_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //Only allow numbers to be entered
            if (!((e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                //Allow the user to use the backspace and delete keys
                if (!(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.OemQuestion))
                {
                    //No other keys aside from numbers, backspace and delete
                    e.Handled = true;
                }
            }
        }
    }
}
