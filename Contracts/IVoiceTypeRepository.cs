using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IVoiceTypeRepository
    {
        Task<IEnumerable<VoiceType>> GetAllVoiceTypesAsync(bool trackChanges);
        Task<VoiceType> GetVoiceTypeAsync(int voiceTypeId, bool trackChanges);
        void CreateVoiceType(VoiceType voiceType);
        void DeleteVoiceType(VoiceType voiceType);
    }
}
