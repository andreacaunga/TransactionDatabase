using InventoryDatabase.Models;
using InventoryDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InventoryDatabase
{
    public partial class UserPage : Form
    {
        private string currentUsername;
        public UserPage(string username)
        {
            InitializeComponent();
            currentUsername = username;

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve user information from tblAccounts
                var userRepo = new UserRepository();
                var userInfo = userRepo.GetUserInfo(currentUsername);

                // Get total amount from the form or your business logic
                double totalAmount = Convert.ToDouble(txtTotal.Text); // Example total amount

                // Create a transaction instance
                Transaction transaction = new Transaction
                {
                    userID = userInfo.userID,
                    fName = userInfo.fName,
                    lName = userInfo.lName,
                    transactionDate = DateTime.Now,
                    totalAmount = totalAmount
                };

                // Save transaction to the database
                var transactionRepo = new TransactionRepository();
                transactionRepo.addTransaction(transaction);

                MessageBox.Show("Transaction saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frmLogin = new Login();
            frmLogin.ShowDialog();
            this.Close();
        }
    }
}
