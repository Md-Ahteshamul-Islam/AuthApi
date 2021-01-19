using AuthApi.entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AuthApi.Services
{
    public class UserService
    {
        protected TestDbEntities Context { get; set; }
        public UserService()
        {
            Context = new TestDbEntities();
        }
        public List<User> GetAllUsers()
        {
            List<User> UserList = Context.Users.ToList();
            return UserList;
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            List<User> UserList = await Context.Users.ToListAsync();
            return UserList;
        }
    }
}