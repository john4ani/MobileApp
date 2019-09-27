using Microsoft.WindowsAzure.MobileServices;
using MobileApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileApp
{
    public class QueringService
    {
        private static MobileServiceClient _azClient;
        public QueringService(string serviceBaseUrl)
        {
            _azClient = new MobileServiceClient(serviceBaseUrl);
        }

        public async Task<IEnumerable<Query>> GetQueries()
        {
            var table = _azClient.GetTable<Query>();
            return await table.ReadAsync();
        }

        public async Task<IEnumerable<QueryReplay>> GetQueryReplays(string queryId)
        {
            var table = _azClient.GetTable<QueryReplay>();
            var query = table.Where(qr=>qr.QueryId == queryId);
            return await table.ReadAsync(query);
        }
    }
}
