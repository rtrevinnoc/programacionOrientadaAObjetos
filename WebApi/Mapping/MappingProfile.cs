using System;
using AutoMapper;
using WebApi.Mapping.Resources.Livestock;
using Core.Domain.Livestock;

namespace WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Domain to API Resource

            CreateMap<Animal, AnimalResource>()
                .ForMember(dest => dest.Sound, opt => opt.MapFrom(src => src.EmitSound()));
            CreateMap<Horse, HorseResource>(); 
            CreateMap<Goat, GoatResource>();

            #endregion

            #region API Resource to Domain

            CreateMap<SaveHorseResource, Horse>();
            CreateMap<SaveGoatResource, Goat>();

            #region Management
            #endregion
            #endregion

            #region ExtraMapping
            #endregion
        }
    }
}
