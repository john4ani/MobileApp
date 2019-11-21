using MobileApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileApp.Repositories
{
    public interface IBusinessRepository
    {
        Task<IEnumerable<Business>> GetAll();
        Task<bool> AddBusinessAsync(Business business);
    }
}