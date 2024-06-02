using AutoMapper;
using Klinika.Application.Appoitments.AppoitmentsDTO;
using Klinika.Application.Cats.CatsDTO;
using Klinika.Application.Clients.ClientsDTO;
using Klinika.Domain.Models;

namespace Klinika.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Client, GetClientDTO>();
            CreateMap<Cat, GetClientCatDTO>();
            CreateMap<UpsertClientDTO, Client>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => Guid.NewGuid()));
        }
    }
}