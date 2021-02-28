using System;

namespace Apram.Domain.RFL
{
    public class RFLResponse
    {
        public Guid ID { get; set; }
        public Guid RequestID { get; set; }
        public int MessageCount { get; set; }
        public string ResponderEntity { get; set; }
        public string RequestorEntity { get; set; }
        public decimal QuotePrice { get; set; }
    }
}
