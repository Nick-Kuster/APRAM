using Apram.Abstractions.Data;
using Apram.Domain.RFL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Apram.Data.InMemory
{
    public class RFLResponseRepository : IRFLResponseRepository
    {
        public List<RFLResponse> Responses { get; set; }

        public RFLResponseRepository()
        {
            Responses = new List<RFLResponse>();
        }

        public void AddResponse(RFLResponse response)
        {
            response.ID = Guid.NewGuid();
            Responses.Add(response);
        }

        public List<RFLResponse> GetAllResponses()
        {
            return Responses;
        }

        public List<RFLResponse> GetAllResponsesByRequestor(string userName)
        {
            return Responses.Where(x => x.RequestorEntity == userName).ToList();
        }

        public List<RFLResponse> GetAllResponsesByResponder(string userName)
        {
            return Responses.Where(x => x.ResponderEntity == userName).ToList();
        }

        public List<RFLResponse> GetAllResponsesByRFLID(Guid rflID)
        {
            return Responses.Where(x => x.RequestID == rflID).ToList();
        }

        public RFLResponse GetResponseByID(Guid id)
        {
            return Responses.FirstOrDefault(x => x.ID == id);
        }

        public int GetResponseCountForRFL(Guid rflID)
        {
            return Responses.Count(x => x.RequestID == rflID);
        }
    }
}
