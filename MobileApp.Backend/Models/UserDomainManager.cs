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
    public class UserDomainManager : MappedEntityDomainManager<User, UserDBEntity>
    {
        public UserDomainManager(DbContext context, HttpRequestMessage request) : base(context, request)
        {
        }

        public override Task<bool> DeleteAsync(string id)
        {
            return base.DeleteItemAsync(id);
        }

        public override SingleResult<User> Lookup(string id)
        {
            MobileServiceContext ctx = this.Context as MobileServiceContext;

            var item = from ai in ctx.Users
                       where ai.Id == id
                       select new User
                       {
                           Id = ai.Id,
                           CurrentAddress = ai.CurrentAddress,
                           DisplayName = ai.DisplayName,
                           Email = ai.Email,
                           Password = ai.Password
                           
                       };
            return new SingleResult<User>(item);

        }

        public override Task<User> UpdateAsync(string id, Delta<User> patch)
        {
            return base.UpdateEntityAsync(patch,id);
        }
    }
}