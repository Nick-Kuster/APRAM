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
    public class ViewUserPartListingModel : PageModel
    {
        public List<PartListing> Parts { get; set; }

        private readonly IPartListingRepository _repo;

        public ViewUserPartListingModel(IPartListingRepository repo)
        {
            _repo = repo;
        }
        public void OnGet()
        {
            Parts = _repo.GetPartListings().Where(x => x.SellingEntity == User.Identity.Name).ToList();
        }
    }
}
