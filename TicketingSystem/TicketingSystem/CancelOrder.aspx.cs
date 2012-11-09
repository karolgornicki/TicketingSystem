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
    public partial class CancelOrder : System.Web.UI.Page
    {
        DataTable orders = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            LbHeader.Text = "Cancel entertainments from order number: " + Session["code"].ToString();
            LbInfo.Visible = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DbOrdersConnectionString"].ToString();
            MapDbOrdersDataContext dataContext = new MapDbOrdersDataContext(connectionString);

            DataRow ordersEntity;
            
            orders.Columns.Add("date", System.Type.GetType("System.DateTime"));
            orders.Columns.Add("title");
            orders.Columns.Add("row", System.Type.GetType("System.Int32"));
            orders.Columns.Add("number", System.Type.GetType("System.Int32"));

            int invoiceID = dataContext.Invoices.Where(x => x.Code == (string)Session["code"]).Select(y => y.InvoiceID).First();

            var orderItems = dataContext.InvoiceLines.Where(x => x.InvoiceID == invoiceID);

            foreach (var item in orderItems)
            {
                ordersEntity = orders.NewRow();
                ordersEntity[0] = item.DateOfEvent;
                ordersEntity[1] = item.Title;
                ordersEntity[2] = item.Row;
                ordersEntity[3] = item.Number;
                orders.Rows.Add(ordersEntity);
            }

            GvOrders.DataSource = orders;
            GvOrders.DataBind();
        }

        protected void GvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                updateDataBase(Convert.ToInt32(e.CommandArgument.ToString()));
            }
        }

        private void updateDataBase(int rowNumber)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbOrdersConnectionString"].ToString();
            MapDbOrdersDataContext dataContext = new MapDbOrdersDataContext(connectionString);


            int invoiceID = dataContext.Invoices.Where(x => x.Code == (string)Session["code"]).Select(y => y.InvoiceID).First();

            //var record = dataContext.InvoiceLines.Where(x => x.InvoiceID == invoiceID &&
            //    x.DateOfEvent == Convert.ToDateTime(GvOrders.Rows[rowNumber].Cells[0]) &&
            //    x.Row == Convert.ToInt32(GvOrders.Rows[rowNumber].Cells[2]) &&
            //    x.Number == Convert.ToInt32(GvOrders.Rows[rowNumber].Cells[3]) &&
            //    x.Title == GvOrders.Rows[rowNumber].Cells[1].ToString()).First();

            if (Convert.ToDateTime(orders.Rows[rowNumber][0]).AddDays(10) < DateTime.Now)
            {
                var record = dataContext.InvoiceLines.Where(x => x.InvoiceID == invoiceID &&
                    x.DateOfEvent == Convert.ToDateTime(orders.Rows[rowNumber][0]) &&
                    x.Row == Convert.ToInt32(orders.Rows[rowNumber][2]) &&
                    x.Number == Convert.ToInt32(orders.Rows[rowNumber][3]) &&
                    x.Title == orders.Rows[rowNumber][1].ToString()).First();

                switch (record.Organizer)
                {
                    case "Ballet":
                        WsBallet.Service1 wsBallet = new WsBallet.Service1();
                        string result = wsBallet.CancelReservation(Convert.ToDateTime(orders.Rows[rowNumber][0]),
                            orders.Rows[rowNumber][1].ToString(),
                            Convert.ToInt32(orders.Rows[rowNumber][2]),
                            Convert.ToInt32(orders.Rows[rowNumber][3]));
                        // Maybe some information occured any problems...?
                        break;

                    case "Opera":
                        WsOpera.Service1 wsOpera = new WsOpera.Service1();
                        string result2 = wsOpera.CancelReservation(Convert.ToDateTime(orders.Rows[rowNumber][0]),
                            orders.Rows[rowNumber][1].ToString(),
                            Convert.ToInt32(orders.Rows[rowNumber][2]),
                            Convert.ToInt32(orders.Rows[rowNumber][3]));
                        // Maybe some information occured any problems...?
                        // Mark certain seat as available.
                        break;

                    case "Theatre":
                        WsSmallTheatre.Service1 wsTheatre = new WsSmallTheatre.Service1();
                        string result3 = wsTheatre.CancelReservation(Convert.ToDateTime(orders.Rows[rowNumber][0]),
                            orders.Rows[rowNumber][1].ToString(),
                            Convert.ToInt32(orders.Rows[rowNumber][2]),
                            Convert.ToInt32(orders.Rows[rowNumber][3]));
                        // Maybe some information occured any problems...?
                        break;
                }

                dataContext.InvoiceLines.DeleteOnSubmit(record);
                dataContext.SubmitChanges();

                Response.Redirect("CancelOrder.aspx");
            }
            else 
            {
                LbInfo.Text = "This reservation cannot be canceled.";
                LbInfo.Visible = true;
            }
        }
    }
}