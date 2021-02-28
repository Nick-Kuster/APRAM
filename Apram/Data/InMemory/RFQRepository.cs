using Apram.Abstractions.Data;
using Apram.Domain.RFQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Data.InMemory
{
    public class RFQRepository : IRFQRepository
    {
        private List<RFQ> rfqList { get; set; }
        public RFQRepository()
        {
            rfqList = new List<RFQ>()
            {
                new RFQ(){AircraftType = "Antonov An-28", DateInserted = DateTime.Now, ID = Guid.NewGuid(), PartDescription = "Wheel Bearing", PartNumber = "AHUIY-7869", RequestingEntity = "nickkuster@airmostllc.com"},
                new RFQ(){AircraftType = "Antonov An-28", DateInserted = DateTime.Now.AddDays(-14), ID = Guid.NewGuid(), PartDescription = "Window Pane", PartNumber = "FHIU-9587", RequestingEntity = "petesasson@airmostllc.com"},
            };
        }
        public List<RFQ> GetAllRFQs()
        {
            return rfqList;
        }

        public void InsertRFQ(RFQ rfq)
        {
            rfq.ID = Guid.NewGuid();
            rfqList.Add(rfq);
        }
    }
}
