using Apram.Abstractions.Data;
using Apram.Domain.RFL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Data.InMemory
{
    public class RFLRepository : IRFLRepository
    {
        private List<RFL> rflList { get; set; }

        public RFLRepository()
        {
            rflList = new List<RFL>()
            {
                new RFL(){AircraftType = "Antonov An-28", DateInserted = DateTime.Now, DateNeededStart = DateTime.Now.AddMonths(1), DateNeededEnd = DateTime.Now.AddMonths(2), ID = Guid.NewGuid(), PartDescription = "Landing Gear Wheels", PartNumber = "FGHUI-1989", Quantity = 2, RequestingEntity = "nickkuster@airmostllc.com"},
                new RFL(){AircraftType = "Antonov An-28",DateInserted = DateTime.Now.AddMonths(-1), DateNeededStart = DateTime.Now.AddMonths(4), DateNeededEnd = DateTime.Now.AddMonths(15), ID = Guid.NewGuid(), PartDescription = "Engine Turbine 4", PartNumber = "77-aasiuhi-229A", Quantity = 1, RequestingEntity = "petesasson@airmostllc.com"},
            };
        }
        public List<RFL> GetAllRFLs()
        {
            return rflList;
        }

        public void InsertRFL(RFL rfl)
        {
            rfl.ID = Guid.NewGuid();
            rflList.Add(rfl);
        }
    }
}
