using Microsoft.Azure.Mobile.Server;
using MobileApp.Backend.DataObjects;
using System;
using System.Collections.ObjectModel;

namespace MobileApp.Backend.Models
{
    public class QueryDBEntity : EntityData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }

        public virtual Collection<QueryReplay> Bids { get; set; }
    }
}