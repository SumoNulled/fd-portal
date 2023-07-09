using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FDPortal.Model
{
    public class UserModel
    {
        public int? Id { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public bool? IsClockedIn { get; set; }

        public UserModel(int id, string username, string first_name, string last_name, bool clocked_in)
        {
            Id = id;
            Username = username;
            FirstName = first_name;
            LastName = last_name;
            IsClockedIn = clocked_in;
        }
    }
}
