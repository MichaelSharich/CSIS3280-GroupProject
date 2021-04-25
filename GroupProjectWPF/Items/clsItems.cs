using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectWPF.Items
{
    class clsItems
    {
        private string id;
        private string name;
        private string itemPrice;
        private string itemDescription;

        public clsItems(String inID, String iname, String iprice, String iDesc)
        {
            id = inID;
            name = iname;
            itemPrice = iprice;
            itemDescription = iDesc;
        }

        public clsItems()
        {
            id = "";
            name = "";
            itemPrice = "";
            itemDescription = "";
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
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
