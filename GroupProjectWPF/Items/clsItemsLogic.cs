using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectWPF.Items
{
    // Pass in the clsItemsSQL class so we can access the methods within that class.
    class clsItemsLogic
    {
        //This is a region tag that holds our class attributes, the purpose of this tag is to help clean up our code and make it more readable by allowing us to minimize our blocks of code.
        #region Attributes

        clsItemsSQL SQL;

        List<clsItems> Items = new List<clsItems>();

        bool IsDeleting = false;

        //This is the end of our attributes region tag.
        #endregion

        //This is a region tag that holds our methods, the purpose of this tag is to help clean up our code and make it more readable by allowing us to minimize our blocks of code.
        #region Methods

        //Create a method called AllItems that will add data to a list, That will then be used to add the items to a datagrid
        // this method should create a list
        // this method will call the getItems() method from the clsItemSQL
        // then once the items are added to the list, return the list.
        public List<clsItems> AllItems()
        {
            Items.Clear();
            try
            {
                SQL = new clsItemsSQL();
                DataSet ds = SQL.getItems();
                clsItems Current;

                for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Current = new clsItems();
                    Current.ID = ds.Tables[0].Rows[i][0].ToString();
                    Current.Name = ds.Tables[0].Rows[i][1].ToString();
                    Current.ItemPrice = ds.Tables[0].Rows[i][2].ToString();
                    Current.ItemDescription = ds.Tables[0].Rows[i][3].ToString();

                    Items.Add(Current);

                }

                return Items;
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        //Create a method called AddItem that will add an item to the datagrid
        public List<clsItems> AddItem(string name, int price, string desc)
        {
            try
            {
                SQL = new clsItemsSQL();
                DataSet ds = new DataSet();
                clsItems Current;
                int iRet = 0;
                SQL.insertItem(name, price, desc);

                for (int i = 0; i < iRet; i++)
                {
                    Current = new clsItems();
                    Current.Name = ds.Tables[0].Rows[i][0].ToString();
                    Current.ItemPrice = ds.Tables[0].Rows[i][1].ToString();
                    Current.ItemDescription = ds.Tables[0].Rows[i][2].ToString();
                    Items.Add(Current);
                }

                return Items;
            }
            
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        public List<clsItems> DeleteItem(string code)
        {
            try
            {
                SQL = new clsItemsSQL();
                DataSet ds = new DataSet();
                clsItems Current;
                int iRet = 0;

                SQL.deleteItem(code);

                for (int i = 0; i < iRet; i++)
                {
                    Current = new clsItems();
                    Current.Name = ds.Tables[0].Rows[i][0].ToString();
                    Items.Add(Current);
                }

                return Items;
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
        // this method should create a list
        // this method should call the insertItem() method to add the specified item to the list
        // return the list with the added item.

        //Create a method called EditItem that will edit an existing item in the datagrid
        public void EditItem(clsItems item)
        {
            try
            {

                SQL.updateItem(item.ItemDescription, item.ItemPrice, item.ID);

            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
        // this method should create a list
        // this method will make sure that the description and cost will be the only editing factor
        // call the updateItem() method to update the specific item
        // return the list with edited item
        // this method will also update the drop down box and the current invoice using the clsSearchSQL methods and the clsMainSQL methods.

        //Create a method called DeleteItem that will delete an existing item from the datagrid
        // this method should create a list
        // this method will call the deleteItem() method in clsItemSQL
        // return the new list.

        //Create a method called GetItem() that will get the item that is to be deleted or edited.

        //This is the end of our Methods region tag.
        #endregion
    }
}
