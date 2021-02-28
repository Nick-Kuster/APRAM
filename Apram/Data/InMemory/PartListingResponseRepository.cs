using Apram.Abstractions.Data;
using Apram.Domain.PartListing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Data.InMemory
{
    public class PartListingResponseRepository : IPartListingResponseRepository
    {
        public List<PartListingResponse> Responses { get; set; }

        public PartListingResponseRepository()
        {
            Responses = new List<PartListingResponse>();
        }

        public void AddResponse(PartListingResponse response)
        {
            response.ID = Guid.NewGuid();
            Responses.Add(response);
        }

        public List<PartListingResponse> GetAllResponses()
        {
            return Responses;
        }

        public List<PartListingResponse> GetAllResponsesByRequestor(string userName)
        {
            return Responses.Where(x => x.RequestorEntity == userName).ToList();
        }

        public List<PartListingResponse> GetAllResponsesByResponder(string userName)
        {
            return Responses.Where(x => x.ResponderEntity == userName).ToList();
        }

        public List<PartListingResponse> GetAllResponsesByPartListingID(Guid rflID)
        {
            return Responses.Where(x => x.RequestID == rflID).ToList();
        }

        public PartListingResponse GetResponseByID(Guid id)
        {
            return Responses.FirstOrDefault(x => x.ID == id);
        }

        public int GetResponseCountForPartListing(Guid rflID)
        {
            return Responses.Count(x => x.RequestID == rflID);
        }
    }
}
