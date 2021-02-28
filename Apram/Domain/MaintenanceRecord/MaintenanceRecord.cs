using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Domain.MaintenanceRecord
{
    public class MaintenanceRecord
    {
        public Guid ID { get; set; }
        public Guid PartID { get; set; }
        public string MaintenanceProvider { get; set; }
        public string Type { get; set; }
        public int Miles { get; set; }
        public DateTime Date { get; set; }
    }
}
