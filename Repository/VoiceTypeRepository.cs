using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VoiceTypeRepository: RepositoryBase<VoiceType>, IVoiceTypeRepository
    {
        public VoiceTypeRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
                
        }

        public void CreateVoiceType(VoiceType voiceType)
        {
            Create(voiceType);
        }

        public void DeleteVoiceType(VoiceType voiceType)
        {
            Delete(voiceType);
        }

        public async Task<IEnumerable<VoiceType>> GetAllVoiceTypesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<VoiceType> GetVoiceTypeAsync(int voiceTypeId, bool trackChanges)
        {
            return await FindByCondition(voice => voice.Id.Equals(voiceTypeId), trackChanges).SingleOrDefaultAsync();
        }
    }
}
