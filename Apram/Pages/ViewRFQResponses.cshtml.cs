using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apram.Abstractions.Data;
using Apram.Domain.RFQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Apram.Pages
{
    public class ViewRFQResponsesModel : PageModel
    {
        private readonly IRFQResponseRepository _rfqResponseRepo;
        private readonly IMessageRepository _messageRepo;

        public ViewRFQResponsesModel(IRFQResponseRepository rfqResponseRepo, IMessageRepository messageRepo)
        {
            _rfqResponseRepo = rfqResponseRepo;
            _messageRepo = messageRepo;
        }

        public List<RFQResponse> ResponseList { get; private set; }

        public void OnGet(Guid ID)
        {
            ResponseList = _rfqResponseRepo.GetAllResponsesByRFQID(ID);

            foreach(var response in ResponseList)
            {
                response.MessageCount = _messageRepo.GetMessageCountByParentID(response.ID);
            }

            
        }
    }
}
