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
        List<String> txtFilteredList = new List<String>();
        List<String> invFilteredList = new List<String>();
        List<String> dFilteredList = new List<String>();
        List<String> totFilteredList = new List<String>();
        bool chInvoice = false;
        bool chDate = false;
        bool chTotal = false;

        public wndSearch()
        {
            InitializeComponent();

            PopulateFilter();
            PopulateCmbo();
            PopulateTxtBox();
        }

        public void PopulateFilter()
        {
            txtInvoices.ItemsSource = txtFilteredList;
            if (chInvoice == true)
            {
                cmbInvoiceNum.ItemsSource = invFilteredList;
            }
            if (chDate == true)
            {
                cmbDate.ItemsSource = dFilteredList;
            }
            if (chTotal == true)
            {
                cmbTotalCharge.ItemsSource = totFilteredList;
            }
        }

        public void PopulateCmbo()
        {
            cmbInvoiceNum.ItemsSource = logic.GetInvoiceIDs();
            cmbDate.ItemsSource = logic.GetInvoiceDates();
            cmbTotalCharge.ItemsSource = logic.GetTotalCostList();
        }

        public void PopulateTxtBox()
        {
            txtInvoices.ItemsSource = logic.GetInvoices();
        }

        private void cmbInvoiceNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbInvoiceNum.SelectedItem == null)
            {
                return;
            }

            chInvoice = true;
            String str = "";

            str = cmbInvoiceNum.SelectedItem.ToString();

            if (chDate == true)
            {
                txtFilteredList = logic.GetInvoicesWhere("InvoiceID = " + str + " AND InvoiceDate = " + cmbDate.Text);
                invFilteredList = logic.GetInvoicesIDSWhere("InvoiceID = " + str + " AND InvoiceDate = " + cmbDate.Text);
            }
            if(chTotal == true)
            {
                foreach (String s in logic.GetTotalCostList())
                {
                    if (!s.Equals(cmbTotalCharge.SelectedItem.ToString()))
                    {
                        totFilteredList.Remove(s);
                    }
                }
                cmbTotalCharge.ItemsSource = totFilteredList;
            }
            if (chDate == false && chTotal == false)
            {
                txtFilteredList = logic.GetInvoicesWhere("InvoiceID = " + str);
                invFilteredList = logic.GetInvoicesWhere("InvoiceID = " + str);
            }

            PopulateFilter();
        }

        private void cmbDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cmbDate.SelectedItem == null)
            {
                return;
            }

            chDate = true;
            String str = "";

            str = cmbDate.SelectedItem.ToString();
            dFilteredList = logic.GetInvoicesWhere("InvoiceDate = " + str);

            if(chInvoice == true)
            {
                txtFilteredList = logic.GetInvoicesWhere("InvoiceID = " + str + " AND InvoiceDate = " + cmbDate.Text);
                List<String> templist = new List<String>();
                templist = logic.GetInvoicesWhere("InvoiceID = " + str);
                
                for(int i = 0; i < templist.Count; i++)
                {
                    templist[i] = templist[i].Substring(0, 2);
                    templist[i].Trim();
                }

                cmbInvoiceNum.ItemsSource = templist;
            }
            
            if(chTotal == true)
            {
                List<String> templist = new List<String>();

                //Find ID to pass to : public double GetInvoiceTotal(String ID)
                foreach (String s in logic.GetTotalCostList()){
                    if (!s.Equals(cmbTotalCharge.SelectedItem.ToString()))
                    {
                        totFilteredList.Remove(s);
                    }
                }
                cmbTotalCharge.ItemsSource = totFilteredList;
            }

            cmbInvoiceNum_SelectionChanged(this, null);
            cmbTotalCharge_SelectionChanged(this, null);
            PopulateFilter();            
        }

        private void cmbTotalCharge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTotalCharge.SelectedItem == null)
            {
                return;
            }
            chTotal = true;
            String str = "";

            str = cmbTotalCharge.SelectedItem.ToString();

            for (int i = 0; i < logic.GetInvoices().Count; i++)
            {
                if (str.Equals(logic.GetInvoiceTotal(logic.GetInvoiceIDs().ElementAt(i))))
                {
                    totFilteredList.Add(str);
                }
            }

            PopulateFilter();
        }
    }
}
