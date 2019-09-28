using System;


namespace MobileApp.Models
{
    public class Query
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }

        protected Query()
        {

        }
    }
}