using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IConcertRepository
    {
        Task<IEnumerable<Concert>> GetAllConcertsAsync(bool trackChanges);
        Task<Concert> GetConcertAsync(int concertId, bool trackChanges);
        void CreateConcert(Concert concert);
        void DeleteCompany(Concert concert);
    }
}
