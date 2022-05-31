using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Models;

namespace UserManagementService.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository user;

        public UserController(IUserRepository _user)
        {
            user = _user;
        }
        [HttpGet]
        [Route("User/GetUserByUserId")]
        public UserDetail GetUserByUserId(int userId)
        {
            return user.GetUserByUserId(userId);
        }
        [HttpGet]
        [Route("User/GetAllUsers")]
        public IEnumerable<UserDetail> GetAllUsers()
        {
            return user.GetAllUsers();
        }

        [HttpPost]
        [Route("User/RegisterUser")]
        public UserDetail RegisterUser([FromBody]UserDetail userDetail)
        {
            return user.RegisterUser(userDetail);
        }

        [HttpDelete]
        [Route("User/DeleteUser")]
        public UserDetail DeleteUser(int userId)
        {
            return user.DeleteUser(userId);
        }

        [HttpPut]
        [Route("User/UpdateUser")]
        public UserDetail UpdateUser([FromBody]UserDetail changeUser)
        {
            return user.UpdateUser(changeUser);
        }

        [HttpGet]
        [Route("User/VerifyUser")]
        public bool VerifyUser([FromBody]UserDetail userDetail)
        {
            return user.VerifyUser(userDetail);
        }

        [HttpGet]
        [Route("User/VerifyAdmin")]
        public bool VerifyAdmin([FromBody] UserDetail userDetail)
        {
            return user.VerifyAdmin(userDetail);
        }
    }
}
