using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apram.Abstractions.Data;
using Apram.Domain.RFL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Apram.Pages
{
    public class BrowseRFLModel : PageModel
    {

        private readonly IRFLRepository _repo;      

        public BrowseRFLModel(IRFLRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public RFLSearch Search { get; set; }
        public string SearchString { get; set; }
        public List<RFL> RFLs { get; set; }
        public bool Descending { get; set; }

        public void OnGet(string orderBy = "RequestingEntity", string search = "", bool desc = true)
        {
            Search = JsonConvert.DeserializeObject<RFLSearch>(search);
            SearchString = search;
            RFLs = _repo.GetAllRFLs();
            FilterBySearch();
            Sort(orderBy, desc);
        }

        public ActionResult OnPostSearch()
        {
            string json = JsonConvert.SerializeObject(Search);
            return new RedirectToPageResult("BrowseRFL", new { search = json });
        }

        private void FilterBySearch()
        {
            if (Search == null)
            {
                Search = new RFLSearch();
            }

            if (!string.IsNullOrEmpty(Search.RequestingEntity))
            {
                RFLs = RFLs.Where(x => x.RequestingEntity.ToLower().Contains(Search.RequestingEntity.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(Search.PartDescription))
            {
                RFLs = RFLs.Where(x => x.PartDescription.ToLower().Contains(Search.PartDescription.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(Search.PartSerialNumber))
            {
                RFLs = RFLs.Where(x => x.PartNumber.ToLower().Contains(Search.PartSerialNumber.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(Search.AircraftType))
            {
                RFLs = RFLs.Where(x => x.AircraftType.ToLower().Contains(Search.AircraftType.ToLower())).ToList();
            }
            RFLs = RFLs.ToList();
        }
        private void Sort(string orderBy, bool desc)
        {
            Descending = desc;
            switch (orderBy)
            {
                case "RequestingEntity":
                    if (Descending)
                    {
                        RFLs = RFLs.OrderByDescending(x => x.RequestingEntity).ToList();
                    }
                    else
                    {
                        RFLs = RFLs.OrderBy(x => x.RequestingEntity).ToList();
                    }
                    break;
                case "PartDescription":
                    if (Descending)
                    {
                        RFLs = RFLs.OrderByDescending(x => x.PartDescription).ToList();
                    }
                    else
                    {
                        RFLs = RFLs.OrderBy(x => x.PartDescription).ToList();
                    }
                    break;
                case "PartSerialNumber":
                    if (Descending)
                    {
                        RFLs = RFLs.OrderByDescending(x => x.PartNumber).ToList();
                    }
                    else
                    {
                        RFLs = RFLs.OrderBy(x => x.PartNumber).ToList();
                    }
                    break;
                case "AircraftType":
                    if (Descending)
                    {
                        RFLs = RFLs.OrderByDescending(x => x.AircraftType).ToList();
                    }
                    else
                    {
                        RFLs = RFLs.OrderBy(x => x.AircraftType).ToList();
                    }
                    break;
                case "DateInserted":
                    if (Descending)
                    {
                        RFLs = RFLs.OrderByDescending(x => x.DateInserted).ToList();
                    }
                    else
                    {
                        RFLs = RFLs.OrderBy(x => x.DateInserted).ToList();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
