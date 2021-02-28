using System;
using Apram.Abstractions.Data;
using Apram.Domain.Messages;
using Apram.Domain.RFQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Apram.Pages
{
    public class RespondToRFQModel : PageModel
    {
        private readonly IRFQResponseRepository _responseRepo;
        private readonly IMessageRepository _messageRepo;

        public Guid RFQID { get; set; }
        [BindProperty]
        public RFQResponse ResponseToAdd { get; set; }

        [BindProperty]
        public Message MessageToAdd { get; set; }

        public RespondToRFQModel(IRFQResponseRepository responseRepo, IMessageRepository messageRepo)
        {
            _responseRepo = responseRepo;
            _messageRepo = messageRepo;
        }
        public void OnGet(Guid ID)
        {
            RFQID = ID;
        }

        public IActionResult OnPost()
        {
            try
            {
                _responseRepo.AddResponse(ResponseToAdd);
                MessageToAdd.Type = MessageType.RFQ;
                MessageToAdd.ParentID = ResponseToAdd.ID;
                _messageRepo.AddMessage(MessageToAdd);
                TempData["Message"] = "You have responded to the RFQ";
                TempData["MessageClass"] = "bg-success";
                return new RedirectToPageResult("BrowseRFQ", ViewData);
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
