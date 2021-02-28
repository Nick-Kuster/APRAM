using System;

namespace Apram.Domain.RFQ
{
    public class RFQSearch
    {
        public string RequestingEntity { get; set; }
        public string AircraftType { get; set; }
        public DateTime DateInserted { get; set; }
        public string PartSerialNumber { get; set; }
        public string PartDescription { get; set; }
        public int ResponseCount { get; set; }
    }
}
