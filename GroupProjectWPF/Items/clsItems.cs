using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectWPF.Items
{
    class clsItems
    {
        private string itemID;
        private string itemPrice;
        private string itemDescription;

        public clsItems(String id, String iprice, String iDesc)
        {
            itemID = id;
            itemPrice = iprice;
            itemDescription = iDesc;
        }

        public clsItems()
        {
            itemID = "";
            itemPrice = "";
            itemDescription = "";
        }

        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        public string ItemPrice
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }

        public string ItemDescription
        {
            get { return itemDescription; }
            set { itemDescription = value; }
        }
    }
}
