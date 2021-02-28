using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apram.Abstractions.Data;
using Apram.Domain.PartListing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Apram.Pages
{
    public class ViewPartListingResponsesModel : PageModel
    {
        private readonly IPartListingResponseRepository _partListingResponseRepo;
        private readonly IMessageRepository _messageRepo;

        public ViewPartListingResponsesModel(IPartListingResponseRepository partListingResponseRepo, IMessageRepository messageRepo)
        {
            _partListingResponseRepo = partListingResponseRepo;
            _messageRepo = messageRepo;
        }

        public List<PartListingResponse> ResponseList { get; private set; }

        public void OnGet(Guid ID)
        {
            ResponseList = _partListingResponseRepo.GetAllResponsesByPartListingID(ID);

            foreach (var response in ResponseList)
            {
                response.MessageCount = _messageRepo.GetMessageCountByParentID(response.ID);
            }
        }
    }
}
