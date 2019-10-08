using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using MobileApp.Backend.DataObjects;
using MobileApp.Backend.Models;

namespace MobileApp.Backend.Controllers
{
    public class QueryController : TableController<Query>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new QueryDomainManager(context, Request);
        }

        // GET tables/Query
        public IQueryable<Query> GetAllQuery()
        {
            return Query(); 
        }

        // GET tables/Query/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Query> GetQuery(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Query/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Query> PatchQuery(string id, Delta<Query> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Query
        public async Task<IHttpActionResult> PostQuery(Query item)
        {
            Query current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Query/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteQuery(string id)
        {
             return DeleteAsync(id);
        }
    }
}
