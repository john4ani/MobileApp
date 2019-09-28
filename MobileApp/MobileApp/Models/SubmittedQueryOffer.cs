namespace MobileApp.Models
{
    public class SubmittedQueryOffer
    {
        public string Id { get; set; }
        public string SubmittedQueryId { get; set; }
        public string Bidder { get; set; }
        public string Description { get; set; }
        public double OfferPrice { get; set; }     
    }
}