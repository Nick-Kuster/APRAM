using Apram.Abstractions.Data;
using Apram.Domain.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Apram.Pages
{
    public class ConversationModel : PageModel
    {
        private readonly IMessageRepository _messageRepo;

        public ConversationModel(IMessageRepository messageRepo)
        {
            _messageRepo = messageRepo;
        }

        [BindProperty]
        public Message MessageToAdd { get; set; }

        public Guid ParentID { get; set; }
        public MessageType MessagesType { get; set; }
        public List<Message> Messages { get; private set; }
        public bool ShowRespondDiv { get; set; }
        public void OnGet(Guid id, bool showRespondDiv = false)
        {
            Messages = _messageRepo.GetMessagesByParentID(id);
            Messages.OrderBy(x => x.SendDate);
            MessagesType = Messages.Select(x => x.Type).FirstOrDefault();
            ParentID = id;
            ShowRespondDiv = showRespondDiv;
        }

        public IActionResult OnPost()
        {
            _messageRepo.AddMessage(MessageToAdd);
            return RedirectToPage("Conversation", new { id = MessageToAdd.ParentID });
        }
    }
}
