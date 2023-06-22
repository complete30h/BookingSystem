using AutoMapper;
using Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager: IServiceManager
    {
        private readonly Lazy<IConcertService> _concertService;
        private readonly Lazy<IVoiceTypeService> _voiceTypeService;

        public ServiceManager(IRepositoryManager repositoryManager,ILoggerManager logger, IMapper mapper)
        {
            _concertService = new Lazy<IConcertService>(() => new ConcertService(repositoryManager, logger, mapper));
            _voiceTypeService = new Lazy<IVoiceTypeService>(() => new VoiceTypeService(repositoryManager, mapper));
        }

        public IConcertService ConcertService => _concertService.Value;
        public IVoiceTypeService VoiceTypeService => _voiceTypeService.Value;
    }
}
