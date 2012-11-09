using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TicketingSystem
{
    public partial class EntBallet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["buying"] != null)
            {
                Session["ShoppingCart"] = null;
            }
            DateTime date;

            if (Session["date"] == null)
            {
                date = DateTime.Now;
                Session["date"] = date;
            }
            else
            {
                if (Session["stage"] != null)
                {
                    if (Session["stage"].Equals("Ballet"))
                        date = Convert.ToDateTime(Session["date"]);
                    else
                    {
                        date = DateTime.Now;
                        Session["date"] = date;
                    }
                }
                else
                {
                    date = DateTime.Now;
                    Session["date"] = date;
                }
            }

            LbHeader.Text = "Repertoire for the ballet in " + date.ToString("MMMM");

            WsBallet.Service1 wsBallet = new WsBallet.Service1();
            WsOpera.Service1 wsOpera = new WsOpera.Service1();
            WsSmallTheatre.Service1 wsTheatre = new WsSmallTheatre.Service1();
            DataRow singleEvent;

            DataTable DtSchedule = new DataTable();
            DtSchedule.Columns.Add("Title");
            DtSchedule.Columns.Add("Date", System.Type.GetType("System.DateTime"));
            DtSchedule.Columns.Add("Runtime", System.Type.GetType("System.Int32"));
            DtSchedule.Columns.Add("OpenSeats", System.Type.GetType("System.Int32"));

            var scheduleBallet = wsBallet.GetScheduleForAMonth(date);
            if (scheduleBallet != null)
            {
                for (int i = 0; i < scheduleBallet.Length / 4; i++)
                {
                    int y = i * 4;
                    singleEvent = DtSchedule.NewRow();
                    singleEvent[0] = scheduleBallet[y];
                    singleEvent[1] = Convert.ToDateTime(scheduleBallet[y + 1]);
                    singleEvent[2] = Convert.ToInt32(scheduleBallet[y + 2]);
                    singleEvent[3] = Convert.ToInt32(scheduleBallet[y + 3]);
                    DtSchedule.Rows.Add(singleEvent);
                }
            }

            GvEntBallet.DataSource = DtSchedule;
            GvEntBallet.DataBind();
        }

        protected void GvEntBallet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Select"))
            {
                int rowNumber = Convert.ToInt32(e.CommandArgument.ToString());
                Session["date"] = GvEntBallet.Rows[rowNumber].Cells[0].Text;
                Session["stage"] = "Ballet";
                Session["title"] = GvEntBallet.Rows[rowNumber].Cells[1].Text;
                Response.Redirect("Entertainment.aspx");
            }
        }

        protected void BtPreviousMonth_Click(object sender, EventArgs e)
        {
            DateTime current = Convert.ToDateTime(Session["date"]);
            Session["date"] = current.AddMonths(-1);
            Session["stage"] = "Ballet";
            Response.Redirect("EntBallet.aspx");
        }

        protected void BtNextMonth_Click(object sender, EventArgs e)
        {
            DateTime current = Convert.ToDateTime(Session["date"]);
            Session["date"] = current.AddMonths(1);
            Session["stage"] = "Ballet";
            Response.Redirect("EntBallet.aspx");
        }
    }
}