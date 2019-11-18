using System;


namespace MobileApp.Models
{
    public class Query
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public bool NeedsDelivery { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime EventDate { get; set; }        

        public Query()
        {

        }
    }
}