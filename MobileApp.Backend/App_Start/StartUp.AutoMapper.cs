using MobileApp.Backend.DataObjects;
using MobileApp.Backend.Models;
using System.Web.Http;

namespace MobileApp.Backend.App_Start
{
    public partial class StartUp
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