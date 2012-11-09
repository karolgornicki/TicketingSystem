using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace TicketingSystem
{
    public partial class RepertoireForADay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["buying"] != null)
            {
                Session["ShoppingCart"] = null;
            }
            string date = (string)Session["date"];
            WsBallet.Service1 wsBallet = new WsBallet.Service1();
            WsOpera.Service1 wsOpera = new WsOpera.Service1();
            WsSmallTheatre.Service1 wsTheatre = new WsSmallTheatre.Service1();
            DataRow singleEvent;

            // Get schedul for Ballet.
            var scheduleBallet = wsBallet.GetScheduleForDate(Convert.ToDateTime(date));
            DataTable DtScheduleBallet = new DataTable();

            DtScheduleBallet.Columns.Add("Title");
            DtScheduleBallet.Columns.Add("Date", System.Type.GetType("System.DateTime"));
            DtScheduleBallet.Columns.Add("Runtime", System.Type.GetType("System.Int32"));
            DtScheduleBallet.Columns.Add("OpenSeats", System.Type.GetType("System.Int32"));

            if (scheduleBallet != null)
            {
                for (int i = 0; i < scheduleBallet.Length/8; i++)
                {
                    int y = i * 8;
                    singleEvent = DtScheduleBallet.NewRow();
                    singleEvent[0] = scheduleBallet[y];
                    singleEvent[1] = Convert.ToDateTime(scheduleBallet[y + 1]);
                    singleEvent[2] = Convert.ToInt32(scheduleBallet[y + 6]);
                    singleEvent[3] = Convert.ToInt32(scheduleBallet[y + 7]);
                    DtScheduleBallet.Rows.Add(singleEvent);
                }
            }

            // Get schedule for Opera.
            var scheduleOpera = wsOpera.GetScheduleForDate(Convert.ToDateTime(date));
            DataTable DtScheduleOpera = new DataTable();

            DtScheduleOpera.Columns.Add("Title");
            DtScheduleOpera.Columns.Add("Date", System.Type.GetType("System.DateTime"));
            DtScheduleOpera.Columns.Add("Runtime", System.Type.GetType("System.Int32"));
            DtScheduleOpera.Columns.Add("OpenSeats", System.Type.GetType("System.Int32"));

            if (scheduleOpera != null)
            {
                for (int i = 0; i < scheduleOpera.Length/6; i++)
                {
                    int y = i * 6;
                    singleEvent = DtScheduleOpera.NewRow();
                    singleEvent[0] = scheduleOpera[y];
                    singleEvent[1] = Convert.ToDateTime(scheduleOpera[y + 1]);
                    singleEvent[2] = Convert.ToInt32(scheduleOpera[y + 4]);
                    singleEvent[3] = Convert.ToInt32(scheduleOpera[y + 5]);
                    DtScheduleOpera.Rows.Add(singleEvent);
                }
            }

            // Get schedule for Theatre.
            var scheduleTheatre = wsTheatre.GetScheduleForDate(Convert.ToDateTime(date));
            DataTable DtScheduleTheatre = new DataTable();

            DtScheduleTheatre.Columns.Add("Title");
            DtScheduleTheatre.Columns.Add("Date", System.Type.GetType("System.DateTime"));
            DtScheduleTheatre.Columns.Add("Runtime", System.Type.GetType("System.Int32"));
            DtScheduleTheatre.Columns.Add("OpenSeats", System.Type.GetType("System.Int32"));

            if (scheduleTheatre != null)
            {
                for (int i = 0; i < scheduleTheatre.Length/6; i++)
                {
                    int y = i * 6;
                    singleEvent = DtScheduleTheatre.NewRow();
                    singleEvent[0] = scheduleTheatre[y];
                    singleEvent[1] = Convert.ToDateTime(scheduleTheatre[y + 1]);
                    singleEvent[2] = Convert.ToInt32(scheduleTheatre[y + 4]);
                    singleEvent[3] = Convert.ToInt32(scheduleTheatre[y + 5]);
                    DtScheduleTheatre.Rows.Add(singleEvent);
                }
            }

            GvBallet.DataSource = DtScheduleBallet;
            GvBallet.DataBind();

            GvOpera.DataSource = DtScheduleOpera;
            GvOpera.DataBind();

            GvTheatre.DataSource = DtScheduleTheatre;
            GvTheatre.DataBind();
        }
        
        protected void GvBallet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Select"))
            {
                int rowNumber = Convert.ToInt32(e.CommandArgument.ToString());
                Session["date"] = GvBallet.Rows[rowNumber].Cells[1].Text;
                Session["stage"] = "Ballet";
                Session["title"] = GvBallet.Rows[rowNumber].Cells[0].Text;
                Response.Redirect("Entertainment.aspx");
            }
        }

        protected void GvOpera_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Select"))
            {
                int rowNumber = Convert.ToInt32(e.CommandArgument.ToString());
                Session["date"] = GvOpera.Rows[rowNumber].Cells[1].Text;
                Session["stage"] = "Opera";
                Session["title"] = GvOpera.Rows[rowNumber].Cells[0].Text;
                Response.Redirect("Entertainment.aspx");
            }
        }

        protected void GvTheatre_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Select"))
            {
                int rowNumber = Convert.ToInt32(e.CommandArgument.ToString());
                Session["date"] = GvTheatre.Rows[rowNumber].Cells[1].Text;
                Session["stage"] = "Theatre";
                Session["title"] = GvTheatre.Rows[rowNumber].Cells[0].Text;
                Response.Redirect("Entertainment.aspx");
            }
        }
    }
    
}