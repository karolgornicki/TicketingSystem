using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Data;

namespace TicketingSystem
{
    public partial class Entertainment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["buying"] != null)
            {
                Session["ShoppingCart"] = null;
            }
            if (Session["stage"] == null)
                Response.Redirect("Home.aspx");
            LbHeader.Text = "Statge for " + Session["title"].ToString() + " at " + Convert.ToDateTime(Session["date"]).ToString("MMMM dd, yyyy hh:mm");
            
            switch(Session["stage"].ToString())
            {
                case "Ballet" :
                    // Get data about seats for certain entartainment
                    WsBallet.Service1 wsBallet = new WsBallet.Service1();
                    var seats = wsBallet.GetSeats(Convert.ToDateTime(Session["date"].ToString()), Session["title"].ToString());
                    int seatsIterator = 0;

                    // Disply the stage
                    for (int i = 1; i <= 8; i++)
                    {
                        TableRow trNewRow = new TableRow();
                        for (int j = 1; j <= 9; j++)
                        {
                            bool available;
                            decimal price = 0;

                            // Read data from WS.
                            string row = seats[seatsIterator].ToString().Substring(0, 1);
                            string number = seats[seatsIterator].ToString().Substring(2, 1);
                            if(seats[seatsIterator + 1].ToString().Equals("available"))
                            {
                                available = true;
                                price = Convert.ToDecimal(seats[seatsIterator +2].ToString());
                                // string currency = Session["currency"].ToString();
                                // Recalculate the price.
                                // ...
                            }
                            else
                                available = false;

                            // Create a Cell.
                            TableCell tcNewCell = new TableCell();
                            if (available)
                            {
                                if (IsInCart(Convert.ToDateTime(Session["date"].ToString()), Session["title"].ToString(), Convert.ToInt32(row), Convert.ToInt32(number)))
                                {
                                    tcNewCell.BackColor = Color.Yellow;
                                }
                                else
                                {
                                    tcNewCell.BackColor = Color.LightGray;
                                    Label LbPrice = new Label();
                                    LbPrice.Text = "Price: £" + price.ToString("0.##");
                                    tcNewCell.Controls.Add(LbPrice);
                                    tcNewCell.Controls.Add(new HtmlGenericControl("br"));

                                    Button BtSelect = new Button();
                                    BtSelect.Text = "Select";
                                    BtSelect.ID = "BtSelectB_" + row + "-" + number;
                                    BtSelect.Click += new EventHandler(BtSelectB_Click);
                                    tcNewCell.Controls.Add(BtSelect);
                                }
                                
                            }
                            else
                            {
                                tcNewCell.BackColor = Color.Black;
                            }

                            trNewRow.Cells.Add(tcNewCell);
                            seatsIterator += 3;
                        }
                        TbStage.Rows.Add(trNewRow);
                    }
                    break;

                case "Opera":
                    // Get data about seats for certain entartainment
                    WsOpera.Service1 wsOpera = new WsOpera.Service1();
                    var seatsOpera = wsOpera.GetSeats(Convert.ToDateTime(Session["date"].ToString()), Session["title"].ToString());
                    int seatsIteratorOpera = 0;

                    // Disply the stage
                    for (int i = 1; i <= 8; i++)
                    {
                        TableRow trNewRow = new TableRow();
                        for (int j = 1; j <= 10; j++)
                        {
                            bool available;
                            decimal price = 0;

                            // Read data from WS.
                            string row = seatsOpera[seatsIteratorOpera].ToString().Substring(0, 1);
                            string number = seatsOpera[seatsIteratorOpera].ToString().Substring(2);
                            if (seatsOpera[seatsIteratorOpera + 1].ToString().Equals("available"))
                            {
                                available = true;
                                price = Convert.ToDecimal(seatsOpera[seatsIteratorOpera + 2].ToString());
                                // string currency = Session["currency"].ToString();
                                // Recalculate the price.
                                // ...
                            }
                            else
                                available = false;

                            // Create a Cell.
                            TableCell tcNewCell = new TableCell();
                            if (available)
                            {
                                if (IsInCart(Convert.ToDateTime(Session["date"].ToString()), Session["title"].ToString(), Convert.ToInt32(row), Convert.ToInt32(number)))
                                {
                                    tcNewCell.BackColor = Color.Yellow;
                                }
                                else
                                {
                                    tcNewCell.BackColor = Color.LightGray;

                                    Label LbPrice = new Label();
                                    LbPrice.Text = "Price: £" + price.ToString("0.##");
                                    tcNewCell.Controls.Add(LbPrice);
                                    tcNewCell.Controls.Add(new HtmlGenericControl("br"));

                                    Button BtSelectO = new Button();
                                    BtSelectO.Text = "Select";
                                    BtSelectO.ID = "BtSelectO_" + row + "-" + number;
                                    BtSelectO.Click += new EventHandler(BtSelectO_Click);
                                    tcNewCell.Controls.Add(BtSelectO);
                                }
                            }
                            else
                            {
                                tcNewCell.BackColor = Color.Black;
                            }

                            trNewRow.Cells.Add(tcNewCell);
                            seatsIteratorOpera += 3;
                        }
                        TbStage.Rows.Add(trNewRow);
                    }
                    break;
                case "Theatre":
                    // Get data about seats for certain entartainment
                    WsSmallTheatre.Service1 wsTheatre = new WsSmallTheatre.Service1();
                    var seatsTheatre = wsTheatre.GetSeats(Convert.ToDateTime(Session["date"].ToString()), Session["title"].ToString());
                    int seatsIteratorTheatre = 0;
                    // Disply the stage
                    for (int i = 1; i <= 5; i++)
                    {
                        TableRow trNewRow = new TableRow();
                        for (int j = 1; j <= 8; j++)
                        {
                            bool available;
                            decimal price = 0;

                            // Read data from WS.
                            string row = seatsTheatre[seatsIteratorTheatre].ToString().Substring(0, 1);
                            string number = seatsTheatre[seatsIteratorTheatre].ToString().Substring(2);
                            if (seatsTheatre[seatsIteratorTheatre + 1].ToString().Equals("available"))
                            {
                                available = true;
                                price = Convert.ToDecimal(seatsTheatre[seatsIteratorTheatre + 2].ToString());
                                // string currency = Session["currency"].ToString();
                                // Recalculate the price.
                                // ...
                            }
                            else
                                available = false;

                            // Create a Cell.
                            TableCell tcNewCell = new TableCell();
                            if (available)
                            {
                                if (IsInCart(Convert.ToDateTime(Session["date"].ToString()), Session["title"].ToString(), Convert.ToInt32(row), Convert.ToInt32(number)))
                                {
                                    tcNewCell.BackColor = Color.Yellow;
                                }
                                else
                                {
                                    tcNewCell.BackColor = Color.LightGray;

                                    Label LbPrice = new Label();
                                    LbPrice.Text = "Price: £" + price.ToString("0.##");
                                    tcNewCell.Controls.Add(LbPrice);
                                    tcNewCell.Controls.Add(new HtmlGenericControl("br"));

                                    Button BtSelectT = new Button();
                                    BtSelectT.Text = "Select";
                                    BtSelectT.ID = "BtSelectT_" + row + "-" + number;
                                    BtSelectT.Click += new EventHandler(BtSelectT_Click);
                                    tcNewCell.Controls.Add(BtSelectT);
                                }
                            }
                            else
                            {
                                tcNewCell.BackColor = Color.Black;
                            }

                            trNewRow.Cells.Add(tcNewCell);
                            seatsIteratorTheatre += 3;
                        }
                        TbStage.Rows.Add(trNewRow);
                    }
                    break;
            }
        }
        protected void BtSelectB_Click(object sender, EventArgs e)
        {
            // Indicate cell by different background color.
            int row = Convert.ToInt32(((Button)sender).ID.Substring(10, 1)) - 1;
            int number = Convert.ToInt32(((Button)sender).ID.Substring(12, 1)) - 1;
            if (TbStage.Rows[row].Cells[number].BackColor == Color.Yellow)
                TbStage.Rows[row].Cells[number].BackColor = Color.LightGray;
            else
                TbStage.Rows[row].Cells[number].BackColor = Color.Yellow;
        }

        protected void BtSelectO_Click(object sender, EventArgs e)
        {
            // Indicate cell by different background color.
            int row = Convert.ToInt32(((Button)sender).ID.Substring(10, 1)) - 1;
            int number = Convert.ToInt32(((Button)sender).ID.Substring(12, 1)) - 1;
            if (TbStage.Rows[row].Cells[number].BackColor == Color.Yellow)
                TbStage.Rows[row].Cells[number].BackColor = Color.LightGray;
            else
                TbStage.Rows[row].Cells[number].BackColor = Color.Yellow;
        }

        protected void BtSelectT_Click(object sender, EventArgs e)
        {
            // Indicate cell by different background color.
            int row = Convert.ToInt32(((Button)sender).ID.Substring(10, 1)) - 1;
            int number = Convert.ToInt32(((Button)sender).ID.Substring(12, 1)) - 1;
            if (TbStage.Rows[row].Cells[number].BackColor == Color.Yellow)
                TbStage.Rows[row].Cells[number].BackColor = Color.LightGray;
            else
                TbStage.Rows[row].Cells[number].BackColor = Color.Yellow;
        }

        private bool IsInCart(DateTime date, string title, int row, int number)
        {
            if (Session["ShoppingCart"] != null)
            {
                DataTable DtShoppingCart = (DataTable)Session["ShoppingCart"];
                for (int i = 0; i < DtShoppingCart.Rows.Count; i++)
                {
                    if ((DateTime)DtShoppingCart.Rows[i][1] == date && (string)DtShoppingCart.Rows[i][2] == title && (int)DtShoppingCart.Rows[i][3] == row && (int)DtShoppingCart.Rows[i][4] == number)
                        return true;
                }
            }
            else
                return false;
            return false;
        }

        private void AddToCart(string stage, DateTime date, string title, int row, int number, decimal price)
        {
            DataTable DtShoppingCart = new DataTable();
            DataRow CartItem;
            if (Session["ShoppingCart"] == null)
            {
                DtShoppingCart.Columns.Add("stage");
                DtShoppingCart.Columns.Add("date", System.Type.GetType("System.DateTime"));
                DtShoppingCart.Columns.Add("title");
                DtShoppingCart.Columns.Add("row", System.Type.GetType("System.Int32"));
                DtShoppingCart.Columns.Add("number", System.Type.GetType("System.Int32"));
                DtShoppingCart.Columns.Add("price", System.Type.GetType("System.Decimal"));
                CartItem = DtShoppingCart.NewRow();
                CartItem[0] = stage;
                CartItem[1] = date;
                CartItem[2] = title;
                CartItem[3] = row;
                CartItem[4] = number;
                CartItem[5] = price;
                DtShoppingCart.Rows.Add(CartItem);
            }
            else
            {
                DtShoppingCart = (DataTable)Session["ShoppingCart"];
                CartItem = DtShoppingCart.NewRow();
                CartItem[0] = stage;
                CartItem[1] = date;
                CartItem[2] = title;
                CartItem[3] = row;
                CartItem[4] = number;
                CartItem[5] = price;
                DtShoppingCart.Rows.Add(CartItem);
            }
            Session["ShoppingCart"] = DtShoppingCart;
        }

        private void EraseItemsForEntertainment(string stage, DateTime date, string title)
        {
            if (Session["ShoppingCart"] != null)
            {
                DataTable DtShoppingCart = (DataTable)Session["ShoppingCart"];
                DataTable reply = new DataTable();
                reply.Columns.Add("stage");
                reply.Columns.Add("date", System.Type.GetType("System.DateTime"));
                reply.Columns.Add("title");
                reply.Columns.Add("row", System.Type.GetType("System.Int32"));
                reply.Columns.Add("number", System.Type.GetType("System.Int32"));
                reply.Columns.Add("price", System.Type.GetType("System.Decimal"));
                for (int i = 0; i < DtShoppingCart.Rows.Count; i++)
                {
                    if ((string)DtShoppingCart.Rows[i][0] != stage || (DateTime)DtShoppingCart.Rows[i][1] != date || (string)DtShoppingCart.Rows[i][2] != title)
                        reply.Rows.Add(DtShoppingCart.Rows[i].ItemArray);
                }
                Session["ShoppingCart"] = reply;
            }
        }

        protected void BtUpdateCart_Click(object sender, EventArgs e)
        {
            int rowsQty = TbStage.Rows.Count;
            int numbersQty = TbStage.Rows[0].Cells.Count;
            EraseItemsForEntertainment(Session["stage"].ToString(), Convert.ToDateTime(Session["date"].ToString()), Session["title"].ToString());
            for (int i = 1; i <= rowsQty; i++)
            {
                for (int j = 1; j <= numbersQty; j++)
                {
                    if (TbStage.Rows[i-1].Cells[j-1].BackColor == Color.Yellow)
                    {
                        decimal price = 0;
                        if ((string)Session["stage"] == "Ballet")
                        {
                            WsBallet.Service1 wsBallet = new WsBallet.Service1();
                            var seats = wsBallet.GetSeats(Convert.ToDateTime(Session["date"].ToString()), Session["title"].ToString());
                            price = Convert.ToDecimal(seats[((i - 1) * 9 + j) * 3 - 1]);
                        }
                        else if ((string)Session["stage"] == "Opera")
                        {
                            WsOpera.Service1 wsOpera = new WsOpera.Service1();
                            var seats = wsOpera.GetSeats(Convert.ToDateTime(Session["date"].ToString()), Session["title"].ToString());
                            price = Convert.ToDecimal(seats[((i - 1) * 10 + j) * 3 - 1]);
                        }
                        else if ((string)Session["stage"] == "Theatre")
                        {
                            WsSmallTheatre.Service1 wsTheatre = new WsSmallTheatre.Service1();
                            var seats = wsTheatre.GetSeats(Convert.ToDateTime(Session["date"].ToString()), Session["title"].ToString());
                            price = Convert.ToDecimal(seats[((i - 1) * 8 + j) * 3 - 1]);
                        }
                        AddToCart(Session["stage"].ToString(), Convert.ToDateTime(Session["date"].ToString()), Session["title"].ToString(), i, j, price);
                    }
                }
            }
            Response.Redirect("ShoppingCart.aspx");
        }   
    }
}