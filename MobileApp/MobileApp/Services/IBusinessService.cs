using MobileApp.Models;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public interface IBusinessService
    {
        Task<bool> ValidateBusinessAsync(string businessNumber);
        Task<bool> AddBusinessAsync(Business business);
    }
}
