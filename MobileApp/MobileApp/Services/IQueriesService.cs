using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApp.Models;

namespace MobileApp.Services
{
    public interface IQueriesService
    {
        Task<IEnumerable<Query>> GetReceivedQueries();
        Task<IEnumerable<Query>> GetSubmittedQueries();
        Task<IEnumerable<QueryOffer>> GetSubmittedQueryOffers(string submittedQueryId);
        Task<Query> MakeQuery(Query query);
        Task<QueryOffer> MakeSubmittedQueryOffer(QueryOffer offer);
    }
}