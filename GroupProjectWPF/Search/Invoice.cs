using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectWPF.Search
{
    public class Invoice
    {
        public int UniqueID { get; set; }
        public int InvoiceID { get; set; }
        public String InvoiceDate { get; set; }
        public double TotalPrice { get; set; }
        public int ItemID { get; set; }
        public String OrderItem { get; set; }

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
