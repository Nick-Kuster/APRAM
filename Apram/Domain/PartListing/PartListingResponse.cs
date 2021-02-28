using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Domain.PartListing
{
    public class PartListingResponse
    {
        public Guid ID { get; set; }
        public Guid PartListingID { get; set; }
        public int MessageCount { get; set; }
        public string ResponderEntity { get; set; }
        public string RequestorEntity { get; set; }
        public PartListing ParentListing { get; set; }
    }
}
