using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apram.Abstractions.Data;
using Apram.Domain.Inventory;
using Apram.Domain.RFQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Apram.Pages
{
    public class AddRFQModel : PageModel
    {
        private readonly IRFQRepository _repo;

        public AddRFQModel(IRFQRepository repo)
        {
            _repo = repo;
        }
        [BindProperty]
        public RFQ RFQToAdd { get; set; }

        public bool Success { get; set; }
        public bool ShowSuccessStatus { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            ShowSuccessStatus = true;
            try
            {
                _repo.InsertRFQ(RFQToAdd);
                Success = true;
            }
            catch (Exception e)
            {
                Success = false;
            }
        }
    }
}
