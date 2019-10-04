using MobileApp.Backend.DataObjects;
using MobileApp.Backend.Models;
using System.Web.Http;

namespace MobileApp.Backend
{
    public partial class Startup
    {
        public static void ConfigureAutoMapper(HttpConfiguration httpConfiguration)
        {
            AutoMapper.Mapper.Initialize(cfg=>
            {
                cfg.CreateMap<Query, QueryDBEntity>();
            });
        }
    }
}