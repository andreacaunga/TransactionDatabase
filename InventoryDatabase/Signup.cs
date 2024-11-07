using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryDatabase
{
    public partial class Signup : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=ASUS\SQLEXPRESS;Initial Catalog=dboProject;Persist Security Info=True;User ID=sa;Password=123;Trust Server Certificate=True");
        public Signup()
        {
            InitializeComponent();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frmLogin = new Login();
            frmLogin.ShowDialog();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFname.Text) || String.IsNullOrEmpty(txtLname.Text) || String.IsNullOrEmpty(txtUser.Text) ||
                String.IsNullOrEmpty(txtAddress.Text) || String.IsNullOrEmpty(txtPhone.Text) || String.IsNullOrEmpty(txtConPass.Text))
            {
                MessageBox.Show("All fields are required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (txtUser.Text == "admin" && txtPass.Text == "admin123")
            {
                MessageBox.Show("Invalid. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPass.Text.Trim() != txtConPass.Text.Trim())
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    String checkUsername = "SELECT * FROM tblAccounts WHERE username = '" + txtUser.Text.Trim() + "'";

                    using (SqlCommand checkUser = new SqlCommand(checkUsername, connection))
                    {
                        checkUser.Parameters.AddWithValue("@username", txtUser.Text);

                        SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count >= 1)
                        {
                            MessageBox.Show(txtUser.Text + " already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string insertData = "INSERT INTO tblAccounts (first_name, last_name, username, address, phone, password) " +
                                "VALUES(@fName, @lName, @username, @address, @phone, @pass)";

                            using (SqlCommand cmd = new SqlCommand(insertData, connection))
                            {
                                cmd.Parameters.AddWithValue("@fName", txtFname.Text.Trim());
                                cmd.Parameters.AddWithValue("@lName", txtLname.Text.Trim());
                                cmd.Parameters.AddWithValue("@username", txtUser.Text.Trim());
                                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                                cmd.Parameters.AddWithValue("@pass", txtPass.Text.Trim());

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Account successfully created", null, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.Hide();
                                Login frmLogin = new Login();
                                frmLogin.ShowDialog();
                                this.Close();
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting database: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
