using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace NetCoreWebAPIs.Order.WebAPI.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string connectionString;

        public OrderRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("OrderConnection");
        }

        public List<Core.Models.Order> GetOrders(int customerId)
        {
            var orders = new List<Core.Models.Order>();
            const string sql = "SELECT * FROM CustomerOrder WHERE CustomerId = @id";
            using (var connection = new SqliteConnection(connectionString))
            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", customerId);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    orders.Add(new Core.Models.Order
                    {
                        OrderId = int.Parse(reader["OrderId"].ToString()),
                        CustomerId = int.Parse(reader["CustomerId"].ToString()),
                        TotalPrice = int.Parse(reader["TotalPrice"].ToString()),
                        OrderDate = DateTime.Parse(reader["OrderDate"].ToString())
                    });
                }
                connection.Close();
            }
            return orders;
        }

        public void InsertOrder(Core.Models.Order order)
        {
            const string initialSeedSQL = "INSERT INTO CustomerOrder(CustomerId, TotalPrice, OrderDate) VALUES(@customerid, @totalprice, @orderdate)";
            using (var connection = new SqliteConnection(connectionString))
            using (var command = new SqliteCommand(initialSeedSQL, connection))
            {
                command.Parameters.AddWithValue("@customerid", order.CustomerId);
                command.Parameters.AddWithValue("@totalprice", order.TotalPrice);
                command.Parameters.AddWithValue("@orderdate", order.OrderDate);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}