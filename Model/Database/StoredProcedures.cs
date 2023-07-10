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
                "DROP TABLE users; CREATE TABLE IF NOT EXISTS users (Id INTEGER PRIMARY KEY AUTOINCREMENT, Username VARCHAR(50), First_Name VARCHAR(50), Last_Name VARCHAR(50), Password VARCHAR(255), Clocked_In INTEGER);"
                );

            Schema.Add(
                "usp_Create_Table_Timesheets",
                "CREATE TABLE IF NOT EXISTS timesheets (Id INTEGER PRIMARY KEY AUTOINCREMENT, User_Id INTEGER, Clock_In TIMESTAMP, Clock_Out TIMESTAMP);"
                );

            Schema.Add(
                "usp_Add_Users",
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('jdoe', 'John', 'Doe', 'password123');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('lhost', 'Local', 'Host', 'securepassword');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('kbellator', 'Klay', 'Bellator', 'pass1234');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user1', 'John', 'Smith', 'pass123');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user2', 'Emma', 'Johnson', 'abc456');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user3', 'Michael', 'Williams', 'pass789');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user4', 'Sophia', 'Brown', 'xyz987');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user5', 'Matthew', 'Jones', 'password1');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user6', 'Olivia', 'Miller', 'passw0rd');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user7', 'Liam', 'Davis', 'securepass');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user8', 'Ava', 'Wilson', 'mypassword');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user9', 'Noah', 'Taylor', 'password123');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user10', 'Isabella', 'Anderson', 'myp4ssword');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user11', 'James', 'Thomas', 'pass9876');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user12', 'Emily', 'Martinez', 'abcd1234');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user13', 'Benjamin', 'Robinson', 'pass!@#$');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user14', 'Amelia', 'Clark', 'qwerty12');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user15', 'Lucas', 'Walker', 'password!@#');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user16', 'Mia', 'Young', 'pass12345');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user17', 'Henry', 'Hill', 'secure1');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user18', 'Charlotte', 'Scott', 'mypassword12');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user19', 'Alexander', 'Green', 'passwordabc');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user20', 'Harper', 'Adams', 'passw0rd123');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user21', 'Daniel', 'Baker', 'myp4ssword!');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user22', 'Sophie', 'Gonzalez', 'abcd12345');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user23', 'Joseph', 'Carter', 'pass!@#123');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user24', 'Grace', 'Harris', 'qwerty123');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user25', 'Samuel', 'Turner', 'password!@#123');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user26', 'Avery', 'Allen', 'pass123456');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user27', 'Elizabeth', 'Adams', 'secure12');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user28', 'David', 'Parker', 'mypassword123');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user29', 'Sebastian', 'Ward', 'passwordabc12');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user30', 'Victoria', 'Bell', 'passw0rd!@#');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user31', 'Jackson', 'Watson', 'myp4ssword123');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user32', 'Lily', 'Brooks', 'abcd123456');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user33', 'Andrew', 'Hayes', 'pass!@#1234');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user34', 'Sofia', 'Sullivan', 'qwerty1234');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user35', 'William', 'Mitchell', 'password!@#1234');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user36', 'Aria', 'Russell', 'pass1234567');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user37', 'Elijah', 'Coleman', 'secure123');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user38', 'Scarlett', 'Harrison', 'mypassword1234');" +
    "INSERT INTO users (Username, First_Name, Last_Name, Password) VALUES ('user39', 'Gabriel', 'Mason', 'passwordabc123');"
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
