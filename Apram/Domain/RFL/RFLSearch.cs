using System;

namespace Apram.Domain.RFL
{
    public class RFLSearch
    {
        public string AircraftType { get; set; }
        public int ResponseCount { get; set; }
        public string RequestingEntity { get; set; }
        public DateTime DateInserted { get; set; }
        public DateTime DateNeededStart { get; set; }
        public DateTime DateNeededEnd { get; set; }
        public string PartSerialNumber { get; set; }
        public string PartDescription { get; set; }
    }
}
