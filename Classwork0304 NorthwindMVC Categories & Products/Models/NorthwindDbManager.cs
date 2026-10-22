using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Classwork0304_NorthwindMVC_Categories___Products.Models
{
    public class NorthwindDbManager
    {
        private readonly string _connectionString;

        public NorthwindDbManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Category> GetCategories()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT CategoryID, CategoryName, Description FROM Categories";

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Category> categories = new List<Category>();

            while (reader.Read())
            {
                categories.Add( new Category 
                {
                    Id = (int)reader["CategoryID"],
                    Name = (string)reader["CategoryName"],
                    Description = (string)reader["Description"]
                });
            }

            connection.Close();

            return categories;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Products
                                    WHERE CategoryID = @CategoryID";
            command.Parameters.AddWithValue("@CategoryID", categoryId);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                products.Add(new Product
                {
                    ProductId = (int)reader["ProductID"],
                    ProductName = (string)reader["ProductName"],
                    CategoryId = (int)reader["CategoryID"],
                    UnitPrice = (decimal)reader["UnitPrice"],
                    UnitsInStock = (short)reader["UnitsInStock"]
                });
            }

            connection.Close();

            return products;
        }

        public string GetCategoryName(int categoryId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT CategoryName FROM Categories
                                    WHERE CategoryID = @CategoryID";
            command.Parameters.AddWithValue("@CategoryID", categoryId);
            connection.Open();            

            return (string)command.ExecuteScalar();
        }
    }
}