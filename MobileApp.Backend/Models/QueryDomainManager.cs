using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using MobileApp.Backend.DataObjects;
using System.Linq;
using System.Data.Entity;
using System.Net.Http;

namespace MobileApp.Backend.Models
{
    public class QueryDomainManager : MappedEntityDomainManager<Query, QueryDBEntity>
    {
        public QueryDomainManager(DbContext context, HttpRequestMessage request) : base(context, request)
        {
        }

        public override Task<bool> DeleteAsync(string id)
        {
            return base.DeleteItemAsync(id);
        }

        public override SingleResult<Query> Lookup(string id)
        {
            MobileServiceContext ctx = this.Context as MobileServiceContext;

            var item = from ai in ctx.Queries
                       where ai.Id == id
                       select new Query
                       {
                           Id = ai.Id,
                           Description = ai.Description,
                           Name = ai.Name,
                           //EventDate = ai.EventDate,
                           Category = ai.Category
                           
                       };
            return new SingleResult<Query>(item);

        }

        public override Task<Query> UpdateAsync(string id, Delta<Query> patch)
        {
            return base.UpdateEntityAsync(patch,id);
        }
    }
}