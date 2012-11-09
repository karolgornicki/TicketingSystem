using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace TicketingSystem
{
    public partial class Print : System.Web.UI.Page
    {
        DataTable DtShoppingCart;
        string cardHolder, code;
        DateTime dateOfOrder;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void SendOutPDF(System.IO.MemoryStream PDFData)
        {
            // Clear response content & headers
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.Charset = string.Empty;
            Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
            Response.AddHeader("Content-Disposition",
                "attachment; filename=Ticket.pdf");

            Response.OutputStream.Write(PDFData.GetBuffer(), 0, PDFData.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.End();
        }

        protected void BtPrint_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbOrdersConnectionString"].ToString();
            MapDbOrdersDataContext dataContext = new MapDbOrdersDataContext(connectionString);

            DataTable DtShoppingCart = new DataTable();
            DataRow CartItem;

            DtShoppingCart.Columns.Add("stage");
            DtShoppingCart.Columns.Add("date", System.Type.GetType("System.DateTime"));
            DtShoppingCart.Columns.Add("title");
            DtShoppingCart.Columns.Add("row", System.Type.GetType("System.Int32"));
            DtShoppingCart.Columns.Add("number", System.Type.GetType("System.Int32"));

            var invoiceID = dataContext.Invoices.Where(x => x.Code == Session["code"].ToString()).Select(y => y.InvoiceID).First();

            var contents = dataContext.InvoiceLines.Where(x => x.InvoiceID == invoiceID);

            foreach (var item in contents)
            {
                CartItem = DtShoppingCart.NewRow();
                CartItem[0] = item.Organizer;
                CartItem[1] = item.DateOfEvent;
                CartItem[2] = item.Title;
                CartItem[3] = item.Row;
                CartItem[4] = item.Number;
                DtShoppingCart.Rows.Add(CartItem);
            }

            //DtShoppingCart = (DataTable)Session["ShoppingCart"];
            cardHolder = dataContext.Invoices.Where(x => x.Code == Session["code"].ToString()).Select(y => y.CustomerName).Single();
            code = Session["Code"].ToString();
            dateOfOrder = dataContext.Invoices.Where(x => x.Code == Session["code"].ToString()).Select(y => y.Date).Single();
            Session.Clear();
            SendOutPDF(new Ticket().CreatePDF(DtShoppingCart, cardHolder, dateOfOrder, code));
        }
    }
}