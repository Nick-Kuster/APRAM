using Apram.Abstractions.Data;
using Apram.Domain.PartListing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Data.InMemory
{
    public class PartListingRepository : IPartListingRepository
    {
        
        public List<PartListing> Parts { get;set; }

        public PartListingRepository()
        {
            Parts = new List<PartListing>()
            {
                new PartListing(){ID = Guid.NewGuid(),AircraftType = "Antonov An-28",  SellingEntity = "nkuster@airmostllc.com",Description="Part 1", ImageLocation=$@"C:\Par1.img", SerialNumber="A12-fg-cde" },
                new PartListing(){ID = Guid.NewGuid(),AircraftType = "Antonov An-28",  SellingEntity = "Eastern Air", Description="Part 6", ImageLocation=$@"C:\Par6.img", SerialNumber="A12-fg-cde" },
                new PartListing(){ID = Guid.NewGuid(),AircraftType = "Beechcraft Model 18",  SellingEntity = "Pull-a-part", Description="Part 2", ImageLocation=$@"C:\Par2.img", SerialNumber="K312-f1123g-abc" },
                new PartListing(){ID = Guid.NewGuid(),AircraftType = "Beechcraft Model 18",  SellingEntity = "private seller", Description="Part 3", ImageLocation=$@"C:\Par3.img", SerialNumber="45kh-1245-12l" },
                new PartListing(){ID = Guid.NewGuid(),AircraftType = "Cessna 340",  SellingEntity = "Bob's Parts" , Description="Part 4", ImageLocation=$@"C:\Par4.img", SerialNumber="687459-fg-asdf" },
                new PartListing(){ID = Guid.NewGuid(),AircraftType = "Cessna 340",  SellingEntity = "Bob's Parts", Description="Part 5", ImageLocation=$@"C:\Par5.img", SerialNumber="1235l-asd-fiujh" }
            };
        }

        public PartListing GetPartListingByIDNumber(Guid partID)
        {
            return Parts.FirstOrDefault(x => x.ID == partID);
        }

        public PartListing GetPartListingBySerialNumber(string serialNumber)
        {
            return Parts.FirstOrDefault(x => x.SerialNumber == serialNumber);
        }

        public List<PartListing> GetPartListings()
        {
            return Parts;
        }

        public void UpdatePartListing(PartListing part)
        {
            var toUpdate = Parts.FirstOrDefault(x => x.Equals(part));
            toUpdate = part;
        }

        public void UploadPartListing(PartListing part)
        {
            if(part.SerialNumber != null)
            {
                part.ID = Guid.NewGuid();
                Parts.Add(part);
            }
        }
    }
}
