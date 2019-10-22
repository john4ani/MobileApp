using Microsoft.Azure.Mobile.Server;


namespace MobileApp.Backend.DataObjects
{
    public class Query : EntityData
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        //public DateTime EventDate { get; set; }
    }
}