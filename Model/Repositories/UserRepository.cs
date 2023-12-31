﻿using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.Data.Sqlite;

namespace FDPortal.Model.Repositories
{
    class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;

            using (var connection = GetConnection())
            {
                using (var command = connection.CreateCommand()) 
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM [Users] WHERE username=@username AND [password]=@password";
                    command.Parameters.Add("@username", SqliteType.Text).Value=credential.UserName;
                    command.Parameters.Add("@password", SqliteType.Text).Value=credential.Password;
                    validUser = command.ExecuteScalar() == null ? false : true;
                }
            }

           return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void ClockIn(int id)
        {
            using (var connection = GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "UPDATE Users SET clocked_in = @clocked_in WHERE id = @id";
                    command.Parameters.AddWithValue("@clocked_in", 1);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO timesheets (User_Id, Clock_In) VALUES (@user_id, datetime('now', 'localtime'))";
                    command.Parameters.AddWithValue("@user_id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ClockOut(int id)
        {
            using (var connection = GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "UPDATE Users SET clocked_in = @clocked_in WHERE id = @id";
                    command.Parameters.AddWithValue("@clocked_in", 0);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();

                    command.CommandText = "UPDATE timesheets SET Clock_Out = datetime('now', 'localtime') WHERE User_Id = @user_id AND Clock_Out IS NULL";
                    command.Parameters.AddWithValue("@user_id", id);
                    command.ExecuteNonQuery();
                }
            }
        }


        public bool IsClockedIn(int id)
        {
            bool status;

            using (var connection = GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "SELECT clocked_in FROM [Users] WHERE id=@id AND clocked_in=1";
                    command.Parameters.Add("@id", SqliteType.Integer).Value = id;
                    status = command.ExecuteScalar() == null ? false : true;
                }
            }

            return status;
        }
    }
}
