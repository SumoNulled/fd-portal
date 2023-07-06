using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace FDPortal.Model.Database
{
    class StoredProcedures
    {
        private static Dictionary<string, string> Schema = new Dictionary<string, string>();

        public static Dictionary<string, string> GetUser(int id)
        {
            Dictionary<string, string> userData = null;

            // Assuming you have a database connection established
            using (var connection = Database.connect())
            {
                connection.Open();

                // Assuming the "users" table has columns: Id, First_Name, Last_Name, Password, Email
                string query = $"SELECT * FROM users WHERE Id = @Id";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userData = new Dictionary<string, string>();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetName(i);
                                string columnValue = reader.IsDBNull(i) ? null : reader.GetString(i);

                                userData[columnName] = columnValue;
                            }
                        }
                    }
                }
            }

            return userData;
        }



        public static string InitializeSchema()
        {
            Schema.Add(
                "usp_Create_Table_Users", 
                "DROP TABLE users; CREATE TABLE IF NOT EXISTS users (Id INTEGER PRIMARY KEY AUTOINCREMENT, Username VARCHAR(50), First_Name VARCHAR(50), Last_Name VARCHAR(50), Password VARCHAR(255));"
                );

            Schema.Add(
                "usp_Add_Users",
                "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('jdoe', 'John', 'Doe', 'password123');" +
                "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('lhost', 'Local', 'Host', 'securepassword');" +
                "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('kbellator', 'Klay', 'Bellator', 'pass1234');"
                );

            string combinedQuery = "";

            foreach (var query in Schema.Values)
            {
                combinedQuery += query;
            }

            return combinedQuery;
        }
    }
}
