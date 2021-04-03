using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProjectWPF.Search
{
    class clsSearchLogic
    {
        clsSearchSQL sql = new clsSearchSQL();
        List<String> FilteredList = new List<String>();

        public clsSearchLogic()
        {

        }

        public List<String> GetInvoicesWhere(String x)
        {
            List<String> invoices = new List<String>();
            DataSet ds = sql.GetWhereX(x);
            int iNum = 0;
            String iDate = "";
            List<String> items = new List<String>();
            String allItems = "";

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                iNum = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                iDate = ds.Tables[0].Rows[i][2].ToString();
                items = sql.GetInvoiceItems(iNum);
                foreach (String item in items)
                {
                    allItems += item + " ";
                }
                invoices.Add(iNum + " " + iDate + " " + allItems);
                allItems = "";
            }


            return invoices;
        }

        public List<String> GetInvoicesIDSWhere(String x)
        {
            List<String> invoices = new List<String>();
            DataSet ds = sql.GetIDWhereX(x);
            int iNum = 0;
            String iDate = "";
            List<String> items = new List<String>();
            String allItems = "";

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                iNum = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                invoices.Add(Convert.ToString(iNum));
            }

            return invoices;
        }

        public List<String> GetTotalCostList()
        {
            List<String> invoices = new List<String>();
            DataSet ds = sql.GetInvoices();
            List<Tuple<String, int>> Entries = new List<Tuple<String, int>>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Entries.Add(new Tuple<String, int>(ds.Tables[0].Rows[i][1].ToString(), Convert.ToInt32(ds.Tables[0].Rows[i][4].ToString())));
            }

            double total = 0;
            foreach (Tuple<String, int> d in Entries)
            {
                if (!invoices.Contains(d.Item1)){
                    total = GetInvoiceTotal(d.Item1);
                    String str = d.Item1 + " - " + total;
                    invoices.Add(str);
                }
            }
            invoices = invoices.Distinct().ToList();

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
