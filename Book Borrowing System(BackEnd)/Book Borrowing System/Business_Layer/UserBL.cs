using Business_Layer.Interface;
using Business_Object_Layer;
using Data_Access_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAL _userDal;

        public UserBL(IUserDAL userDal)
        {
            _userDal = userDal;
        }

        public User GetUserNameById(int id)
        {
            var name = _userDal.GetUserNameById(id);
            return name;
        }

        public User IsValid(User user)
        {
            var u = _userDal.IsValid(user);
            if (u != null)
                return u;
            else
                return null;
        }
    }
}
