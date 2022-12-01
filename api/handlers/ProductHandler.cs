using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using api.models;

namespace api.handlers
{
    public class ProductHandler : DBHandler
    {
        public IEnumerable<Product> GetAllProducts()
        {

            List<Product> products = new List<Product>();

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Product", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product()
                            {

                                ProdID = reader.GetString(0),
                                CatID = reader.GetInt32(1),
                                Description = reader.GetString(2),
                                UnitPrice = reader.GetDecimal(3)
                            });
                        }
                    }
                }
                conn.Close();
            }
            return products;
        }
    }
}