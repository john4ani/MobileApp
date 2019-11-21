using MobileApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileApp.Repositories
{
    public class BusinessRepository : IBusinessRepository
    {
        List<Business> _repo = new List<Business>();

        public async Task<bool> AddBusinessAsync(Business business)
        {
            _repo.Add(business);
            return true;
        }

        public async Task<IEnumerable<Business>> GetAll()
        {
            return _repo;
        }
        
    }
}
