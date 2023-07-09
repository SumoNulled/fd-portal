using FDPortal.Model;
using FDPortal.Model.Database;
using FDPortal.ViewModel;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using User = FDPortal.Model.UserModel;

namespace FDPortal.View
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
            LoadUserData();

            var viewModel = DataContext as DashboardViewModel;
            viewModel.ClockedInChanged += ViewModel_ClockedInChanged;
        }


        private void LoadUserData()
        {

            // Query to retrieve user data
            string query = "SELECT * FROM users";

            // Create a list to store user objects
            List<User> userList = new List<User>();

            using (SqliteConnection connection = Database.connect())
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        // Loop through the result set and create user objects
                        while (reader.Read())
                        {
                            // Assuming you have 'id', 'name', 'email', and 'role' columns in your users table
                            int id = reader.GetInt32(0);
                            string username = reader.GetString(1);
                            string first_name = reader.GetString(2);
                            string last_name = reader.GetString(3);
                            int clocked_in_value = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);

                            bool clocked_in = (clocked_in_value == 1); // Convert to boolean

                            // Create a new user object
                            User user = new User(id, username, first_name, last_name, clocked_in);

                            // Add the user object to the list
                            userList.Add(user);
                        }
                    }
                }
            }

            // Bind the user list to the DataGrid
            employeesDataGrid.ItemsSource = userList;

            // Assuming you have already defined the columns in your DataGrid
            DataGridColumn[] columns = {
                new DataGridTextColumn { Header = "ID", Binding = new Binding("Id") },
                new DataGridTextColumn { Header = "Username", Binding = new Binding("Username") },
                new DataGridTextColumn { Header = "First Name", Binding = new Binding("FirstName") },
                new DataGridTextColumn { Header = "Last Name", Binding = new Binding("LastName") },
                new DataGridTextColumn { Header = "Clocked In", Binding = new Binding("IsClockedIn") }
            };

            string[] headers = { "ID", "Username", "First Name", "Last Name", "Clocked In" };

            employeesDataGrid.Columns.Clear(); // Clear existing columns

            for (int i = 0; i < columns.Length; i++)
            {
                DataGridColumn column = columns[i];
                employeesDataGrid.Columns.Add(column);
                column.Header = headers[i];
            }

        }

        private void ViewModel_ClockedInChanged(object sender, EventArgs e)
        {
            LoadUserData();
        }
    }
}
