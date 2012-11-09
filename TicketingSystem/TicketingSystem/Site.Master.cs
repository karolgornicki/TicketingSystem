using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace TicketingSystem
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["date"] != null)
            {
                Calendar1.SelectedDate = Convert.ToDateTime(Session["date"]);
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Session["date"] = Calendar1.SelectedDate.ToString();
            Response.Redirect("ScheduleForADay.aspx");
        }
        protected void DisablePastDays(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < System.DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = Color.Gray;
            }
        }
    }
}
