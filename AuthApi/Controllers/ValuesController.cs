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

namespace AuthApi.Controllers
{
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
