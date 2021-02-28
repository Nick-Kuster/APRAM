using Apram.Domain.PartListing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Abstractions.Data
{
    public interface IPartListingRepository
    {
        public List<PartListing> GetPartListings();
        public PartListing GetPartListingBySerialNumber(string serialNumber);
        public PartListing GetPartListingByIDNumber(Guid partID);
        public void UploadPartListing(PartListing part);
        public void UpdatePartListing(PartListing part);
    }
}
