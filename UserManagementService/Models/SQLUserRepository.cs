using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementService.Models
{
    public class SQLUserRepository : IUserRepository
    {
        private AppDbContext context;
        public SQLUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public UserDetail DeleteUser(int userId)
        {
            UserDetail details = context.UserDetail.Find(userId);
            if (details != null)
            {
                context.Remove(details);
                context.SaveChanges();
            }
            return details;
        }

        public IEnumerable<UserDetail> GetAllUsers()
        {
            return context.UserDetail;
        }

        public UserDetail GetUserByUserId(int userId)
        {
            return context.UserDetail.Where(n => n.UserId == userId).First();
        }

        public UserDetail RegisterUser(UserDetail user)
        {
            context.UserDetail.Add(user);
            context.SaveChanges();
            return user;
        }

        public UserDetail UpdateUser(UserDetail changeUser)
        {
            var details = context.UserDetail.Attach(changeUser);
            details.State = EntityState.Modified;
            context.SaveChanges();
            return changeUser;
        }

        public bool VerifyAdmin(UserDetail userDetail)
        {
            bool isExist = context.UserDetail.Any(n => n.Email == userDetail.Email && n.Password == userDetail.Password && n.IsAdmin == true);
            return isExist;
        }

        public bool VerifyUser(UserDetail user)
        {
            bool isExist = context.UserDetail.Any(n => n.Email == user.Email && n.Password == user.Password);
            return isExist;
        }
    }
}
