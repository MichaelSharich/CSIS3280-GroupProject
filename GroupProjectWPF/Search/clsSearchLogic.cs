using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectWPF.Search
{
    /// <summary>
    /// class clsSearchLogic - 
    ///             Use clsSearchSQL class to get results from queries
    /// </summary>
    class clsSearchLogic
    {
        // Instantiate clsSearchSQL for searching
        clsSearchSQL sql = new clsSearchSQL();
        // static invoices list
        public List<Invoice> invoices = new List<Invoice>();

        /// <summary>
        /// public clsSearchLogic() - Constructor 
        /// </summary>
        public clsSearchLogic()
        {
            invoices = this.GetActiveInvoices();
        }

        public void FilterInvoice(String inv)
        {
            List<Invoice> tempinv = new List<Invoice>();
            foreach (Invoice i in invoices)
            {
                if(Convert.ToString(i.InvoiceID).Equals(inv))
                {
                    tempinv.Add(i);
                }
            }
            invoices = tempinv;
        }

        public void FilterDate(String inv)
        {
            List<Invoice> tempinv = new List<Invoice>();
            foreach (Invoice i in invoices)
            {
                if((i.InvoiceDate.Equals(inv)))
                {
                    tempinv.Add(i);
                }
            }
            invoices = tempinv;
        }

        public void FilterTotal(double inv)
        {
            List<Invoice> tempinv = new List<Invoice>();
            foreach (Invoice i in invoices)
            {
                if (i.TotalPrice == inv)
                {
                    tempinv.Add(i);
                }
            }
            invoices = tempinv;
        }

        public List<String> GetcmbInvoices()
        {
            List<String> strs = new List<String>();
            foreach (Invoice i in invoices)
            {
                strs.Add(i.InvoiceID + "");
            }

            return strs;
        }

        public List<String> GetcmbDates()
        {
            List<String> strs = new List<String>();
            foreach (Invoice i in invoices)
            {
                strs.Add(i.InvoiceDate);
            }

            return strs;
        }

        public List<String> GetcmbTotals()
        {
            List<String> strs = new List<String>();
            foreach (Invoice i in invoices)
            {
                strs.Add(i.TotalPrice + "");
            }

            return strs;
        }

        public List<Invoice> GetActiveInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();
            DataSet ds = sql.GetInvoices();

            int iUNum = 0;
            int iNum = 0;
            String iDate = "";
            double totalPrice;
            int itemID = 0;
            String OrderItem = "";

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                iUNum = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                iNum = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                iDate = ds.Tables[0].Rows[i][2].ToString();
                totalPrice = this.GetInvoiceTotal(Convert.ToString(iNum));
                itemID = Convert.ToInt32(ds.Tables[0].Rows[i][4]);
                OrderItem = Convert.ToString(ds.Tables[0].Rows[i][5].ToString());

                Invoice inv = new Invoice(iUNum, iNum, iDate, totalPrice, itemID, OrderItem);
                invoices.Add(inv);
            }

            return invoices;
        }

        public double GetInvoiceTotal(String ID)
        {
            DataSet ds = sql.GetInvoices();
            double ret = 0;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][1].ToString().Equals(ID))
                {
                    ret += sql.GetItemPrice(ds.Tables[0].Rows[i][4].ToString());
                }
            }
            return ret;
        }

        public List<String> GetInvoiceDates()
        {
            List<String> invoices = new List<String>();
            DataSet ds = sql.GetInvoices();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (!invoices.Contains(ds.Tables[0].Rows[i][2].ToString()))
                {
                    invoices.Add(ds.Tables[0].Rows[i][2].ToString());
                }
            }

            return invoices;
        }

        public List<String> GetInvoiceIDs()
        {
            List<String> invoices = new List<String>();
            DataSet ds = sql.GetInvoices();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (!invoices.Contains(ds.Tables[0].Rows[i][1].ToString())){
                    invoices.Add(ds.Tables[0].Rows[i][1].ToString());
                }
            }

            return invoices;
        }

        public List<String> GetInvoices()
        {
            List<String> invoices = new List<String>();
            DataSet ds = sql.GetInvoices();
            int iNum = 0;
            String iDate = "";
            List<String> items = new List<String>();
            String allItems = "";

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                iNum = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                iDate = ds.Tables[0].Rows[i][2].ToString();
                items = sql.GetInvoiceItems(iNum);
                foreach(String item in items)
                {
                    allItems += item + " ";
                }
                invoices.Add(iNum + " " + iDate + " " + allItems);
                allItems = "";
            }


            return invoices;
        }
    }
}
