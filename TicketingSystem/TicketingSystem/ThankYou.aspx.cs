using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TicketingSystem
{
    public partial class ThankYou : System.Web.UI.Page
    {
        DataTable DtShoppingCart;
        string cardHolder, code;
        DateTime dateOfOrder;

        protected void Page_Load(object sender, EventArgs e)
        {
            DtShoppingCart = (DataTable)Session["ShoppingCart"];
            cardHolder = Session["CardHolder"].ToString();
            code = Session["Code"].ToString();
            dateOfOrder = Convert.ToDateTime(Session["DateOfOrder"].ToString());
            Session["buyiny"] = "done";
            //Session.Clear();
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
            Session.Clear();
            SendOutPDF(new Ticket().CreatePDF(DtShoppingCart, cardHolder, dateOfOrder, code));
        }
    }
}