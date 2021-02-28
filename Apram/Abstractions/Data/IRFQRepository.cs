using Apram.Domain.RFQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Abstractions.Data
{
    public interface IRFQRepository
    {
        List<RFQ> GetAllRFQs();
        void InsertRFQ(RFQ rfq);
    }
}
