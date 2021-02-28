using System;
using System.Collections.Generic;
using Apram.Abstractions.Data;
using Apram.Domain.RFL;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Apram.Pages
{
    public class ViewRFLResponsesModel : PageModel
    {
        private readonly IRFLResponseRepository _rflResponseRepo;
        private readonly IMessageRepository _messageRepo;

        public ViewRFLResponsesModel(IRFLResponseRepository rflResponseRepo, IMessageRepository messageRepo)
        {
            _rflResponseRepo = rflResponseRepo;
            _messageRepo = messageRepo;
        }

        public List<RFLResponse> ResponseList { get; private set; }

        public void OnGet(Guid ID)
        {
            ResponseList = _rflResponseRepo.GetAllResponsesByRFLID(ID);

            foreach (var response in ResponseList)
            {
                response.MessageCount = _messageRepo.GetMessageCountByParentID(response.ID);
            }
        }
    }
}
