using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace NetCoreWebAPIs.Order.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Data.IOrderRepository, Data.OrderRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //InitiallySetupDatabase();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void InitiallySetupDatabase()
        {
            var connString = Configuration.GetConnectionString("OrderConnection");
            const string sql = "CREATE TABLE CustomerOrder(OrderId INTEGER PRIMARY KEY ASC NOT NULL, CustomerId INTEGER NOT NULL, TotalPrice REAL NOT NULL, OrderDate TEXT NOT NULL);";
            using (var conn = new SqliteConnection(connString))
            using (var c = new SqliteCommand(sql, conn))
            {
                conn.Open();
                c.ExecuteNonQuery();
                conn.Close();
            }

            const string initialSeedSQL = "INSERT INTO CustomerOrder(CustomerId, TotalPrice, OrderDate) VALUES(@id, 3, '2016-01-01 10:20:05.123')";
            using (var conn = new SqliteConnection(connString))
            using (var c = new SqliteCommand(initialSeedSQL, conn))
            {
                c.Parameters.AddWithValue("@id", 33);
                conn.Open();
                c.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}