using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectWPF
{
    class Invoice
    {
        public int UniqueID = 0;
        public int InvoiceID = 0;
        public String InvoiceDate = "";
        public double TotalPrice = 0;
        public int ItemID = 0;
        public String OrderItem;
        public Invoice()
        {

        }
        public Invoice(int uid, int iid, String d, double tp, int itID, String oItem)
        {
            UniqueID = uid;
            InvoiceID = iid;
            InvoiceDate = d;
            TotalPrice = tp;
            ItemID = itID;
            OrderItem = oItem;
        }
        public Invoice(int iid, string d, double tp, int itID, String oItem)
        {
            InvoiceID = iid;
            InvoiceDate = d;
            TotalPrice = tp;
            ItemID = itID;
            OrderItem = oItem;
        }

        public override string ToString()
        {

            return InvoiceID + " " + InvoiceDate + " " + ItemID + " " + OrderItem;
        }
    }
}
