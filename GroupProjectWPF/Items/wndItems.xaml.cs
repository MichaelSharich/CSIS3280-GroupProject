using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
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

namespace GroupProjectWPF.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        clsItemsLogic itemLogic;
        clsItemsSQL SQL;
        clsItems Item;
        bool IsDeleting = false;
        DataSet ds;
        string itemname;
        int itemprice;
        string itemdesc;
        bool no = false;

        public wndItems()
        {
            InitializeComponent();
            // Make sure to include this line of code or the application will not close, because windows are still in memory.
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            itemLogic = new clsItemsLogic();
            Item = new clsItems();
            SQL = new clsItemsSQL();
            ds = SQL.getItems();
            fillDataGrid();
        }

        public void fillDataGrid()
        {
            ListOfItemsDG.ItemsSource = "";
            ListOfItemsDG.ItemsSource = itemLogic.AllItems();
            //ListOfItemsDG.Columns[0].Visibility = Visibility.Hidden;
        }


        /// <summary>
        /// This method is to add a new item to the datagrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // This method will check if the user entered a valid item.
                // This method will call the AddItem() method so a new item can be added to the data grid
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method is to edit an item in the data grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditItemBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // This method will call the GetItem() method so the user knows what item is being edited.
                // This method will call the EditItem() method so the user can edit an item in the datagrid/database.
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method will delete the item from the datagrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ListOfItemsDG.CurrentCell != null)
                {
                    int iRowNum = ListOfItemsDG.Items.IndexOf(ListOfItemsDG.CurrentItem);

                    IsDeleting = true;

                    ds.Tables[0].Rows[iRowNum].Delete();

                    ds.AcceptChanges();

                    ListOfItemsDG.ItemsSource = itemLogic.DeleteItem(iRowNum.ToString());

                    IsDeleting = false;
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
        ///  this method is used to make sure that the user has entered in a valid item to be added.
        /// </summary>
        /// <returns>isValid</returns>
        private Boolean ValidItem()
        {
            // This try catch block, checks for exceptions and then raises them.
            try
            {
                // this method is used to make sure that the user has entered in a valid item.
                return true;
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// This method is used to check if an item can be deleted.
        /// </summary>
        /// <returns>isValid</returns>
        private Boolean CanBeDeleted()
        {
            // This try catch block, checks for exceptions and then raises them.
            try
            {
                // this method is used to make sure that the user can delete an item from the datagrid, this method also checks if the item is already in an invoice.
                return true;
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
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
                MessageBox.Show(sClass + "." + sMethod + "->" + sMessage);
            }
            catch (Exception ex)
            {

                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }

        /*private string getItemText()
        {
            string addedItem = ItemIDTextBox.Text;
            return addedItem;
        }*/

        private void AddNewItemBtn_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                itemname = ItemNameTextBox.Text;
                itemprice = Convert.ToInt32(CostTextBox.Text);
                itemdesc = DescriptionTextBox.Text;

                itemLogic.AddItem(itemname, itemprice, itemdesc);

                fillDataGrid();


            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void ListOfItemsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (costTextBox.IsFocused || descriptionTextBox.IsFocused)
            {
                return;
            }
            if(no == true)
            {
                return;
            }

            try
            {
                ds = SQL.getItems();

                int rowIndex = ListOfItemsDG.SelectedIndex;

                costTextBox.Text = ds.Tables[0].Rows[rowIndex][2].ToString();
                descriptionTextBox.Text = ds.Tables[0].Rows[rowIndex].ItemArray[3].ToString();

               
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void UpdateItemBtn_Click(object sender, RoutedEventArgs e)
        {
            no = true;
            ds = SQL.getItems();

            clsItems item = new clsItems();
            item = (clsItems) ListOfItemsDG.SelectedItem;

            clsItems test = new clsItems(item.ID, item.Name, costTextBox.Text, descriptionTextBox.Text);

            itemLogic.EditItem(test);

            fillDataGrid();

            no = false;
        }

    }
}
