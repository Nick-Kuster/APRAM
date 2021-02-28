using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Domain.RFQ
{
    public class RFQ
    {
        public Guid ID { get; set; }
        public string RequestingEntity { get; set; }
        public string AircraftType { get; set; }
        public DateTime DateInserted { get; set; }
        public string PartNumber { get; set; }
        public string PartDescription { get; set; }
        public int ResponseCount { get; set; }
    }
}
