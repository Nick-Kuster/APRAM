using Apram.Abstractions.Data;
using Apram.Domain.PartListing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Data.Database
{
    public class InventoryDBRepository : IPartListingRepository
    {
        public PartListing GetPartListingByIDNumber(Guid partID)
        {
            throw new NotImplementedException();
        }

        public PartListing GetPartListingBySerialNumber(string serialNumber)
        {
            throw new NotImplementedException();
        }

        public List<PartListing> GetPartListings()
        {
            throw new NotImplementedException();
        }

        public void UpdatePartListing(PartListing part)
        {
            throw new NotImplementedException();
        }

        public void UploadPartListing(PartListing part)
        {
            throw new NotImplementedException();
        }
    }
}
