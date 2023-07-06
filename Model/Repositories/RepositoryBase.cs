using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDPortal.Model.Repositories
{
    class RepositoryBase
    {
        protected SqliteConnection GetConnection()
        {
            return Database.Database.connect();
        }
    }
}
