using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apram.Abstractions.Data;
using Apram.Domain.Messages;
using Apram.Domain.PartListing;
using Apram.Services.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Apram.Pages
{
    public class RespondToPartListing : PageModel
    {
        private readonly IPartListingResponseRepository _responseRepo;
        private readonly IMessageRepository _messageRepo;

        public Guid PartListingID { get; set; }

        [BindProperty]
        public PartListingResponse ResponseToAdd { get; set; }
        [BindProperty]
        public Message MessageToAdd { get; set; }

        public RespondToPartListing(IPartListingResponseRepository responseRepo, IMessageRepository messageRepo)
        {
            _responseRepo = responseRepo;
            _messageRepo = messageRepo;
        }
        public void OnGet(Guid parentID)
        {
            PartListingID = parentID;
        }

        public IActionResult OnPost()
        {
            try
            {
                _responseRepo.AddResponse(ResponseToAdd);
                MessageToAdd.Type = MessageType.Inventory;
                MessageToAdd.ParentID = ResponseToAdd.ID;
                _messageRepo.AddMessage(MessageToAdd);
                TempData["Message"] = "You have responded to the RFL";
                TempData["MessageClass"] = "bg-success";
                return new RedirectToPageResult("BrowseRFL");
            }
            catch (Exception e)
            {
                TempData["Message"] = "Error while processing request";
                TempData["MessageClass"] = "bg-danger";
                return Page();
            }
        }
    }
}
