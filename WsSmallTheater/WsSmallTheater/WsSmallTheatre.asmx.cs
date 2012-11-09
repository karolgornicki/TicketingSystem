using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections;
using System.Configuration;

namespace WsSmallTheater
{
    /// <summary>
    /// Web service manages data base regarded to the small theater.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        /// <summary>
        /// Ships details about seats of certain entertainment for particualr date.
        /// </summary>
        /// <param name="date">
        /// Date when entertainmant has to perform.
        /// </param>
        /// <param name="showTitle">
        /// Title of the show.
        /// </param>
        /// <returns>
        /// Array with details about each seat, in details: availability, price.
        /// </returns>
        /// <remarks>
        /// Index mod 3 = 1 stand for number of seat, coordinates are divided by comma.
        /// Index mod 3 = 2 stand for availability.
        /// Index mod 3 = 0 stand for price.
        /// </remarks>
        [WebMethod]
        public ArrayList GetSeats(DateTime date, string showTitle)
        {
            ArrayList reply = new ArrayList();

            string connectionString = ConfigurationManager.ConnectionStrings["DbSmallTheatreConnectionString"].ToString();
            MapDbSmallTheatreDataContext dataContext = new MapDbSmallTheatreDataContext(connectionString);

            // Get ID of the show that name is "showName".
            int showID = Convert.ToInt32(dataContext.Shows.Where(showEntity => showEntity.Title == showTitle).First().ShowID);

            // Get ID of the entertainment that refer to showID and will be performed on "date".
            int entertainmentID = Convert.ToInt32(dataContext.Entertainments.Where(entertainmentEntity => 
                entertainmentEntity.Date == date && entertainmentEntity.ShowID == showID).First().EntertainmentID);

            // Get all seats that refer to entertainment.
            var allSeats = dataContext.Seats.Where(seatEntity => seatEntity.EntertainmentID == entertainmentID);

            // Extract data from each seat and populate with them final table.
            foreach (var item in allSeats)
            {
                reply.Add(item.Row.ToString() + "," + item.Number.ToString());
                if (item.CustomerName == null)
                    reply.Add("available");
                else
                    reply.Add("unavailable");
                reply.Add(item.Price.ToString());
            }

            return reply;
        }
        /// <summary>
        /// Books particualar seat by assigning with them name of the customer.
        /// </summary>
        /// <param name="date">
        /// Date when entertainmant has to perform.
        /// </param>
        /// <param name="showTitle">
        /// Title of the show.
        /// </param>
        /// <param name="row">
        /// Number of the row in which seat in located.
        /// </param>
        /// <param name="number">
        /// Number of the seat in particular row.
        /// </param>
        /// <param name="customerName">
        /// Customer's name that would be assignet to the seat.
        /// </param>
        /// <returns>
        /// Flag is task has been done successfully of failed.
        /// </returns>
        [WebMethod]
        public string BookSeat(DateTime date, string showTitle, int row, int number, string customerName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbSmallTheatreConnectionString"].ToString();
            MapDbSmallTheatreDataContext dataContext = new MapDbSmallTheatreDataContext(connectionString);

            // Get ID of the show that name is "showName".
            int showID = Convert.ToInt32(dataContext.Shows.Where(showEntity => showEntity.Title == showTitle).First().ShowID);

            // Get ID of the entertainment that refer to showID and will be performed on "date".
            int entertainmentID = Convert.ToInt32(dataContext.Entertainments.Where(entertainmentEntity => 
                entertainmentEntity.Date == date && entertainmentEntity.ShowID == showID).First().EntertainmentID);

            // Get required seat.
            var seat = dataContext.Seats.Where(seatEntity => seatEntity.EntertainmentID == entertainmentID && 
                seatEntity.Row == row && seatEntity.Number == number).First();

            if (seat.CustomerName == null)
            {
                seat.CustomerName = customerName;
                dataContext.SubmitChanges();
                return "success";
            }
            else
                return "fail";
        }
        /// <summary>
        /// Ships details about particular play.
        /// </summary>
        /// <param name="showTitle">
        /// Titel of the play that is subject of search.
        /// </param>
        /// <returns>
        /// Array with details.
        /// </returns>
        /// <remarks>
        /// First index stand for director.
        /// Second index stand for cast.
        /// Third index stand for storyline.
        /// Fourth index stand for runtime.
        /// </remarks>
        [WebMethod]
        public ArrayList GetShowDetails(string showTitle)
        {
            ArrayList reply = new ArrayList();

            string connectionString = ConfigurationManager.ConnectionStrings["DbSmallTheatreConnectionString"].ToString();
            MapDbSmallTheatreDataContext dataContext = new MapDbSmallTheatreDataContext(connectionString);

            // Identify particular play based on "showTitle".
            var play = dataContext.Shows.Where(showEntity => showEntity.Title == showTitle).First();

            // Populate reply array with appropiate data.
            reply.Add(play.Director);
            reply.Add(play.Cast);
            reply.Add(play.Storyline);
            reply.Add(play.Runtime.ToString());

            return reply;
        }
        /// <summary>
        /// Ships program of all entertainments that has to be scheduled for particular date, including essential information
        /// about each performance.
        /// </summary>
        /// <param name="date">
        /// Date that has to be investigated.
        /// </param>
        /// <returns>
        /// Array with program.
        /// </returns>
        /// <remarks>
        /// x mod 6 = 1 : title.
        /// x mod 6 = 2 : date. 
        /// x mod 6 = 3 : director.
        /// x mod 6 = 4 : cast.
        /// x mod 6 = 5 : duration.
        /// x mod 6 = 0 : quantity of open seats.
        /// </remarks>
        [WebMethod]
        public ArrayList GetScheduleForDate(DateTime date)
        {
            ArrayList reply = new ArrayList();

            // Border dates.
            DateTime bottomDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0),
                upperDate = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);

            string connectionString = ConfigurationManager.ConnectionStrings["DbSmallTheatreConnectionString"].ToString();
            MapDbSmallTheatreDataContext dataContext = new MapDbSmallTheatreDataContext(connectionString);

            // Collect all entertainments in "date".
            var collectionOfEntertainments = dataContext.Entertainments.Where(collectionEntity =>
                collectionEntity.Date >= bottomDate && collectionEntity.Date <= upperDate).OrderBy(x => x.Date);

            // Populate the final array.
            foreach (var item in collectionOfEntertainments)
            {
                // Get play that entertainment entity refered to.
                var play = dataContext.Shows.Where(playEntity => playEntity.ShowID == item.ShowID).First();
                reply.Add(play.Title);
                reply.Add(item.Date);
                reply.Add(play.Director);
                reply.Add(play.Cast);
                reply.Add(play.Runtime);
                reply.Add(OpenSeat(item.EntertainmentID));
            }

            return reply;
        }
        /// <summary>
        /// Ships name and date of 3 earliest entertainment since requested date.
        /// </summary>
        /// <param name="sinceDate">
        /// Date since searching begin.
        /// </param>
        /// <returns>
        /// Array with titles and dates of entertainments.
        /// </returns>
        /// <remarks>
        /// x mod 2 = 1 : title.
        /// x mod 2 = 0 : date.
        /// </remarks>
        [WebMethod]
        public ArrayList Get3EarliestEntertainment(DateTime sinceDate)
        {
            ArrayList reply = new ArrayList();

            string connectionString = ConfigurationManager.ConnectionStrings["DbSmallTheatreConnectionString"].ToString();
            MapDbSmallTheatreDataContext dataContext = new MapDbSmallTheatreDataContext(connectionString);

            var collectionOfEntertainment = dataContext.Entertainments.Where(entertainment => entertainment.Date >= sinceDate).OrderBy(x => x.Date);
            int counterOfEntertainments = 0;
            foreach (var item in collectionOfEntertainment)
            {

                string title = (dataContext.Shows.Where(showEntity => showEntity.ShowID == item.ShowID).Select(
                    searchedShow => searchedShow.Title).First());
                DateTime date = item.Date;
                
                int runtime = dataContext.Shows.Where(showEntity => showEntity.Title == title).Select(y => y.Runtime).First();
                int openSeats = OpenSeat(dataContext.Entertainments.Where(entity => entity.Date == date && entity.ShowID == item.ShowID).Select(z => z.EntertainmentID).First());
                reply.Add(title);
                reply.Add(date);
                reply.Add(runtime);
                reply.Add(openSeats);
                counterOfEntertainments++;

                if (counterOfEntertainments.Equals(3))
                    return reply;
            }

            return reply;
        }
        /// <summary>
        /// Get all entertainment within certain month.
        /// </summary>
        /// <param name="date">
        /// Whole date, month from this date would be extracted.
        /// </param>
        /// <returns>
        /// Array with brief ingformation about each entertainment that has been schedulet in required month.
        /// </returns>
        /// <remarks>
        /// 1 : title
        /// 2 : date
        /// 3 : runtime
        /// 4 : open seats
        /// </remarks>
        [WebMethod]
        public ArrayList GetScheduleForAMonth(DateTime date)
        {
            ArrayList reply = new ArrayList();

            string connectionString = ConfigurationManager.ConnectionStrings["DbSmallTheatreConnectionString"].ToString();
            MapDbSmallTheatreDataContext dataContext = new MapDbSmallTheatreDataContext(connectionString);

            DateTime bottomDate = new DateTime(date.Year, date.Month, 1, 0, 0, 0),
                upperDate = bottomDate.AddMonths(1);

            var collectionOfEnt = dataContext.Entertainments.Where(ent => ent.Date >= bottomDate && ent.Date <= upperDate).OrderBy(x => x.Date);

            foreach (var item in collectionOfEnt)
            {
                string title = (dataContext.Shows.Where(showEntity => showEntity.ShowID == item.ShowID).Select(
                    searchedShow => searchedShow.Title).First());
                DateTime dateOfEnt = item.Date;

                int runtime = dataContext.Shows.Where(showEntity => showEntity.Title == title).Select(y => y.Runtime).First();
                int openSeats = OpenSeat(dataContext.Entertainments.Where(entity => entity.Date == dateOfEnt && entity.ShowID == item.ShowID).Select(z => z.EntertainmentID).First());
                reply.Add(title);
                reply.Add(dateOfEnt);
                reply.Add(runtime);
                reply.Add(openSeats);
            }

            return reply;
        }
        /// <summary>
        /// Cance reservation for particualar seat by erasing already assigned name of the customer with it.
        /// </summary>
        /// <param name="date">
        /// Date when entertainmant has to perform.
        /// </param>
        /// <param name="showTitle">
        /// Title of the show.
        /// </param>
        /// <param name="row">
        /// Number of the row in which seat in located.
        /// </param>
        /// <param name="number">
        /// Number of the seat in particular row.
        /// <returns>
        /// Flag is task has been done successfully or failed.
        /// </returns>
        [WebMethod]
        public string CancelReservation(DateTime date, string showTitle, int row, int number)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbSmallTheatreConnectionString"].ToString();
            MapDbSmallTheatreDataContext dataContext = new MapDbSmallTheatreDataContext(connectionString);

            try
            {
                // Get ID of the show that name is "showName".
                int showID = Convert.ToInt32(dataContext.Shows.Where(showEntity => showEntity.Title == showTitle).First().ShowID);

                // Get ID of the entertainment that refer to showID and will be performed on "date".
                int entertainmentID = Convert.ToInt32(dataContext.Entertainments.Where(entertainmentEntity =>
                    entertainmentEntity.Date == date && entertainmentEntity.ShowID == showID).First().EntertainmentID);

                // Get required seat.
                var seat = dataContext.Seats.Where(seatEntity => seatEntity.EntertainmentID == entertainmentID &&
                    seatEntity.Row == row && seatEntity.Number == number).First();

                seat.CustomerName = null;
                dataContext.SubmitChanges();
                return "success";
            }
            catch (Exception)
            {
                return "fail";
            }
        }
        /// <summary>
        /// Private method, ships number of open seats for particular entertainment. 
        /// </summary>
        /// <param name="entertainmentID">
        /// ID for investigating entertainment.
        /// </param>
        /// <returns>
        /// Number of open seats.
        /// </returns>
        private int OpenSeat(int entertainmentID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbSmallTheatreConnectionString"].ToString();
            MapDbSmallTheatreDataContext dataContext = new MapDbSmallTheatreDataContext(connectionString);

            return dataContext.Seats.Where(seatEntity => seatEntity.EntertainmentID == entertainmentID &&
                seatEntity.CustomerName == null).Count();
        }
        
    }
}