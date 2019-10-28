using Microsoft.WindowsAzure.MobileServices;
using MobileApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MobileApp.Services
{
    public class QueriesService : IQueriesService
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

        public async Task<QueryOffer> UpdateQueryOfferAsync(QueryOffer offer)
        {
            var table = _azClient.GetTable<QueryOffer>();
            var query = table.Where(qo => qo.Id == offer.Id);
            var existingQuery = await table.ReadAsync(query);
            if (existingQuery.Count() == 1)
            {
                var existingQueryObject = existingQuery.First();
                existingQueryObject.OfferPrice = offer.OfferPrice;
                existingQueryObject.Status = offer.Status;

                await table.UpdateAsync(existingQueryObject);

                return existingQueryObject;
            }
            return null;
        }
    }
}
