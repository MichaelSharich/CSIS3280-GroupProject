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

        public clsSearchLogic()
        {

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
                iNum = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                iDate = ds.Tables[0].Rows[i][1].ToString();
                items = sql.GetInvoiceItems(iNum);
                foreach(String item in items)
                {
                    allItems = allItems + item;
                }
                invoices.Add(iNum + " " + iDate + " " + allItems);
            }


            return invoices;
        }
    }
}
