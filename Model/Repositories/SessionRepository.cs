using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDPortal.Model.Repositories
{
    class SessionRepository : RepositoryBase
    {
        static Dictionary<string, string> session = new Dictionary<string, string>();
        public static string SessionToken 
        {
            get
            {
                if (session.TryGetValue("Session_Token", out string value))
                {
                    return value;
                }
                else
                {
                    return null; // or return any default value
                }
            }
        }
        public static void CreateSession(string sessionToken)
        {
            session.Add("Is_Logged_In", "True");
            session.Add("Session_Token", sessionToken);
        }

        public static void DeleteSession()
        {
            session.Remove("Is_Logged_In");
            session.Remove("Session_Token");
        }

        public static string GetSessionToken()
        {
            if (session.ContainsKey("Session_Token"))
            {
                return session["Session_Token"];
            }

            return null;
        }

        public static bool GetLoggedIn()
        {
            bool logged_in = false;

            if (session.ContainsKey("Is_Logged_In"))
            {
                switch (session["Is_Logged_In"])
                {
                    case "True":
                        logged_in = true;
                        break;

                    default:
                        logged_in = false;
                        break;
                }
            }

            return logged_in;
        }
    }
}
