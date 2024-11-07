using InventoryDatabase.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDatabase.Repositories
{
    public class TransactionRepository
    {
        private string connectionString = @"Data Source=ASUS\SQLEXPRESS;Initial Catalog=dboProject;Persist Security Info=True;User ID=sa;Password=123;Encrypt=True;Trust Server Certificate=True";

        public List<Transaction> ReadTransactions()
        {
            var transactions = new List<Transaction>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM tblTransactions";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Transaction transaction = new Transaction();

                                transaction.transactionID = reader.GetInt32(0);
                                transaction.transactionDate = reader.GetDateTime(1);
                                transaction.fName = reader.GetString(2);
                                transaction.lName = reader.GetString(3);
                                transaction.userID = reader.GetInt32(4);
                                transaction.totalAmount = reader.GetDouble(5);


                                transactions.Add(transaction);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return transactions;
        }
        public void addTransaction(Transaction transaction)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO tblTransactions (user_id, first_name, last_name, transaction_date, total_amount) " +
                               "VALUES (@userID, @firstName, @lastName, @transactionDate, @totalAmount)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userID", transaction.userID);
                    command.Parameters.AddWithValue("@firstName", transaction.fName);
                    command.Parameters.AddWithValue("@lastName", transaction.lName);
                    command.Parameters.AddWithValue("@transactionDate", transaction.transactionDate);
                    command.Parameters.AddWithValue("@totalAmount", transaction.totalAmount);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
