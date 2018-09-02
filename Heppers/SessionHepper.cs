using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Heppers
{
    public class SessionHepper
    {
        public static bool IsAuthenticated
        {
            get { return HttpContext.Current.Session != null && HttpContext.Current.Session["loggedUser"] != null; }
        }
        public static void SetSession(Session session)
        {
            HttpContext.Current.Session["loggedUser"] = session;
        }
        public static Session GetSession()
        {
            var session = HttpContext.Current.Session["loggedUser"];
            return session as Session;
        }
    }
}
