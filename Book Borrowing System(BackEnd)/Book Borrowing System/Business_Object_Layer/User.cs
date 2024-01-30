using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Object_Layer
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Tokens_Available { get; set; }
    }
}
