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

        public async Task<IEnumerable<ReceivedQuery>> GetReceivedQueries()
        {
            var table = _azClient.GetTable<ReceivedQuery>();
            return await table.ReadAsync();
        }

        public async Task<IEnumerable<SubmittedQuery>> GetSubmittedQueries()
        {
            var table = _azClient.GetTable<SubmittedQuery>();
            return await table.ReadAsync();
        }

        public async Task<IEnumerable<SubmittedQueryOffer>> GetSubmittedQueryOffers(string submittedQueryId)
        {
            var table = _azClient.GetTable<SubmittedQueryOffer>();
            var query = table.Where(qr=>qr.SubmittedQueryId == submittedQueryId);
            return await table.ReadAsync(query);
        }

        public async Task<SubmittedQueryOffer> MakeSubmittedQueryOffer(SubmittedQueryOffer offer)
        {
            var table = _azClient.GetTable<SubmittedQueryOffer>();
            await table.InsertAsync(offer);
            return offer;
        }
    }
}
