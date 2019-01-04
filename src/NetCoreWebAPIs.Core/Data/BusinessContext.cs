using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreWebAPIs.Core.Data
{
    public class BusinessContext : DbContext
    {

        public BusinessContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}