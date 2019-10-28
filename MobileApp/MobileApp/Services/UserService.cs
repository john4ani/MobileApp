using Microsoft.WindowsAzure.MobileServices;
using MobileApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public class UserService : IUserService
    {
        private MobileServiceClient _azClient;
        User _loggedInUser;

        public UserService(MobileServiceClient client)
        {
            _azClient = client;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            var table = _azClient.GetTable<User>();
            var query = table.Where(x => x.Email == user.Email);
            var existingUsers = await table.ReadAsync(query);
            if (existingUsers.Count() != 0)
                return false;
            await table.InsertAsync(user);
            return true;
        }

        public async Task<bool> ValidateUserEmailAsync(string email)
        {
            var table = _azClient.GetTable<User>();
            var query = table.Where(x => x.Email == email);
            var existingUsers = await table.ReadAsync(query);
            if (existingUsers.Count() != 0)
                return false;
            return true;
        }

        public async Task<bool> UpdateUserPasswordAsync(string email, string password)
        {
            var table = _azClient.GetTable<User>();
            var query = table.Where(x => x.Email == email && x.Password == password);
            var existingUsers = await table.ReadAsync(query);
            var user = existingUsers.FirstOrDefault();
            if (user != null)
            {
                user.Password = password;
                await table.UpdateAsync(user);
                return true;
            }
            else
                return false;
        }
        public async Task<bool> ValidateLoginAsync(string email, string password)
        {
            var table = _azClient.GetTable<User>();
            var query = table.Where(x => x.Email == email && x.Password == password);
            var existingUsers = await table.ReadAsync(query);
            if (existingUsers.Count() != 0)
            {
                _loggedInUser = existingUsers.First();
                return true;
            }
            else
                return false;
        }

        public async Task<User> GetLoggedInUserAsync()
        {
            return _loggedInUser;
        }
    }
}
