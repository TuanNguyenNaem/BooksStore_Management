using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Helpers
{
    public class SessionHelper
    {
        public static bool IsAuthenticated
        {
            get { return HttpContext.Current.Session != null && HttpContext.Current.Session["loggedUser"] != null; }
        }
        public static void SetSession(UserSession session)
        {
            HttpContext.Current.Session["loggedUser"] = session;
        }
        public static UserSession GetSession()
        {
            var session = HttpContext.Current.Session["loggedUser"];
            return session as UserSession;
        }
    }
}
