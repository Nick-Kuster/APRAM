using Apram.Domain.RFL;
using System;
using System.Collections.Generic;

namespace Apram.Abstractions.Data
{
    public interface IRFLResponseRepository
    {
        List<RFLResponse> GetAllResponses();
        void AddResponse(RFLResponse response);
        RFLResponse GetResponseByID(Guid id);
        List<RFLResponse> GetAllResponsesByResponder(string userName);
        List<RFLResponse> GetAllResponsesByRequestor(string userName);
        List<RFLResponse> GetAllResponsesByRFLID(Guid rflID);
        int GetResponseCountForRFL(Guid rflID);
    }
}
