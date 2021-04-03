using System;
using System.Collections.Generic;
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
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class Items : Window
    {
        // this file will pass in the clsItemLogic class so we can access the public methods, we do this by creating a clsItemLogic variable.

        public Items()
        {
            InitializeComponent();

            // we initialize the clsItemLogic variable within the constructor.
        }

        /// <summary>
        /// This method is to add data to the datagrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // This method will call the AllItems() method so we can display the items within the data grid.
            }
            catch (Exception ex)
            {
                //This is the top level method so we want to handle the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
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
                // This method will call the GetItem() method so the user knows what item is being Deleted.
                // This method will call the CanBeDeleted() method to check and make sure the item is not already in an invoice
                // This method will call the DeleteItem() method so the user can delete an item from the datagrid/database.
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
                return;
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
                return;
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

    }
}
