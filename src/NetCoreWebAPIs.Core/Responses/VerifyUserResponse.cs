using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreWebAPIs.Core.Responses
{
    public class VerifyUserResponse
    {
        public bool Authenticated { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
    }
}