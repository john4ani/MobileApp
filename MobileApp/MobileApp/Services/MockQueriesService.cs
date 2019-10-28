using Microsoft.WindowsAzure.MobileServices;
using MobileApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public class MockQueriesService : IQueriesService
    {
        List<Query> _queries;
        List<QueryOffer> _queriesOffers;

        public MockQueriesService()
        {
            _queries = new List<Query>();
            _queriesOffers = new List<QueryOffer>();
        }

        public async Task<IEnumerable<Query>> GetReceivedQueries()
        {
            return _queries;
        }

        public async Task<IEnumerable<Query>> GetSubmittedQueries()
        {
            return _queries.Where(q=>q.UserId == App.GetUserService().GetLoggedInUserAsync().Result.Id);
        }

        public async Task<Query> MakeQuery(Query query)
        {
            _queries.Add(query);
            return query;
        }

        public async Task<IEnumerable<QueryOffer>> GetSubmittedQueryOffers(string submittedQueryId)
        {
            
            return _queriesOffers.Where(qo=>qo.QueryId == submittedQueryId);
        }

        public async Task<QueryOffer> MakeSubmittedQueryOffer(QueryOffer offer)
        {
            _queriesOffers.Add(offer);
            return offer;
        }

        public async Task<QueryOffer> UpdateQueryOfferAsync(QueryOffer offer)
        {
            var repoOffer = _queriesOffers.Where(qo => qo.Id == offer.Id).FirstOrDefault();
            if(repoOffer != null)
            {
                repoOffer.OfferPrice = offer.OfferPrice;
                repoOffer.Status = offer.Status;
            }
            return repoOffer;
        }
    }
}
