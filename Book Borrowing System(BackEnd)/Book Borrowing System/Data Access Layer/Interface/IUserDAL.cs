using Business_Object_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Interface
{
    public interface IUserDAL
    {
        public User IsValid(User user);
    }
}
