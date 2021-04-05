using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Objects
{
    public class Register
    {
        public Register()
        {

        }

        public string FullName { get; set; }
        public string Birth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
