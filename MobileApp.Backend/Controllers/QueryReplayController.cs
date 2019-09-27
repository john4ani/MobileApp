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
    public class QueryReplayController : TableController<QueryReplay>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<QueryReplay>(context, Request);
        }

        // GET tables/QueryReplay
        public IQueryable<QueryReplay> GetAllQueryReplay()
        {
            return Query(); 
        }

        // GET tables/QueryReplay/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<QueryReplay> GetQueryReplay(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/QueryReplay/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<QueryReplay> PatchQueryReplay(string id, Delta<QueryReplay> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/QueryReplay
        public async Task<IHttpActionResult> PostQueryReplay(QueryReplay item)
        {
            QueryReplay current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/QueryReplay/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteQueryReplay(string id)
        {
             return DeleteAsync(id);
        }
    }
}
