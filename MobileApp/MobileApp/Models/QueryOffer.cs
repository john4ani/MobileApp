namespace MobileApp.Models
{
    public class QueryOffer
    {
        public string Id { get; set; }
        public string QueryId { get; set; }
        public string Bidder { get; set; }
        public string Description { get; set; }
        public double OfferPrice { get; set; }
        public OfferStatus Status { get; set; }
    }

    public enum OfferStatus
    {
        Submitted,
        Accepted,
        Irrelevant
    }
}