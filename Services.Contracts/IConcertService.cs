using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IConcertService
    {
        Task<IEnumerable<ConcertDto>> GetAllConcertsAsync(bool trackChanges);

    }
}
