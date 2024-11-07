using InventoryDatabase.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDatabase.Repositories
{
    public class ProductRepository
    {
        // CHANGE THIS
        private readonly string connectionString = "Data Source=ASUS\\SQLEXPRESS;Initial Catalog=dboProject;Persist Security Info=True;User ID=sa;Password=123;Trust Server Certificate=True";

        public List<Product> ReadProducts()
        {
            var products = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM tblProducts";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product();

                                product.productID = reader.GetInt32(0);
                                product.quantity = reader.GetInt32(1);
                                product.productName = reader.GetString(2);
                                product.category = reader.GetString(3);
                                product.itemPrice = reader.GetDouble(4);

                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return products;
        }

        public Product? ReadProduct(int productID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM tblProducts WHERE product_id = @productID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@productID", productID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product();

                                product.productID = reader.GetInt32(0);
                                product.quantity = reader.GetInt32(1);
                                product.productName = reader.GetString(2);
                                product.category = reader.GetString(3);
                                // MODIFIED FLOAT TO DOUBLE
                                product.itemPrice = reader.GetDouble(4);

                                return product;
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

        //FOR SEARCHING 
        public List<Product>? ReadProductbyID(int productID)
        {
            var products = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM tblProducts WHERE product_id LIKE @productID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@productID", "%" + productID + "%");
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product();

                                product.productID = reader.GetInt32(0);
                                product.quantity = reader.GetInt32(1);
                                product.productName = reader.GetString(2);
                                product.category = reader.GetString(3);
                                // MODIFIED FLOAT TO DOUBLE
                                product.itemPrice = reader.GetDouble(4);

                                products.Add(product);
                            }
                        }
                    }
                    return products;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public void createProduct(Product product)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO tblProducts" +
                        " (quantity, product_name, category, price) VALUES " +
                        "(@quantity, @productName, @category, @itemPrice)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@quantity",product.quantity);
                        cmd.Parameters.AddWithValue("@productName", product.productName);
                        cmd.Parameters.AddWithValue("@category", product.category);
                        cmd.Parameters.AddWithValue("@itemPrice", product.itemPrice);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void updateProduct(Product product)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE tblProducts SET " +
                        "quantity = @quantity, product_name = @productName, category = @category, price = @itemPrice " +
                        "WHERE product_id = @productID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@quantity", product.quantity);
                        cmd.Parameters.AddWithValue("@productName", product.productName);
                        cmd.Parameters.AddWithValue("@category", product.category);
                        cmd.Parameters.AddWithValue("@itemPrice", product.itemPrice);
                        cmd.Parameters.AddWithValue("@productID", product.productID);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // CHANGED deleteProduct to removeProduct
        public void deleteProduct(int productID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM tblProducts " +
                        "WHERE product_id = @productID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@productID", productID);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
