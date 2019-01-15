using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Core.Responses
{
    public class AuthResponse
    {
        public bool Authenticated { get; set; }
        public string TokenContent { get; set; }
    }
}