using Apram.Abstractions.Data;
using Apram.Domain.MaintenanceRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Data.InMemory
{
    public class MaintenanceRecordRepository : IMaintenanceRecordRepository
    {
        public List<MaintenanceRecord> Records { get; set; }

        public MaintenanceRecordRepository()
        {
            Records = new List<MaintenanceRecord>();
        }

        public List<MaintenanceRecord> GetMaintenanceRecordsForPart(Guid PartID)
        {
            return Records.Where(x => x.PartID == PartID).ToList();
        }

        public void AddMaintenanceRecordList(List<MaintenanceRecord> records)
        {
            foreach(var record in records)
            {
                record.ID = Guid.NewGuid();
            }
            Records.AddRange(records);
        }

        public void AddMaintenanceRecord(MaintenanceRecord record)
        {
            Records.Add(record);
        }

        public void RemoveMaintenanceRecord(Guid maintenanceID)
        {
            var toRemove = Records.FirstOrDefault(x => x.ID == maintenanceID);
            Records.Remove(toRemove);
        }
    }
}
