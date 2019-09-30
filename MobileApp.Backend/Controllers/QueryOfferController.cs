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
    public class QueryOfferController : TableController<QueryOffer>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<QueryOffer>(context, Request);
        }

        // GET tables/QueryOffer
        public IQueryable<QueryOffer> GetAllOffers()
        {
            return Query(); 
        }

        // GET tables/QueryOffer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<QueryOffer> GetQueryOffer(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/QueryOffer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<QueryOffer> PatchQueryOffer(string id, Delta<QueryOffer> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/QueryOffer
        public async Task<IHttpActionResult> PostQueryOffer(QueryOffer item)
        {
            QueryOffer current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/QueryOffer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteQueryOffer(string id)
        {
             return DeleteAsync(id);
        }
    }
}
