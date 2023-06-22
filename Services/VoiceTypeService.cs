using AutoMapper;
using Contracts;
using Entities.Models;
using Services.Contracts;
using Entities.Exceptions;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal sealed class VoiceTypeService : IVoiceTypeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public VoiceTypeService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<VoiceTypeDto> CreateVoiceType(VoiceTypeDto voiceTypeDto)
        {
            var voiceTypeEntity = _mapper.Map<VoiceType>(voiceTypeDto);

            _repository.VoiceType.CreateVoiceType(voiceTypeEntity);
            await _repository.SaveAsync();

            var voiceTypeToReturn = _mapper.Map<VoiceTypeDto>(voiceTypeEntity);
            return voiceTypeToReturn;
        }

        public async Task DeleteVoiceType(int voiceTypeId, bool trackChanges)
        {
            var voiceType = await GetVoiceTypeAndCheckIfItExists(voiceTypeId, trackChanges);

            _repository.VoiceType.DeleteVoiceType(voiceType);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<VoiceTypeDto>> GetAllVoiceTypesAsync(bool trackChanges)
        {
            var voiceTypes = await _repository.VoiceType.GetAllVoiceTypesAsync(trackChanges);
            var voiceTypesDto = _mapper.Map<IEnumerable<VoiceTypeDto>>(voiceTypes);

            return voiceTypesDto;
        }

        public async Task<VoiceTypeDto> GetVoiceTypeAsync(int voiceTypeId, bool trackChanges)
        {
            var voiceType = await GetVoiceTypeAndCheckIfItExists(voiceTypeId, trackChanges);
            var voiceTypeDto = _mapper.Map<VoiceTypeDto>(voiceType);

            return voiceTypeDto;
        }

        private async Task<VoiceType> GetVoiceTypeAndCheckIfItExists(int voiceTypeId, bool trackChanges)
        {
            var voiceType = await _repository.VoiceType.GetVoiceTypeAsync(voiceTypeId, trackChanges);

            if (voiceType == null)
            {
                throw new VoiceTypeNotFoundException(voiceTypeId);
            }

            return voiceType;
        }

    }
}
