using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IVoiceTypeService
    {
        Task<IEnumerable<VoiceTypeDto>> GetAllVoiceTypesAsync(bool trackChanges);
        Task<VoiceTypeDto> GetVoiceTypeAsync(int voiceTypeId, bool trackChanges);
        Task<VoiceTypeDto> CreateVoiceType(VoiceTypeDto voiceTypeDto);
        Task DeleteVoiceType(int voiceTypeId, bool trackChanges);
    }
}
