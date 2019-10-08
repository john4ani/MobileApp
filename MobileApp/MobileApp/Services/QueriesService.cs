using Microsoft.WindowsAzure.MobileServices;
using MobileApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public class QueriesService
    {
        private MobileServiceClient _azClient;
        public QueriesService(MobileServiceClient client)
        {
            _azClient = client;
        }

        public async Task<IEnumerable<Query>> GetReceivedQueries()
        {
            var table = _azClient.GetTable<Query>();
            //#TODO var query = table.Where(qr=>qr.Category == "Subscribed Category" && "Distance from Client to business < client serch radius");
            return await table.ReadAsync();
        }

        public async Task<IEnumerable<Query>> GetSubmittedQueries()
        {
            var table = _azClient.GetTable<Query>();
            //#TODO var query = table.Where(qr=>qr.UserId == "Logged in user id");
            return await table.ReadAsync();
        }

        public async Task<Query> MakeQuery(Query query)
        {
            var table = _azClient.GetTable<Query>();
            await table.InsertAsync(query);
            return query;
        }

        public async Task<IEnumerable<QueryOffer>> GetSubmittedQueryOffers(string submittedQueryId)
        {
            var table = _azClient.GetTable<QueryOffer>();
            var query = table.Where(qr => qr.QueryId == submittedQueryId);
            return await table.ReadAsync(query);
        }

        public async Task<QueryOffer> MakeSubmittedQueryOffer(QueryOffer offer)
        {
            var table = _azClient.GetTable<QueryOffer>();
            await table.InsertAsync(offer);
            return offer;
        }
    }
}
