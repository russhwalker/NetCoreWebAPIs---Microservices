using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Order.WebAPI.Data
{
    public static class DataStore
    {
        public static List<Core.Models.Order> Orders = new List<Core.Models.Order>();
    }
}
