using Business_Object_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer.Interface
{
    public interface IUserBL
    {
        public User IsValid(User user);
        public User GetUserNameById(int id);
    }
}
