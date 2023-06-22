using AutoMapper;
using Entities.Models;
using Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookingSystem
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Concert, ConcertDto>()
                .ForMember(c => c.Place,
                    opt => opt.MapFrom(x => x.Place.Name));

            CreateMap<VoiceType, VoiceTypeDto>().ReverseMap();
        }
    }
}
