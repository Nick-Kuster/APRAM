using Apram.Abstractions.Data;
using Apram.Domain.RFQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Data.InMemory
{
    public class RFQResponseRepository : IRFQResponseRepository
    {
        public List<RFQResponse> Responses { get; set; }

        public RFQResponseRepository()
        {
            Responses = new List<RFQResponse>();
        }
        public void AddResponse(RFQResponse response)
        {
            response.ID = Guid.NewGuid();
            Responses.Add(response);
        }

        public List<RFQResponse> GetAllResponses()
        {
            return Responses;
        }

        public RFQResponse GetResponseByID(Guid id)
        {
            return Responses.FirstOrDefault(x => x.ID == id);
        }

        public List<RFQResponse> GetAllResponsesByResponder(string userName)
        {
            return Responses.Where(x => x.ResponderEntity == userName).ToList();
        }

        public List<RFQResponse> GetAllResponsesByRequestor(string userName)
        {
            return Responses.Where(x => x.RequestorEntity == userName).ToList();
        }

        public List<RFQResponse> GetAllResponsesByRFQID(Guid rfqID)
        {
            return Responses.Where(x => x.RequestID == rfqID).ToList();
        }

        public int GetResponseCountForRFQ(Guid rfqID)
        {
            return Responses.Count(x => x.RequestID == rfqID);
        }
    }
}
