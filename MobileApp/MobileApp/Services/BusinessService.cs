using MobileApp.Models;
using MobileApp.Repositories;
using System.Threading.Tasks;
using System.Linq;

namespace MobileApp.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _repository;

        public BusinessService(IBusinessRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddBusinessAsync(Business business)
        {
            return await _repository.AddBusinessAsync(business);
        }

        public async Task<bool> ValidateBusinessAsync(string businessNumber)
        {
            var businesses = await _repository.GetAll();
            return businesses.Any(b=>b.RegistrationNumber == businessNumber);
        }
    }
}
