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
            if (session.ContainsKey("Is_Logged_In"))
            {
                switch (session["Is_Logged_In"])
                {
                    case "True":
                        return true;
                        break;

                    default:
                        return false;
                        break;
                }
            }
            return false;
        }
    }
}
