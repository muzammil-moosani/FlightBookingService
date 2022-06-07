using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Models;

namespace UserManagementService.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserRepository user;

        public UserController(IUserRepository _user)
        {
            user = _user;
        }
        [HttpGet("GetUserByUserId/{userId}")]
        public UserDetail GetUserByUserId(int userId)
        {
            return user.GetUserByUserId(userId);
        }
        [HttpGet]
        public IEnumerable<UserDetail> GetAllUsers()
        {
            return user.GetAllUsers();
        }

        [HttpPost("RegisterUser/{userDetail}")]
        public UserDetail RegisterUser([FromBody]UserDetail userDetail)
        {
            return user.RegisterUser(userDetail);
        }

        [HttpDelete("DeleteUser/{userId}")]
        public UserDetail DeleteUser(int userId)
        {
            return user.DeleteUser(userId);
        }

        [HttpPut("UpdateUser/{changeUser}")]
        public UserDetail UpdateUser([FromBody]UserDetail changeUser)
        {
            return user.UpdateUser(changeUser);
        }

        [HttpGet("VerifyUser/{userDetail}")]
        [Route("User/VerifyUser")]
        public bool VerifyUser([FromBody]UserDetail userDetail)
        {
            return user.VerifyUser(userDetail);
        }

        [HttpGet("VerifyAdmin/{userDetail}")]
        public bool VerifyAdmin([FromBody] UserDetail userDetail)
        {
            return user.VerifyAdmin(userDetail);
        }
    }
}
