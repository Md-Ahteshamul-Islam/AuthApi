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
        public async Task<User> GetAllUsersByIdAsync(int Id)
        {
            User User = await Context.Users
                                    .Where(d => d.id == Id)
                                    .FirstOrDefaultAsync();
            return User;
        }
        public async Task<List<User>> SaveUserAsync(User user)
        {
            Context.Users.Add(user);
            await Context.SaveChangesAsync();

            return await GetAllUsersAsync();
        }
        public async Task<bool> UpdateUserAsync(User user)
        {
            bool hasSucceed = false;
            User User = await Context.Users
                                    .Where(d => d.id == user.id)
                                    .FirstOrDefaultAsync();
            if(User != null)
            {
                User.UserName = user.UserName;
                User.FullName = user.FullName;
                User.Mobile = user.Mobile;
                User.email = user.email;
                User.IsActive = user.IsActive;
                User.Password = user.Password;

                Context.SaveChanges();

                hasSucceed = true;
            }

            return hasSucceed;
        }
        public async Task<bool> DeleteUserAsync(int Id)
        {
            bool hasSucceed = false;
            try
            {
                User User = await Context.Users
                                        .Where(d => d.id == Id)
                                        .FirstOrDefaultAsync();
                Context.Users.Remove(User);
                await Context.SaveChangesAsync();

                hasSucceed = true;
            }
            catch (Exception ex)
            {
                hasSucceed = false;
            }

            return hasSucceed;
        }
    }
}