using InventoryDatabase.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDatabase.Repositories
{
    public class UserRepository
    {
        // CHANGE THIS
        private readonly string connectionString = "Data Source=ASUS\\SQLEXPRESS;Initial Catalog=dboProject;Persist Security Info=True;User ID=sa;Password=123;Trust Server Certificate=True";

        public List<User> ReadUsers()
        {
            var users = new List<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM tblAccounts";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User();

                                user.userID = reader.GetInt32(0);
                                user.fName = reader.GetString(1);
                                user.lName = reader.GetString(2);
                                user.username = reader.GetString(3);
                                user.address = reader.GetString(4);
                                user.phone = reader.GetString(5);
                                user.pass = reader.GetString(6);

                                users.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return users;
        }

        public User? ReadUser(int userID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM tblAccounts WHERE user_id = @userID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userID", userID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User();
                                user.userID = reader.GetInt32(0);
                                user.fName = reader.GetString(1);
                                user.lName = reader.GetString(2);
                                user.username = reader.GetString(3);
                                user.address = reader.GetString(4);
                                user.phone = reader.GetString(5);
                                user.pass = reader.GetString(6);

                                return user;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public List<User>? ReadUserbyID(int userID)
        {
            var users = new List<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM tblAccounts WHERE user_id LIKE @userID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userID", "%" + userID + "%");
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User();
                                user.userID = reader.GetInt32(0);
                                user.fName = reader.GetString(1);
                                user.lName = reader.GetString(2);
                                user.username = reader.GetString(3);
                                user.address = reader.GetString(4);
                                user.phone = reader.GetString(5);
                                user.pass = reader.GetString(6);

                                users.Add(user);
                            }
                        }
                    }
                    return users;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void createUser(User user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO tblAccounts" +
                        " (first_name, last_name, username, address, phone, password) VALUES " +
                        "(@fName, @lName, @username, @address, @phone, @pass)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@fName", user.fName);
                        cmd.Parameters.AddWithValue("@lName", user.lName);
                        cmd.Parameters.AddWithValue("@username", user.username);
                        cmd.Parameters.AddWithValue("@address", user.address);
                        cmd.Parameters.AddWithValue("@phone", user.phone);
                        cmd.Parameters.AddWithValue("@pass", user.pass);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void updateUser(User user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE tblAccounts SET " +
                        "first_name = @fName, last_name = @lName, username = @username, address = @address, phone = @phone, password = @pass " +
                        "WHERE user_id = @userID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@fName", user.fName);
                        cmd.Parameters.AddWithValue("@lName", user.lName);
                        cmd.Parameters.AddWithValue("@username", user.username);
                        cmd.Parameters.AddWithValue("@address", user.address);
                        cmd.Parameters.AddWithValue("@phone", user.phone);
                        cmd.Parameters.AddWithValue("@pass", user.pass);
                        cmd.Parameters.AddWithValue("@userID", user.userID);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void deleteUser(int userID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM tblAccounts " +
                        "WHERE user_id = @userID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userID", userID);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool validateUser(string username, string pass)
        {
            bool isValid = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(1) FROM tblAccounts WHERE username = @username AND password = @pass";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@pass", pass);

                        // Execute the query and check if any record exists
                        int count = (int)command.ExecuteScalar();
                        isValid = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }
        
        public (int userID, string fName, string lName) GetUserInfo(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT user_id, first_name, last_name FROM tblAccounts WHERE username = @username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userID = reader.GetInt32(reader.GetOrdinal("user_id"));
                            string firstName = reader.GetString(reader.GetOrdinal("first_name"));
                            string lastName = reader.GetString(reader.GetOrdinal("last_name"));

                            return (userID, firstName, lastName);
                        }
                    }
                }
            }
            throw new Exception("User not found.");
        }
    }
}
