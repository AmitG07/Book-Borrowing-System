using Book_Borrowing_System.Models;
using Business_Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Borrowing_System.Helper
{
    public class UserToUserModelHelper
    {
        public UserModel UserToUserModelMapping(User e)
        {
            UserModel u = new UserModel();
            u.Name = e.Name;
            u.Username = e.Username;
            u.Password = e.Password;
            u.Tokens_Available = e.Tokens_Available;
            return u;
        }
    }
}

