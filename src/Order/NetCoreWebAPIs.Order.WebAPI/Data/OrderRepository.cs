using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Order.WebAPI.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SqliteConnection sqliteConnection;

        public OrderRepository()
        {
            //sqliteConnection = new SqliteConnection("Data Source=orderdatabase.sqlite;Version=3;");
        }

        public void GetOrders(int customerId)
        {
            var sql = "";
            using (var conn = new SqliteConnection("Data Source=orderdatabase.sqlite;Version=3;"))
            using (var c = new SqliteCommand(sql, conn))
            {
                conn.Open();

            }
        }
    }
}
