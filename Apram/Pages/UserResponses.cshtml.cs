using Apram.Abstractions.Data;
using Apram.Domain.PartListing;
using Apram.Domain.RFL;
using Apram.Domain.RFQ;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace Apram.Pages
{
    public class UserResponsesModel : PageModel
    {
        private readonly IMessageRepository _messageRepo;
        private readonly IRFLRepository _rflRepo;
        private readonly IRFQRepository _rfqRepo;
        private readonly IPartListingRepository _partListingRepo;
        public IRFQResponseRepository _rfqResponseRepo;
        private readonly IRFLResponseRepository _rflResponseRepo;
        private readonly IPartListingResponseRepository _partListingResponseRepo;

        public List<RFLResponse> RFLResponses { get; set; }
        public List<RFQResponse> RFQResponses { get; set; }
        public List<PartListingResponse> PartListingResponses { get; set; }

        public UserResponsesModel(IMessageRepository messageRepo, IRFLRepository rflRepo, IRFQRepository rfqRepo, IPartListingRepository partListingRepository, IRFQResponseRepository rfqResponseRepo, IRFLResponseRepository rflResponseRepo, IPartListingResponseRepository partListingResponseRepo)
        {
            _messageRepo = messageRepo;
            _rflRepo = rflRepo;
            _rfqRepo = rfqRepo;
            _partListingRepo = partListingRepository;
            _rfqResponseRepo = rfqResponseRepo;
            _rflResponseRepo = rflResponseRepo;
            _partListingResponseRepo = partListingResponseRepo;
        }
        public void OnGet()
        {
            RFLResponses = _rflResponseRepo.GetAllResponsesByResponder(User.Identity.Name);
            RFQResponses = _rfqResponseRepo.GetAllResponsesByResponder(User.Identity.Name);
            PartListingResponses = _partListingResponseRepo.GetAllResponsesByResponder(User.Identity.Name);

            foreach(var rflResponse in RFLResponses)
            {
                rflResponse.MessageCount = _messageRepo.GetMessageCountByParentID(rflResponse.ID);
                rflResponse.ParentRFL = _rflRepo.GetRFLByID(rflResponse.RequestID);
            }
            foreach(var rfqResponse in RFQResponses)
            {
                rfqResponse.MessageCount = _messageRepo.GetMessageCountByParentID(rfqResponse.ID);
                rfqResponse.ParentRFQ = _rfqRepo.GetRFQByID(rfqResponse.RequestID);
            }
            foreach(var partResponse in PartListingResponses)
            {
                partResponse.MessageCount = _messageRepo.GetMessageCountByParentID(partResponse.ID);
                partResponse.ParentListing = _partListingRepo.GetPartListingByIDNumber(partResponse.PartListingID);
            }
        }
    }
}
