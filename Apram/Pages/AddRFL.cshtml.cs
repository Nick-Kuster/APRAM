using System;
using Apram.Abstractions.Data;
using Apram.Domain.RFL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Apram.Pages
{
    public class AddRFLModel : PageModel
    {
        private readonly IRFLRepository _repo;

        public AddRFLModel(IRFLRepository repo)
        {
            _repo = repo;
        }
        [BindProperty]
        public RFL RFLToAdd { get; set; }

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
                _repo.InsertRFL(RFLToAdd);
                Success = true;
            }
            catch(Exception e)
            {
                Success = false;
            }
        }
    }
}
