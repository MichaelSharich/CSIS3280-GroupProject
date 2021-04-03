using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectWPF.Items
{
    // Pass in the clsItemsSQL class so we can access the methods within that class.
    class clsItemsLogic
    {
        //Create a method called AllItems that will add data to a list, That will then be used to add the items to a datagrid
            // this method should create a list
            // this method will call the getItems() method from the clsItemSQL
            // then once the items are added to the list, return the list.

        //Create a method called AddItem that will add an item to the datagrid
            // this method should create a list
            // this method should call the insertItem() method to add the specified item to the list
            // return the list with the added item.

        //Create a method called EditItem that will edit an existing item in the datagrid
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
    }
}
