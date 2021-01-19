using AuthApi.entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AuthApi.Services
{
    public class AuthService
    {
        protected TestDbEntities Context { get; set; }
        public AuthService()
        {
            Context = new TestDbEntities();
        }
        public bool IsAuthorizedUser(string Username, string Password)
        {
            return Context.Users.Any(u => u.UserName == Username && u.Password == Password);
            //return Username == "Rocky" && Password == "Pass1";
        }
    }
}