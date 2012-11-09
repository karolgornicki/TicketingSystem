using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TicketingSystem
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["buying"] != null)
            {
                Session["ShoppingCart"] = null;
            }
            Session["date"] = null;
            WsBallet.Service1 wsBallet = new WsBallet.Service1();
            WsOpera.Service1 wsOpera = new WsOpera.Service1();
            WsSmallTheatre.Service1 wsTheatre = new WsSmallTheatre.Service1();
            DataRow singleEvent;
            DataTable DtSchedule = new DataTable();

            DtSchedule.Columns.Add("Org");
            DtSchedule.Columns.Add("Title");
            DtSchedule.Columns.Add("Date", System.Type.GetType("System.DateTime"));
            DtSchedule.Columns.Add("Runtime", System.Type.GetType("System.Int32"));
            DtSchedule.Columns.Add("OpenSeats", System.Type.GetType("System.Int32"));

            var scheduleBallet = wsBallet.Get3EarliestEntertainment(DateTime.Now);
            if (scheduleBallet != null)
            {
                for (int i = 0; i < scheduleBallet.Length / 4; i++)
                {
                    int y = i * 4;
                    singleEvent = DtSchedule.NewRow();
                    singleEvent[0] = "Ballet";
                    singleEvent[1] = scheduleBallet[y];
                    singleEvent[2] = Convert.ToDateTime(scheduleBallet[y + 1]);
                    singleEvent[3] = Convert.ToInt32(scheduleBallet[y + 2]);
                    singleEvent[4] = Convert.ToInt32(scheduleBallet[y + 3]);
                    DtSchedule.Rows.Add(singleEvent);
                }
            }

            var scheduleOpera = wsOpera.Get3EarliestEntertainment(DateTime.Now);
            if (scheduleOpera != null)
            {
                for (int i = 0; i < scheduleOpera.Length / 4; i++)
                {
                    int y = i * 4;
                    singleEvent = DtSchedule.NewRow();
                    singleEvent[0] = "Opera";
                    singleEvent[1] = scheduleOpera[y];
                    singleEvent[2] = Convert.ToDateTime(scheduleOpera[y + 1]);
                    singleEvent[3] = Convert.ToInt32(scheduleOpera[y + 2]);
                    singleEvent[4] = Convert.ToInt32(scheduleOpera[y + 3]);
                    DtSchedule.Rows.Add(singleEvent);
                }
            }

            var scheduleTheatre = wsTheatre.Get3EarliestEntertainment(DateTime.Now);
            if (scheduleTheatre != null)
            {
                for (int i = 0; i < scheduleTheatre.Length / 4; i++)
                {
                    int y = i * 4;
                    singleEvent = DtSchedule.NewRow();
                    singleEvent[0] = "Theatre";
                    singleEvent[1] = scheduleTheatre[y];
                    singleEvent[2] = Convert.ToDateTime(scheduleTheatre[y + 1]);
                    singleEvent[3] = Convert.ToInt32(scheduleTheatre[y + 2]);
                    singleEvent[4] = Convert.ToInt32(scheduleTheatre[y + 3]);
                    DtSchedule.Rows.Add(singleEvent);
                }
            }
            DataTable EarliestEvents = Get3EarliestEvents(DtSchedule);

            GvCommingSoon.DataSource = EarliestEvents;
            GvCommingSoon.DataBind();

            

            //Session["ShoppingCart"] = DtShoppingCart;
        }

        private DataTable Get3EarliestEvents(DataTable dtRowData)
        {
            DataTable result = new DataTable();
            result.Columns.Add("Org");
            result.Columns.Add("Title");
            result.Columns.Add("Date", System.Type.GetType("System.DateTime"));
            result.Columns.Add("Runtime", System.Type.GetType("System.Int32"));
            result.Columns.Add("OpenSeats", System.Type.GetType("System.Int32"));
            DateTime firstDate = DateTime.Now.AddYears(100);
            //DateTime earliestDate = DateTime.Now;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < dtRowData.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(dtRowData.Rows[i][2]) <= firstDate)
                        firstDate = Convert.ToDateTime(dtRowData.Rows[i][2]);
                }
                for (int i = 1; i < dtRowData.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(dtRowData.Rows[i][2]) == firstDate)
                    {
                        result.Rows.Add(dtRowData.Rows[i].ItemArray);
                        dtRowData.Rows[i].Delete();
                        firstDate = firstDate.AddYears(100);
                    }
                }
            }
            return result;
        }

        protected void GvCommingSoon_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Select"))
            {
                int rowNumber = Convert.ToInt32(e.CommandArgument.ToString());
                Session["date"] = GvCommingSoon.Rows[rowNumber].Cells[1].Text;
                Session["stage"] = GvCommingSoon.Rows[rowNumber].Cells[0].Text;
                Session["title"] = GvCommingSoon.Rows[rowNumber].Cells[2].Text;
                Response.Redirect("Entertainment.aspx");
            }
        }
    }
}
