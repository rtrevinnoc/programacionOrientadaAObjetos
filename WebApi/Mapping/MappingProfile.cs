using System;
using AutoMapper;
using WebApi.Mapping.Resources.Livestock;
using WebApi.Mapping.Resources.Locations;
using WebApi.Mapping.Resources.Taxonomy;
using Core.Domain.Locations;
using Core.Domain.Taxonomy;
using Core.Domain.Livestock;
using Core.Domain.People;
using WebApi.Mapping.Resources.People;

namespace WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Domain to API Resource

            CreateMap<Animal, AnimalResource>()
                .ForMember(dest => dest.EmitSound, opt => opt.MapFrom(src => src.EmitSound()));
            CreateMap<Horse, HorseResource>();
            CreateMap<Goat, GoatResource>();
            CreateMap<SaveRanchResource, Ranch>();
            CreateMap<SaveCorralResource, Corral>();
            CreateMap<SaveSpecieResource, Specie>();
            CreateMap<SaveBreedResource, Breed>();
            CreateMap<SaveRancherResource, Rancher>();

            #endregion

            #region API Resource to Domain

            CreateMap<SaveHorseResource, Horse>();
            CreateMap<SaveGoatResource, Goat>();
            CreateMap<Ranch, RanchResource>();
            CreateMap<Corral, CorralResource>();
            CreateMap<Specie, SpecieResource>();
            CreateMap<Breed, BreedResource>();
            CreateMap<Rancher, RancherResource>();

            #region Management
            #endregion
            #endregion

            #region ExtraMapping
            #endregion
        }
    }
}
