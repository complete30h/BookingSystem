using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager: IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IConcertRepository> _concertRepository;
        private readonly Lazy<IVoiceTypeRepository> _voiceTypeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _concertRepository = new Lazy<IConcertRepository>(() => new ConcertRepository(repositoryContext));
            _voiceTypeRepository = new Lazy<IVoiceTypeRepository>(() => new VoiceTypeRepository(repositoryContext));
        }

        public IConcertRepository Concert => _concertRepository.Value;
        public IVoiceTypeRepository VoiceType => _voiceTypeRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }


    }
}
