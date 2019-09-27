using Microsoft.Azure.Mobile.Server;
using MobileApp.Backend.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileApp.Backend.DataObjects
{
    public class QueryReplay : EntityData
    {
        public string Bidder { get; set; }
        public string Description { get; set; }
        public double OfferPrice { get; set; }
        

        [Column("Query_Id")]
        public string QueryId { get; set; }

        [ForeignKey("QueryId")]
        public virtual QueryDBEntity Query { get; set; }
    }
}