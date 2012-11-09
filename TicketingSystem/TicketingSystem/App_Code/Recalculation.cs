using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TicketingSystem
{
    public class Recalculation
    {
        public static string Calculate(string Xfrom, string Xto, string Xdeposite)
        {
            XDocument xd = XDocument.Load(@"http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
            string tmp;
            double DFrom = 1d, DTo = 1d;
            double deposite = Convert.ToDouble(Xdeposite);

            if (Xfrom != "EUR")
            {
                var _from = xd.Descendants().First(p => (string)p.Attribute("currency") == Xfrom);
                tmp = _from.Attribute("rate").Value;
                tmp = tmp.Replace(".", ",");
                DFrom = Convert.ToDouble(tmp);
            }

            if (Xto != "EUR")
            {
                var _to = xd.Descendants().First(p => (string)p.Attribute("currency") == Xto);
                tmp = _to.Attribute("rate").Value;
                tmp = tmp.Replace(".", ",");
                DTo = Convert.ToDouble(tmp);
            }
            deposite = ((1 / DFrom) * deposite) * DTo;
            return Convert.ToString(deposite);
        } 
    }
}