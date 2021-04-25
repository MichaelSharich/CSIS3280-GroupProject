using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GroupProjectWPF.Search
{
    /// <summary>
    /// public partial class wndSearch : Window 
    ///            // Class fields
    ///             clsSearchLogic logic;
    ///             List<Invoice> display;
    ///             Invoice SelectedInvoice;
    ///             bool chInvoice;
    ///             bool chDate;
    ///             bool chTotal;
    /// </summary>
    public partial class wndSearch : Window
    {
        // Search logic class for pulling data
        clsSearchLogic logic = new clsSearchLogic();
        // List of current invoices to display
        List<Invoice> display = new List<Invoice>();
        // Current invoice that has been selected by the user
        Invoice SelectedInvoice;
        // Booleans for when a change has been made
        bool chInvoice = false;
        bool chDate = false;
        bool chTotal = false;


        /// <summary>
        /// public wndSearch() : InitializeComponent(); -- Create form
        ///                      Calls - PopulateCmbo(); -- Fill boxes with data on initialization
        /// </summary>
        public wndSearch()
        {
            try
            {
                InitializeComponent();

                // Set datagrid to active invoices only
                datGrid.ItemsSource = logic.GetActiveInvoices();
                // Initialize SelectedInvoice to first index to ensure no null value is passed
                SelectedInvoice = logic.invoices.ElementAt(0);

                //Call main update function
                PopulateCmbo();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                            "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }  

        /// <summary>
        /// public void PopulateCmbo() - Update function called on changes - used as update event
        /// </summary>
        public void PopulateCmbo()
        {
            try
            {
                // Set Datagrid to current invoice list
                datGrid.ItemsSource = logic.invoices;

                //Set invoice numbers item source to logic return
                cmbInvoiceNum.ItemsSource = logic.GetcmbInvoices();

                //Set dates source to logic return
                cmbDate.ItemsSource = logic.GetcmbDates();

                //Set totalcharge source to logic return
                cmbTotalCharge.ItemsSource = logic.GetcmbTotals();

            }
            catch (Exception ex)
            {
                HandleException(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// HandleException(string sClass, string sMethod, string sMessage) : 
        ///                         
        ///                        Show error message when exception is handled and write error information
        ///                        to filesystem
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleException(string sClass, string sMethod, string sMessage)
        {
            try
            {
                System.Windows.MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText("C:\\Error.txt", Environment.NewLine + "HandleErorr Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// private void cmbInvoiceNum_SelectionChanged(object sender, SelectionChangedEventArgs e) -
        /// 
        ///           When combo selection is changed call logic filter to change static invoices list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbInvoiceNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Ensure selected item is valid
            if(cmbInvoiceNum.SelectedItem == null)
            {
                return;
            }

            try
            {
                // Set boolean to true so that this invoice filter is also applied to later filters
                chInvoice = true;

                // 
                string str = cmbInvoiceNum.SelectedItem.ToString();

                logic.FilterInvoice(str);

                PopulateCmbo();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                            "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// private void cmbDate_SelectionChanged(object sender, SelectionChangedEventArgs e) :
        /// 
        ///             Filter textbox based on selected index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbDate.SelectedItem == null)
            {
                return;
            }

            try
            {
                // Set boolean to true so that this invoice filter is also applied to later filters
                chDate = true;

                //Get selected item to send to filter
                string str = cmbDate.SelectedItem.ToString();

                //Filter static invoices list
                logic.FilterDate(str);

                //Update items sources
                PopulateCmbo();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                            "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// private void cmbTotalCharge_SelectionChanged(object sender, SelectionChangedEventArgs e) :
        /// 
        ///             Filter textbox based on selected index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTotalCharge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTotalCharge.SelectedItem == null)
            {
                return;
            }

            try
            {
                // Set boolean to true so that this invoice filter is also applied to later filters
                chTotal = true;

                //Get str from combo box
                double str = Convert.ToDouble(cmbTotalCharge.SelectedItem.ToString());

                //Filter based on selected string
                logic.FilterTotal(str);

                //Update txt and combo boxes
                PopulateCmbo();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                            "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        ///  private void btnClearSelection_Click(object sender, RoutedEventArgs e):
        ///  
        ///             Reset logic and item sources
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSelection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Create new logic - all static invoices are now reset to default
                logic = new clsSearchLogic();

                // Helps with resetting the itemsources
                cmbInvoiceNum.ItemsSource = "";
                cmbDate.ItemsSource = "";
                cmbTotalCharge.ItemsSource = "";

                // Update
                PopulateCmbo();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                            "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        ///  private void SelectInvoice_Click(object sender, RoutedEventArgs e):
        ///  
        ///             Select button gets current selected item from datagrid
        ///             and passes it to wndMain for displaying
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Set selected invoice
                SelectedInvoice = (Invoice)datGrid.SelectedItem;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                            "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            //Pass SelectedInvoice to wndMain
            //this.Close();
        }
    }
}
