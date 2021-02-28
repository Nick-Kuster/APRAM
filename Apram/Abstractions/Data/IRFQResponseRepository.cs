using Apram.Domain.RFQ;
using System;
using System.Collections.Generic;

namespace Apram.Abstractions.Data
{
    public interface IRFQResponseRepository
    {
        List<RFQResponse> GetAllResponses();
        void AddResponse(RFQResponse response);
        RFQResponse GetResponseByID(Guid id);
        List<RFQResponse> GetAllResponsesByResponder(string userName);
        List<RFQResponse> GetAllResponsesByRequestor(string userName);
        List<RFQResponse> GetAllResponsesByRFQID(Guid rfqID);
        int GetResponseCountForRFQ(Guid rfqID);
    }
}
