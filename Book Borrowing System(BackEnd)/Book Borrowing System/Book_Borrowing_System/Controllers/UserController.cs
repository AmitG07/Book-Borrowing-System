using Book_Borrowing_System.Helper;
using Book_Borrowing_System.Models;
using Business_Layer.Interface;
using Business_Object_Layer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Borrowing_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBl;

        public UserController(IUserBL userBl)
        {
            _userBl = userBl;
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("login/post")]
        public Object Post(UserLogin val)
        {
            if (ModelState.IsValid)
            {
                User user = new UserLoginToUserHelper().UserLoginToUserMapping(val);
                var userdummy = _userBl.IsValid(user);
                if (userdummy != null)
                {
                    return userdummy;
                }
                else
                    return new { msg = "no match" };
            }
            return new { msg = "no fill" };
        }

        [HttpGet("{id}")]
        [Route("GetUserNameById/{id}")]
        public UserModel GetUserNameById(int id)
        {
            User user = _userBl.GetUserNameById(id);
            if (user != null)
            {
                var prod = new UserToUserModelHelper().UserToUserModelMapping(user);
                return prod;
            }
            return null;
        }
    }
}

