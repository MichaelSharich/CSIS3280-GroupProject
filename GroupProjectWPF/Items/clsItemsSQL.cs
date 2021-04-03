using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectWPF.Items
{
    class clsItemsSQL
    {
        //Pass in the database class.

        /// <summary>
        /// This SQL statement gets all the items from the database.
        /// </summary>
        /// <returns>All Items</returns>
        public string getItems()
        {
            // This try catch block, checks for exceptions and then raises them.
            try
            {
                string sSQL1 = "select ItemCode, ItemDesc, Cost from ItemDesc";
                return sSQL1;
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// This SQL statement gets a certain item from the database.
        /// </summary>
        /// <param name="sItem"></param>
        /// <returns>A specific item</returns>
        public string getItem(string sItem)
        {
            // This try catch block, checks for exceptions and then raises them.
            try
            {
                string sSQL2 = "select distinct(InvoiceNum) from LineItems where ItemCode = " + sItem;
                return sSQL2;
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
            
        }

        /// <summary>
        /// updates an item from the database.
        /// </summary>
        /// <param name="iDesc"></param>
        /// <param name="iCost"></param>
        /// <param name="iCode"></param>
        /// <returns>Update item</returns>
        public string updateItem(string iDesc, string iCost, string iCode)
        {
            // This try catch block, checks for exceptions and then raises them.
            try
            {
                string sSQL3 = " Update ItemDesc Set ItemDesc = " + iDesc + "Cost = " + iCost + "where ItemCode = " + iCode;
                return sSQL3;
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
            
        }

        /// <summary>
        /// Inserts an item into the database.
        /// </summary>
        /// <param name="sCode"></param>
        /// <param name="sDesc"></param>
        /// <param name="sCost"></param>
        /// <returns>Inserts item</returns>
        public string insertItem(string sCode, string sDesc, string sCost)
        {
            // This try catch block, checks for exceptions and then raises them.
            try
            {
                string sSQL4 = "Insert into ItemDesc(ItemCode, ItemDesc, Cost) Values = " + (sCode, sDesc, sCost);
                return sSQL4;
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
            
        }
       
        /// <summary>
        /// Deletes an item from the database.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string deleteItem(string code)
        {
            // This try catch block, checks for exceptions and then raises them.
            try
            {
                string sSQL5 = " Delete from ItemDesc Where ItemCode = " + code;
                return sSQL5;
            }
            catch (Exception ex)
            {
                //This is the lower level method so we want to raise the exception.
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
            
        }
       
    }
}
