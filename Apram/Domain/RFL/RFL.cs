using System;

namespace Apram.Domain.RFL
{
    public class RFL
    {
        public Guid ID { get; set; }
        public int Quantity { get; set; }
        public string AircraftType { get; set; }
        public int ResponseCount { get; set; }
        public string RequestingEntity { get; set; }
        public DateTime DateInserted { get; set; }
        public DateTime DateNeededStart { get; set; }
        public DateTime DateNeededEnd { get; set; }
        public string PartNumber { get; set; }
        public string PartDescription { get; set; }
    }
}
