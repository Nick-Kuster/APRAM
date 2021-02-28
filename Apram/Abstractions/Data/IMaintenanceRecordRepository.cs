using Apram.Domain.MaintenanceRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Abstractions.Data
{
    public interface IMaintenanceRecordRepository
    {
        public List<MaintenanceRecord> GetMaintenanceRecordsForPart(Guid PartID);
        public void AddMaintenanceRecordList(List<MaintenanceRecord> records);
        public void AddMaintenanceRecord(MaintenanceRecord record);
        public void RemoveMaintenanceRecord(Guid maintenanceID);

    }
}
