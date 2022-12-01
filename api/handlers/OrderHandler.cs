using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using api.models;

namespace api.handlers
{
    public class OrderHandler : DBHandler
    {
        public IEnumerable<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM [Order]", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // string ProdID = reader.GetString(1);
                            // Product prod = new Product();
                            // prod.ProdID = ProdID;
                            // using (SqlConnection conn2 = new SqlConnection(GetConnectionString()))
                            // {
                            //     conn2.Open();
                            //     using (SqlCommand command2 = new SqlCommand($"SELECT * FROM Product WHERE ProdID = '{ProdID}';", conn2))
                            //     {
                            //         using (SqlDataReader reader2 = command2.ExecuteReader())
                            //         {
                            //             while (reader2.Read())
                            //             {
                            //                 prod.CatID = reader2.GetInt32(1);
                            //                 prod.Description = reader2.GetString(2);
                            //                 prod.UnitPrice = reader2.GetDecimal(3);
                            //             }
                            //         }
                            //     }
                            // }

                            // index mapping
                            // 0  =>  order id      e.g.   1, 
                            // 1  =>  customer id   e.g.   CG-12520, 
                            // 2  =>  prod id       e.g.   FUR-BO-10001798, 
                            // 3  =>  order date    e.g.   08/11/2016 00:00:00, 
                            // 4  =>  qty           e.g.   2, 
                            // 5  =>  ship date     e.g.   11/11/2016 00:00:00, 
                            // 6  =>  shipmoide     e.g.   Second Class"

                            int OrderID;
                            int.TryParse(reader[0].ToString(), out OrderID);
                            string CustID = "" + reader[1].ToString();
                            string ProdID = "" + reader[2].ToString();
                            DateTime OrderDate;
                            DateTime.TryParse(reader[3].ToString(), out OrderDate);
                            int Quantity;
                            int.TryParse(reader[4].ToString(), out Quantity);
                            DateTime ShipDate;
                            DateTime.TryParse(reader[5].ToString(), out ShipDate);
                            string ShipMode = "" + reader[6].ToString();

                            orders.Add(new Order(OrderID, OrderDate, Quantity, ShipDate,
                                    CustID, ProdID, ShipMode, new Product() { }));

                        };
                    }
                }
            }
            return orders;
        }

        public int CreateOrder(Order order)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO [ORDER] VALUES (@pOrderID, @pCustID, @pProdID, @pQuantity, @pShipDate, @pShipMode", conn))
                {

                    command.Parameters.AddWithValue("@pOrderID", order.OrderID);
                    command.Parameters.AddWithValue("@pCustID", order.CustID);
                    command.Parameters.AddWithValue("@pProdID", order.ProdID);
                    command.Parameters.AddWithValue("@pOrderDate", order.OrderDate);
                    command.Parameters.AddWithValue("@pQuantity", order.Quantity);
                    command.Parameters.AddWithValue("@pShipDate", order.ShipDate);
                    command.Parameters.AddWithValue("@pShipMode", order.ShipMode);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected;
                }
                // conn.Close();
            }

        }

        public int DeleteOrder(Order order)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM [ORDER] WHERE OrderDate = @Order AND ProdID = @ProdID AND CustID = @CustID", conn))
                {
                    command.Parameters.AddWithValue("@Order", order.OrderDate);
                    command.Parameters.AddWithValue("@ProdID", order.Prod.ProdID);
                    command.Parameters.AddWithValue("@Order", order.CustID);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
                //conn.Close();
            }
        }
    }
}