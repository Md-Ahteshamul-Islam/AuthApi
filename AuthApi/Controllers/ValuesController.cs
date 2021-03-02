using AuthApi.CustomAttribute;
using AuthApi.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AuthApi.Services;
using System.Web.Http.Cors;

namespace AuthApi.Controllers
{
    //CORS-ORIGIN Help: https://www.c-sharpcorner.com/article/enable-cors-in-asp-net-webapi-2/

    //work on : https://stackoverflow.com/questions/56950277/enable-cors-in-angular-6-and-asp-net

    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTION")]
    public class ValuesController : ApiController
    {
        protected TestDbEntities Context { get; set; }
        private UserService UserService { get; set; }
        public ValuesController()
        {
            Context = new TestDbEntities();
            UserService = new UserService();
        }
        // GET api/values


        [BasicAuthentication]
        public async Task<List<User>> Get()
        {
            List<User> UserList = await UserService.GetAllUsersAsync();
            return UserList;
        }

        // GET api/values/5
        public async Task<User> Get(int id)
        {
            return await UserService.GetAllUsersByIdAsync(id);
        }

        // POST api/values
        public async Task<List<User>> Post(User user)
        {
            List<User> UserList = await UserService.SaveUserAsync(user);
            return UserList;
        }

        // PUT api/values/5
        public async Task<bool> Put(User user)
        {
            return await UserService.UpdateUserAsync(user);
        }

        // DELETE api/values/5
        public async Task<bool> Delete(int id)
        {
            return await UserService.DeleteUserAsync(id);
        }
    }
}
