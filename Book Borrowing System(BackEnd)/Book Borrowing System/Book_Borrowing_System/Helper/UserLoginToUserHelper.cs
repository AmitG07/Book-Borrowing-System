using Book_Borrowing_System.Models;
using Business_Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Borrowing_System.Helper
{
    public class UserLoginToUserHelper
    {
        public User UserLoginToUserMapping(UserLogin e)
        {
            User u = new User();
            u.Username = e.Username;
            u.Password = e.Password;
            return u;
        }
    }
}
