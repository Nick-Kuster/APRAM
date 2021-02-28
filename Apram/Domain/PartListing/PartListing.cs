using System;

namespace Apram.Domain.PartListing
{
    public class PartListing : IEquatable<PartListing>
    {
        public Guid ID { get; set; }
        public string SellingEntity { get; set; }
        public string AircraftType { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public string ImageLocation { get; set; }

        public bool Equals(PartListing other)
        {
            return other.ID == ID;
        }
    }
}
