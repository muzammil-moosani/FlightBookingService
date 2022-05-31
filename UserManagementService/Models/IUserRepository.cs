using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Models
{
    public interface IUserRepository
    {
        UserDetail RegisterUser(UserDetail user);
        IEnumerable<UserDetail> GetAllUsers();
        UserDetail GetUserByUserId(int userId);
        UserDetail UpdateUser(UserDetail changeUser);
        UserDetail DeleteUser(int userId);
        bool VerifyUser(UserDetail user);
        bool VerifyAdmin(UserDetail userDetail);
    }
}
