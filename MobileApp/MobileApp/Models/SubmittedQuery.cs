
namespace MobileApp.Models
{
    public class SubmittedQuery : Query
    {
        public SubmittedQuery()
        {

        }
        public SubmittedQuery(Query query)
        {
            Id = query.Id;
            Name = query.Name;
            UserId = query.UserId;
            Category = query.Category;
            Description = query.Description;
            NeedsDelivery = query.NeedsDelivery;
            EventDate = query.EventDate;
        }
        public int OffersCount { get; set; }
    }
}
