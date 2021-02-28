using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apram.Abstractions.Data;
using Apram.Domain.MaintenanceRecord;
using Apram.Domain.PartListing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Apram.Pages
{
    public class ViewPartListingModel : PageModel
    {
        private readonly IPartListingRepository _partListingRepository;
        private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;

        public ViewPartListingModel(IPartListingRepository inventoryRepository, IMaintenanceRecordRepository maintenanceRecordRepository)
        {
            _partListingRepository = inventoryRepository;
            _maintenanceRecordRepository = maintenanceRecordRepository;
        }

        public PartListing Part { get; set; }
        public List<MaintenanceRecord> MaintenanceRecords { get; set; }

        public void OnGet(Guid partID)
        {
            Part = _partListingRepository.GetPartListingByIDNumber(partID);
            MaintenanceRecords = _maintenanceRecordRepository.GetMaintenanceRecordsForPart(partID);
        }
    }
}
