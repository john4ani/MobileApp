using System;

namespace MobileApp.Models
{
    public interface IQuery
    {
        string Category { get; set; }
        string DeliveryAddress { get; set; }
        string Description { get; set; }
        DateTime EventDate { get; set; }
        string Id { get; set; }
        string Name { get; set; }
        bool NeedsDelivery { get; set; }
        string UserId { get; set; }
    }
}