using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDPortal.Model.Database
{
    class Database
    {
        public static String ds = "Data Source=";
        public static String pw = "Password=";
        public void Create(String dataSource, String? password = null)
        {
            // Configure the connection to the embedded database.
            String connectionString = String.Format("{0}{1}; {2}{3};", ds, dataSource, pw, password);

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create the necessary tables and initialize the schema
                string createTableQuery = StoredProcedures.InitializeSchema();

                using (SqliteCommand command = new SqliteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Close the connection
                connection.Close();
            }
        }

        public static SqliteConnection connect()
        {
            Config c = new Config();
            string dataSource = c.getDataSource();
            string password = c.getPassword();

            Database db = new Database();

            // In the unexpected case that the database isn't included in the file, create it.
            switch (File.Exists(dataSource))
            {
                case false:
                    db.Create(dataSource, password);
                    break;
            }

            String connectionString = String.Format("{0}{1}; {2}{3};", ds, dataSource, pw, password);

            SqliteConnection conn = new SqliteConnection();
            conn.ConnectionString = connectionString;

            return conn;
        }
    }
}
