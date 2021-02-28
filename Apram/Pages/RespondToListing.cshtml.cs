using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apram.Abstractions.Data;
using Apram.Domain.Messages;
using Apram.Services.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Apram.Pages
{
    public class RespondToListing : PageModel
    {
        private readonly IMessageRepository _messageRepo;

        public Guid ParentID { get; set; }

        [BindProperty]
        public Message Message { get; set; }

        public RespondToListing(IMessageRepository messageRepo)
        {
            _messageRepo = messageRepo;
        }
        public void OnGet(Guid parentID, MessageType type)
        {
            Message = new Message();
            Message.ParentID = parentID;
            Message.Type = type;
        }

        public IActionResult OnPost()
        {
            try
            {
                _messageRepo.AddMessage(Message);
                TempData["Message"] = "Message Sent!";
                TempData["MessageClass"] = "bg-success";
                return new RedirectToPageResult(Message.Type.GetBrowsePageForType(), ViewData);
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
