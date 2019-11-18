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
        User _loggedInUser;
        public MockUserService()
        {
            _azClient = new List<User>
            {
                new User
                {
                    Id = "a",
                    DisplayName = "User A",
                    CurrentAddress = "Marginea 1960, Suceava",
                    Password = "a",
                    Email = "a"
                }
            };
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
            _loggedInUser = _azClient.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (_loggedInUser != null)
                return true;
            return false;
        }

        public async Task<User> GetLoggedInUserAsync()
        {
            return _loggedInUser;
        }

        public async Task<User> GetUserAsync(string userId)
        {
            return _azClient.FirstOrDefault(u => u.Id == userId);
        }
    }
}
