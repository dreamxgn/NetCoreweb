using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceA.Classs
{
    public class User
    {
        public string UserName { get; set; }
        public string PassWrod { get; set; }
        public string Token { get; set; }

        public List<string> Orders { get; set; }
    }
}
