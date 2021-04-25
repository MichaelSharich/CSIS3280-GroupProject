using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
            try
            {
                invoices = this.GetActiveInvoices();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                            "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// public void FilterInvoice(String inv)
        /// 
        ///             Filter static invoice list
        /// </summary>
        /// <param name="inv"></param>
        public void FilterInvoice(String inv)
        {
            try
            {
                List<Invoice> tempinv = new List<Invoice>();
                foreach (Invoice i in invoices)
                {
                    if (Convert.ToString(i.InvoiceID).Equals(inv))
                    {
                        tempinv.Add(i);
                    }
                }
                invoices = tempinv;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                            "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// public void FilterDate(String inv) -
        /// 
        ///             Filter static invoices based on date
        /// </summary>
        /// <param name="inv"></param>
        public void FilterDate(String inv)
        {
            try
            {
                List<Invoice> tempinv = new List<Invoice>();
                foreach (Invoice i in invoices)
                {
                    if ((i.InvoiceDate.Equals(inv)))
                    {
                        tempinv.Add(i);
                    }
                }
                invoices = tempinv;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                            "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// public void FilterTotal(double inv)
        /// 
        ///            Filter static invoices based on Total
        /// </summary>
        /// <param name="inv"></param>
        public void FilterTotal(double inv)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                            "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// public List<String> GetcmbInvoices() - Get just invoiceID for combo box
        /// </summary>
        /// <returns></returns>
        public List<String> GetcmbInvoices()
        {
            try
            {
                List<String> strs = new List<String>();
                foreach (Invoice i in invoices)
                {
                    strs.Add(i.InvoiceID + "");
                }

                return strs;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                            "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// public List<String> GetcmbDates() -
        /// 
        ///             Get dates for combo box
        /// </summary>
        /// <returns></returns>
        public List<String> GetcmbDates()
        {
            try
            {
                List<String> strs = new List<String>();
                foreach (Invoice i in invoices)
                {
                    strs.Add(i.InvoiceDate);
                }

                return strs;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                            "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// public List<String> GetcmbTotals() -
        /// 
        ///             Get totals for combo box
        /// </summary>
        /// <returns></returns>
        public List<String> GetcmbTotals() {

            try
            {
                List<String> strs = new List<String>();
                foreach (Invoice i in invoices)
                {
                    strs.Add(i.TotalPrice + "");
                }

                return strs;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                            "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// public List<Invoice> GetActiveInvoices() -
        /// 
        ///             Get all invoices from static invoices
        /// </summary>
        /// <returns></returns>
        public List<Invoice> GetActiveInvoices()
        {
            try
            {
                // Used to store invoices;
                List<Invoice> invoices = new List<Invoice>();
                //Fill dataset with all invoices
                DataSet ds = sql.GetInvoices();

                // Fields for creating invoice object
                int iUNum = 0;
                int iNum = 0;
                String iDate = "";
                double totalPrice;
                int itemID = 0;
                String OrderItem = "";

                //For each row create an invoice object
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
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name +
                            "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// public double GetInvoiceTotal(String ID) -
        /// 
        ///             Get total for invoiceID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
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
    }
}
