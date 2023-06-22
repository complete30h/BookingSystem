using AutoMapper;
using Contracts;
using Services.Contracts;
using Shared;

namespace Services
{
    internal sealed class ConcertService : IConcertService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ConcertService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConcertDto>> GetAllConcertsAsync(bool trackChanges)
        {
            var concerts = await _repositoryManager.Concert.GetAllConcertsAsync(trackChanges);
            var concertsDto = _mapper.Map<IEnumerable<ConcertDto>>(concerts);
            return concertsDto;
        }
    }
}