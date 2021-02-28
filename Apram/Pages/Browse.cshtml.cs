using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apram.Abstractions.Data;
using Apram.Domain.PartListing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Apram.Pages
{
    public class BrowseModel : PageModel
    {

        private readonly IPartListingRepository _repo;

        public BrowseModel(IPartListingRepository repo) 
        {
            _repo = repo;
        }
        [BindProperty]
        public PartListingSearch Search { get; set; }
        public string SearchString { get; set; }
        public List<PartListing> Parts { get; set; }
        public bool Descending { get; set; }

        public void OnGet(string orderBy = "RequestingEntity", string search = "", bool desc = true)
        {
            Search = JsonConvert.DeserializeObject<PartListingSearch>(search);
            SearchString = search;
            Parts = _repo.GetPartListings();
            FilterBySearch();
            Sort(orderBy, desc);
        }

        public ActionResult OnPostSearch()
        {
            string json = JsonConvert.SerializeObject(Search);
            return new RedirectToPageResult("Browse", new { search = json });
        }

        private void FilterBySearch()
        {
            if (Search == null)
            {
                Search = new PartListingSearch();
            }

            if (!string.IsNullOrEmpty(Search.AircraftType))
            {
                Parts = Parts.Where(x => x.AircraftType.ToLower().Contains(Search.AircraftType.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(Search.Description))
            {
                Parts = Parts.Where(x => x.Description.ToLower().Contains(Search.Description.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(Search.SellingEntity))
            {
                Parts = Parts.Where(x => x.SellingEntity.ToLower().Contains(Search.SellingEntity.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(Search.SerialNumber))
            {
                Parts = Parts.Where(x => x.SerialNumber.ToLower().Contains(Search.SerialNumber.ToLower())).ToList();
            }
            Parts = Parts.ToList();
        }
        private void Sort(string orderBy, bool desc)
        {
            Descending = desc;
            switch (orderBy)
            {
                case "AircraftType":
                    if (Descending)
                    {
                        Parts = Parts.OrderByDescending(x => x.AircraftType).ToList();
                    }
                    else
                    {
                        Parts = Parts.OrderBy(x => x.AircraftType).ToList();
                    }
                    break;
                case "Description":
                    if (Descending)
                    {
                        Parts = Parts.OrderByDescending(x => x.Description).ToList();
                    }
                    else
                    {
                        Parts = Parts.OrderBy(x => x.Description).ToList();
                    }
                    break;
                case "SellingEntity":
                    if (Descending)
                    {
                        Parts = Parts.OrderByDescending(x => x.SellingEntity).ToList();
                    }
                    else
                    {
                        Parts = Parts.OrderBy(x => x.SellingEntity).ToList();
                    }
                    break;
                case "SerialNumber":
                    if (Descending)
                    {
                        Parts = Parts.OrderByDescending(x => x.SerialNumber).ToList();
                    }
                    else
                    {
                        Parts = Parts.OrderBy(x => x.SerialNumber).ToList();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
