using Business_Object_Layer;
using Data_Access_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Access_Layer
{
    public class UserDAL : IUserDAL
    {
        private readonly ApplicationDbContext _context;

        public UserDAL(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public User GetUserNameById(int id)
        {
            var name = _context.Users.ToList().FirstOrDefault(r => r.UserId == id);
            return name;
        }

        public User IsValid(User user)
        {
            var query = (_context.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password));

            if (query != null)
            {
                User userDal = query;
                return userDal;
            }
            return null;
        }
    }
}
