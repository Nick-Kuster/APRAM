using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apram.Abstractions.Data;
using Apram.Domain.RFL;
using Apram.Domain.RFQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Apram.Pages
{
    public class UserRequestsModel : PageModel
    {
        private readonly IRFLRepository _rflRepo;
        private readonly IRFQRepository _rfqRepo;
        public IRFQResponseRepository _rfqResponseRepo;
        private readonly IRFLResponseRepository _rflResponseRepo;

        public List<RFL> RFLs { get; set; }
        public List<RFQ> RFQs { get; set; }

        public UserRequestsModel(IRFLRepository rflRepo, IRFQRepository rfqRepo, IRFQResponseRepository rfqResponseRepo, IRFLResponseRepository rflResponseRepo)
        {
            _rflRepo = rflRepo;
            _rfqRepo = rfqRepo;
            _rfqResponseRepo = rfqResponseRepo;
            _rflResponseRepo = rflResponseRepo;
        }
        public void OnGet()
        {
            RFLs = _rflRepo.GetAllRFLs().Where(x => x.RequestingEntity == User.Identity.Name).ToList();
            RFQs = _rfqRepo.GetAllRFQs().Where(x => x.RequestingEntity == User.Identity.Name).ToList();

            foreach(var rfq in RFQs)
            {
                rfq.ResponseCount = _rfqResponseRepo.GetResponseCountForRFQ(rfq.ID);
            }

            foreach(var rfl in RFLs)
            {
                rfl.ResponseCount = _rflResponseRepo.GetResponseCountForRFL(rfl.ID);
            }
        }
    }
}
