using Microsoft.WindowsAzure.MobileServices;
using MobileApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public class MockUserService : IUserService
    {
        List<User> _azClient;
        public MockUserService()
        {
            _azClient = new List<User>();
        }

        public async Task<bool> AddUserAsync(User user)
        {
            if (_azClient.Exists(u=>u.Email == user.Email))
                return false;
            _azClient.Add(user);
            return true;
        }

        public async Task<bool> ValidateUserEmailAsync(string email)
        {
            if (_azClient.Exists(u => u.Email == email))
                return false;
            return true;
        }

        public async Task<bool> UpdateUserPasswordAsync(string email, string password)
        {
            return true;
        }
        public async Task<bool> ValidateLoginAsync(string email, string password)
        {
            if (_azClient.Exists(u => u.Email == email && u.Password == password))
                return true;
            return false;
        }
    }
}
