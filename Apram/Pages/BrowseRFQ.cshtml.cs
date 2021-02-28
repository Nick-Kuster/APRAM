using System.Collections.Generic;
using System.Linq;
using Apram.Abstractions.Data;
using Apram.Domain.RFQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Apram.Pages
{
    public class RFQModel : PageModel
    {

        private readonly IRFQRepository _repo;

        public RFQModel(IRFQRepository repo)
        {
            _repo = repo;
        }
        [BindProperty]
        public RFQSearch Search { get; set; }
        public string SearchString { get; set; }
        public List<RFQ> RFQs { get; set; }
        public bool Descending { get; set; }

        public void OnGet(string orderBy = "RequestingEntity", string search = "", bool desc = true)
        {
            Search = JsonConvert.DeserializeObject<RFQSearch>(search);
            SearchString = search;
            RFQs = _repo.GetAllRFQs();
            FilterBySearch();
            Sort(orderBy, desc);
        }

        public ActionResult OnPostSearch()
        {
            string json = JsonConvert.SerializeObject(Search);
            return new RedirectToPageResult("BrowseRFQ", new { search = json });
        }

        private void FilterBySearch()
        {
            if(Search == null)
            {
                Search = new RFQSearch();
            }

            if (!string.IsNullOrEmpty(Search.RequestingEntity))
            {
                RFQs = RFQs.Where(x => x.RequestingEntity.ToLower().Contains(Search.RequestingEntity.ToLower())).ToList();
            } 
            if (!string.IsNullOrEmpty(Search.PartDescription))
            {
                RFQs = RFQs.Where(x => x.PartDescription.ToLower().Contains(Search.PartDescription.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(Search.PartSerialNumber))
            {
                RFQs = RFQs.Where(x => x.PartNumber.ToLower().Contains(Search.PartSerialNumber.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(Search.AircraftType))
            {
                RFQs = RFQs.Where(x => x.AircraftType.ToLower().Contains(Search.AircraftType.ToLower())).ToList();
            }
            RFQs = RFQs.ToList();
        }
        private void Sort(string orderBy, bool desc)
        {
            Descending = desc;
            switch (orderBy)
            {
                case "RequestingEntity":
                    if (Descending)
                    {
                        RFQs = RFQs.OrderByDescending(x => x.RequestingEntity).ToList();
                    }
                    else
                    {
                        RFQs = RFQs.OrderBy(x => x.RequestingEntity).ToList();
                    }
                    break;
                case "PartDescription":
                    if (Descending)
                    {
                        RFQs = RFQs.OrderByDescending(x => x.PartDescription).ToList();
                    }
                    else
                    {
                        RFQs = RFQs.OrderBy(x => x.PartDescription).ToList();
                    }
                    break;
                case "RFQserialNumber":
                    if (Descending)
                    {
                        RFQs = RFQs.OrderByDescending(x => x.PartNumber).ToList();
                    }
                    else
                    {
                        RFQs = RFQs.OrderBy(x => x.PartNumber).ToList();
                    }
                    break;
                case "AircraftType":
                    if (Descending)
                    {
                        RFQs = RFQs.OrderByDescending(x => x.AircraftType).ToList();
                    }
                    else
                    {
                        RFQs = RFQs.OrderBy(x => x.AircraftType).ToList();
                    }
                    break;
                case "DateInserted":
                    if (Descending)
                    {
                        RFQs = RFQs.OrderByDescending(x => x.DateInserted).ToList();
                    }
                    else
                    {
                        RFQs = RFQs.OrderBy(x => x.DateInserted).ToList();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
