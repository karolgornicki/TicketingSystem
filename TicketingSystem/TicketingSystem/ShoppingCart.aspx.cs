using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TicketingSystem
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        decimal total;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["buying"] != null)
            {
                Session["ShoppingCart"] = null;
            }
            DataTable DtShoppingCart = (DataTable)Session["ShoppingCart"];
            GvShoppingCart.DataSource = DtShoppingCart;
            GvShoppingCart.DataBind();
            total = 0;
            if (DtShoppingCart != null)
            {
                for (int i = 0; i < DtShoppingCart.Rows.Count; i++)
                {
                    total += Convert.ToDecimal(DtShoppingCart.Rows[i][5].ToString());
                }
            }

            LbHeader.Text = "Shopping cart";
            LbTotal.Text = "Total: " + total.ToString("0.##") + " GBP";

        }

        protected void GvShoppingCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                updateDataBase(Convert.ToInt32(e.CommandArgument.ToString()));
            }
        }

        private void updateDataBase(int rowNumber)
        {
            DataTable MyDT_X = (DataTable)Session["ShoppingCart"];
            MyDT_X.Rows[rowNumber].Delete();
            Session["ShoppingCart"] = MyDT_X;
            Response.Redirect("shoppingCart.aspx");
        }

        protected void BtCheckout_Click(object sender, EventArgs e)
        {
            Session["total"] = total;
            Response.Redirect("Confirmation.aspx");
        }

        protected void BtRecalculate_Click(object sender, EventArgs e)
        {
            string result = Recalculation.Calculate("GBP", DdlCurrency.SelectedValue, total.ToString());
            decimal y = Convert.ToDecimal(result);
            LbTotal.Text = "Total: " + y.ToString("0.##") + DdlCurrency.SelectedValue;
        }
    }
}