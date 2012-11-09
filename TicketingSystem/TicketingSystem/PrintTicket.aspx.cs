using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace TicketingSystem
{
    public partial class PrintTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LbError.Visible = false;
        }

        protected void BbRun_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbOrdersConnectionString"].ToString();
            MapDbOrdersDataContext dataContext = new MapDbOrdersDataContext(connectionString);

            if (dataContext.Invoices.Where(x => x.Code == TxCode.Text).Count() != 0)
            {
                Session["code"] = TxCode.Text;
                Response.Redirect("Print.aspx");
            }
            else
                LbError.Visible = true;
        }
    }
}