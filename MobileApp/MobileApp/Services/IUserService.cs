using System.Threading.Tasks;
using MobileApp.Models;

namespace MobileApp.Services
{
    public interface IUserService
    {
        Task<bool> AddUserAsync(User user);
        Task<bool> UpdateUserPasswordAsync(string email, string password);
        Task<bool> ValidateLoginAsync(string email, string password);
        Task<bool> ValidateUserEmailAsync(string email);
    }
}