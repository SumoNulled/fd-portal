using Microsoft.Data.Sqlite;

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
