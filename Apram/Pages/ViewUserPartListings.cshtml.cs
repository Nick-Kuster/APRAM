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
    public class ViewUserPartListingsModel : PageModel
    {
        public List<PartListing> Parts { get; set; }

        private readonly IPartListingRepository _repo;
        private readonly IPartListingResponseRepository _responseRepo;

        public ViewUserPartListingsModel(IPartListingRepository repo, IPartListingResponseRepository responseRepo)
        {
            _repo = repo;
            _responseRepo = responseRepo;
        }
        public void OnGet()
        {
            Parts = _repo.GetPartListings().Where(x => x.SellingEntity == User.Identity.Name).ToList();

            foreach(var part in Parts)
            {
                part.ResponseCount = _responseRepo.GetResponseCountForPartListing(part.ID);
            }
        }
    }
}
