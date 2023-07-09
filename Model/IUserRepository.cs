using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FDPortal.Model
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        bool IsClockedIn(int id);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);

        UserModel GetById(int id);
        UserModel GetByUsername(int id);
        IEnumerable<UserModel> GetByAll();

        void ClockIn(int id);
        void ClockOut(int id);
    }
}
