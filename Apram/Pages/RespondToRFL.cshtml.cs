using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apram.Abstractions.Data;
using Apram.Domain.Messages;
using Apram.Domain.RFL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Apram.Pages
{
    public class RespondToRFLModel : PageModel
    {
        private readonly IRFLResponseRepository _responseRepo;
        private readonly IMessageRepository _messageRepo;

        public Guid RFLID { get; set; }

        [BindProperty]
        public RFLResponse ResponseToAdd { get; set; }
        [BindProperty]
        public Message MessageToAdd { get; set; }

        public RespondToRFLModel(IRFLResponseRepository responseRepo, IMessageRepository messageRepo)
        {
            _responseRepo = responseRepo;
            _messageRepo = messageRepo;
        }
        public void OnGet(Guid ID)
        {
            RFLID = ID;
        }

        public IActionResult OnPost()
        {
            try
            {
                _responseRepo.AddResponse(ResponseToAdd);
                MessageToAdd.Type = MessageType.RFL;
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
