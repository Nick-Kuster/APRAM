using Apram.Domain.PartListing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Abstractions.Data
{
    public interface IPartListingResponseRepository
    {
        List<PartListingResponse> GetAllResponses();
        void AddResponse(PartListingResponse response);
        PartListingResponse GetResponseByID(Guid id);
        List<PartListingResponse> GetAllResponsesByResponder(string userName);
        List<PartListingResponse> GetAllResponsesByRequestor(string userName);
        List<PartListingResponse> GetAllResponsesByPartListingID(Guid partListingID);
        int GetResponseCountForPartListing(Guid partListingID);
    }
}
