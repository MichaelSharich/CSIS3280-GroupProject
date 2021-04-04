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

namespace GroupProjectWPF.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        clsSearchLogic logic = new clsSearchLogic();
        List<Invoice> display = new List<Invoice>();
        bool chInvoice = false;
        bool chDate = false;
        bool chTotal = false;

        public wndSearch()
        {
            InitializeComponent();

            PopulateCmbo();
            PopulateTxtBox();
        }


        public void PopulateCmbo()
        {
            txtInvoices.ItemsSource = logic.GettxtInvoices();

            cmbInvoiceNum.ItemsSource = logic.GetcmbInvoices();

            cmbDate.ItemsSource = logic.GetcmbDates();

            cmbTotalCharge.ItemsSource = logic.GetcmbTotals();
        }

        public void PopulateTxtBox()
        {
            txtInvoices.ItemsSource = logic.GetActiveInvoices();
        }

        private void cmbInvoiceNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbInvoiceNum.SelectedItem == null)
            {
                return;
            }

            chInvoice = true;

            string str = cmbInvoiceNum.SelectedItem.ToString();

            logic.FilterInvoice(str);

            PopulateCmbo();
            
        }

        private void cmbDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbDate.SelectedItem == null)
            {
                return;
            }

            chDate = true;

            string str = cmbDate.SelectedItem.ToString();

            logic.FilterDate(str);

            PopulateCmbo();
        }

        private void cmbTotalCharge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTotalCharge.SelectedItem == null)
            {
                return;
            }

            chTotal = true;

            double str = Convert.ToDouble(cmbTotalCharge.SelectedItem.ToString());

            logic.FilterTotal(str);

            PopulateCmbo();
        }

        private void btnClearSelection_Click(object sender, RoutedEventArgs e)
        {
            logic = new clsSearchLogic();

            cmbInvoiceNum.ItemsSource = "";
            cmbDate.ItemsSource = "";
            cmbTotalCharge.ItemsSource = "";


            PopulateCmbo();
            PopulateTxtBox();
        }
    }
}
