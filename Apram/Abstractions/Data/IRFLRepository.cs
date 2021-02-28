using Apram.Domain.RFL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apram.Abstractions.Data
{
    public interface IRFLRepository
    {
        List<RFL> GetAllRFLs();
        RFL GetRFLByID(Guid id);
        void InsertRFL(RFL rfl);
    }
}
