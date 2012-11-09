using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace TicketingSystem
{
    public partial class Confirmation : System.Web.UI.Page
    {
        DateTime dateOfOrder;
        string ordersCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            ordersCode = null;
            if (Session["date"] == null)
                Response.Redirect("Home.aspx");

            RbCardList.SelectedIndex = 0;
            DateTime currentDate = DateTime.Now;

            DDlExpiryYear.Items.Add(currentDate.Year.ToString());
            DDlExpiryYear.Items.Add(currentDate.AddYears(1).Year.ToString());
            DDlExpiryYear.Items.Add(currentDate.AddYears(2).Year.ToString());
            DDlExpiryYear.Items.Add(currentDate.AddYears(3).Year.ToString());
            DDlExpiryYear.Items.Add(currentDate.AddYears(4).Year.ToString());
            DDlExpiryYear.Items.Add(currentDate.AddYears(5).Year.ToString());
            DDlExpiryYear.Items.Add(currentDate.AddYears(6).Year.ToString());
            DDlExpiryYear.Items.Add(currentDate.AddYears(7).Year.ToString());
            DDlExpiryYear.Items.Add(currentDate.AddYears(8).Year.ToString());
            DDlExpiryYear.Items.Add(currentDate.AddYears(9).Year.ToString());
            DDlExpiryYear.Items.Add(currentDate.AddYears(10).Year.ToString());

            DDlStartYear.Items.Add(currentDate.Year.ToString());
            DDlStartYear.Items.Add(currentDate.AddYears(-1).Year.ToString());
            DDlStartYear.Items.Add(currentDate.AddYears(-2).Year.ToString());
            DDlStartYear.Items.Add(currentDate.AddYears(-3).Year.ToString());
            DDlStartYear.Items.Add(currentDate.AddYears(-4).Year.ToString());
            DDlStartYear.Items.Add(currentDate.AddYears(-5).Year.ToString());
        }
        private string CodeGenerator()
        {
            int stringLength = 10;

            Random rnd = new Random((int)System.DateTime.Now.Ticks);
            System.Text.StringBuilder randomText = new System.Text.StringBuilder(stringLength);

            int minValue = 65;
            int maxValue = 90;
            int randomRange = maxValue - minValue;
            double rndValue;

            for (int i = 0; i < stringLength; i++)
            {
                rndValue = rnd.NextDouble();
                randomText.Append((char)(minValue + rndValue * randomRange));
            }

            return randomText.ToString();
        }

        protected void BtCheckout_Click(object sender, EventArgs e)
        {
            string result = "";

            // Booking all events (from Session).
            DataTable DtShoppingCart = (DataTable)Session["ShoppingCart"];
            if(Session["ShoppingCart"] != null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DbOrdersConnectionString"].ToString();
                MapDbOrdersDataContext dataContext = new MapDbOrdersDataContext(connectionString);

                Invoice newInvoice = new Invoice();
                dateOfOrder = newInvoice.Date = DateTime.Now;
                newInvoice.CustomerName = TxCardHolder.Text;
                ordersCode = newInvoice.Code = CodeGenerator();
                newInvoice.Subtotal = Convert.ToDecimal(Session["total"].ToString());

                dataContext.Invoices.InsertOnSubmit(newInvoice);
                dataContext.SubmitChanges();
                
                for (int i = 0; i < DtShoppingCart.Rows.Count; i++)
                {
                    switch (DtShoppingCart.Rows[i][0].ToString())
                    {
                        case "Ballet":
                            WsBallet.Service1 wsBallet = new WsBallet.Service1();
                            result = wsBallet.BookSeat(Convert.ToDateTime(DtShoppingCart.Rows[i][1].ToString()),
                                DtShoppingCart.Rows[i][2].ToString(), Convert.ToInt32(DtShoppingCart.Rows[i][3].ToString()),
                                Convert.ToInt32(DtShoppingCart.Rows[i][4].ToString()), TxCardHolder.Text);
                            if (result.Equals("Fail"))
                                LbError.Text += " System coud not book seat for '" + DtShoppingCart.Rows[i][2].ToString() + "row: "
                                    + DtShoppingCart.Rows[i][3].ToString() + " number: " + DtShoppingCart.Rows[i][4].ToString() + ".\n";
                            else
                            {
                                InvoiceLine newInvoiceLine = new InvoiceLine();
                                newInvoiceLine.InvoiceID = newInvoice.InvoiceID;
                                newInvoiceLine.Organizer = DtShoppingCart.Rows[i][0].ToString();
                                newInvoiceLine.DateOfEvent = Convert.ToDateTime(DtShoppingCart.Rows[i][1].ToString());
                                newInvoiceLine.Title = DtShoppingCart.Rows[i][2].ToString();
                                newInvoiceLine.Row = Convert.ToInt32(DtShoppingCart.Rows[i][3].ToString());
                                newInvoiceLine.Number = Convert.ToInt32(DtShoppingCart.Rows[i][4].ToString());
                                newInvoiceLine.Price = Convert.ToDecimal(DtShoppingCart.Rows[i][5].ToString());

                                dataContext.InvoiceLines.InsertOnSubmit(newInvoiceLine);
                                dataContext.SubmitChanges();
                            }
                            break;

                        case "Opera":
                            WsOpera.Service1 wsOpera = new WsOpera.Service1();
                            result = wsOpera.BookSeat(Convert.ToDateTime(DtShoppingCart.Rows[i][1].ToString()),
                                DtShoppingCart.Rows[i][2].ToString(), Convert.ToInt32(DtShoppingCart.Rows[i][3].ToString()),
                                Convert.ToInt32(DtShoppingCart.Rows[i][4].ToString()), TxCardHolder.Text);
                            if (result.Equals("Fail"))
                                LbError.Text += " System coud not book seat for '" + DtShoppingCart.Rows[i][2].ToString() + "row: "
                                    + DtShoppingCart.Rows[i][3].ToString() + " number: " + DtShoppingCart.Rows[i][4].ToString() + ".\n";
                            else
                            {
                                InvoiceLine newInvoiceLine = new InvoiceLine();
                                newInvoiceLine.InvoiceID = newInvoice.InvoiceID;
                                newInvoiceLine.Organizer = DtShoppingCart.Rows[i][0].ToString();
                                newInvoiceLine.DateOfEvent = Convert.ToDateTime(DtShoppingCart.Rows[i][1].ToString());
                                newInvoiceLine.Title = DtShoppingCart.Rows[i][2].ToString();
                                newInvoiceLine.Row = Convert.ToInt32(DtShoppingCart.Rows[i][3].ToString());
                                newInvoiceLine.Number = Convert.ToInt32(DtShoppingCart.Rows[i][4].ToString());
                                newInvoiceLine.Price = Convert.ToDecimal(DtShoppingCart.Rows[i][5].ToString());

                                dataContext.InvoiceLines.InsertOnSubmit(newInvoiceLine);
                                dataContext.SubmitChanges();
                            }
                            break;

                        case "Theatre":
                            WsSmallTheatre.Service1 wsTheatre = new WsSmallTheatre.Service1();
                            result = wsTheatre.BookSeat(Convert.ToDateTime(DtShoppingCart.Rows[i][1].ToString()),
                                DtShoppingCart.Rows[i][2].ToString(), Convert.ToInt32(DtShoppingCart.Rows[i][3].ToString()),
                                Convert.ToInt32(DtShoppingCart.Rows[i][4].ToString()), TxCardHolder.Text);
                            if (result.Equals("Fail"))
                                LbError.Text += " System coud not book seat for '" + DtShoppingCart.Rows[i][2].ToString() + "row: "
                                    + DtShoppingCart.Rows[i][3].ToString() + " number: " + DtShoppingCart.Rows[i][4].ToString() + ".\n";
                            else
                            {
                                InvoiceLine newInvoiceLine = new InvoiceLine();
                                newInvoiceLine.InvoiceID = newInvoice.InvoiceID;
                                newInvoiceLine.Organizer = DtShoppingCart.Rows[i][0].ToString();
                                newInvoiceLine.DateOfEvent = Convert.ToDateTime(DtShoppingCart.Rows[i][1].ToString());
                                newInvoiceLine.Title = DtShoppingCart.Rows[i][2].ToString();
                                newInvoiceLine.Row = Convert.ToInt32(DtShoppingCart.Rows[i][3].ToString());
                                newInvoiceLine.Number = Convert.ToInt32(DtShoppingCart.Rows[i][4].ToString());
                                newInvoiceLine.Price = Convert.ToDecimal(DtShoppingCart.Rows[i][5].ToString());

                                dataContext.InvoiceLines.InsertOnSubmit(newInvoiceLine);
                                dataContext.SubmitChanges();
                            }
                            break;
                    }
                }
            }
            if (LbError.Text.Equals(""))
            {
                Session["CardHolder"] = TxCardHolder.Text;
                Session["DateOfOrder"] = dateOfOrder;
                Session["Code"] = ordersCode;
                Response.Redirect("ThankYou.aspx");
            }
            else
            {
                Session.Clear();
                LbMessage.Text = "All remains orders has been proceeded successfully. Pleac contact staff for details.";
                BtCheckout.Visible = false;
            }
        }
    }
}