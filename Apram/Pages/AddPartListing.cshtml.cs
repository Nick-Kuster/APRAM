using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Apram.Abstractions.Data;
using Apram.Domain.MaintenanceRecord;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Apram.Services.Extensions;
using Apram.Domain.PartListing;

namespace Apram.Pages
{
    public class AddUserInventoryModel : PageModel
    {
        private readonly IPartListingRepository _inventoryRepo;
        private readonly IMaintenanceRecordRepository _maintenanceRecordRepository;

        public AddUserInventoryModel(IPartListingRepository inventoryRepo, IMaintenanceRecordRepository maintenanceRecordRepository)
        {
            _inventoryRepo = inventoryRepo;
            _maintenanceRecordRepository = maintenanceRecordRepository;
        }
        [BindProperty]
        public PartListing PartToAdd { get; set; }
        
        [BindProperty]
        public IFormFile MaintenanceRecordFile { get; set; }

        public bool FileUploadSuccessful { get; set; }
        public bool ShowFileUploadStatus { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            ShowFileUploadStatus = true;
            try
            {
                _inventoryRepo.UploadPartListing(PartToAdd);
                List<MaintenanceRecord> maintenanceRecords =
                                            MaintenanceRecordFile.ReadAsList()
                                           .Skip(1)
                                           .Select(csvLine =>
                                           {
                                               string[] values = csvLine.Split(",");
                                               return new MaintenanceRecord() {
                                                   Date = Convert.ToDateTime(values[0]),
                                                   Type = values[1],
                                                   Miles = Convert.ToInt32(values[2]),
                                                   MaintenanceProvider = values[3]
                                                }; 
                                            })                                                    
                                           .ToList();

                foreach(var record in maintenanceRecords)
                {
                    record.PartID = PartToAdd.ID;
                }
                _maintenanceRecordRepository.AddMaintenanceRecordList(maintenanceRecords);
                FileUploadSuccessful = true;
            }
            catch(Exception e)
            {
                FileUploadSuccessful = false;
            }
        }
    }
}
