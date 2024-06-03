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
            CreateMap<Cat, GetClientCatDTO>();
            CreateMap<Client, GetClientDTO>();
            CreateMap<CreateClientDTO, Client>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<Client, GetCatClientDTO>();
            CreateMap<Cat, GetCatDTO>();
            CreateMap<UpsertCatDTO, Cat>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<Client, GetAppoitmentClientDTO>();
            CreateMap<Cat, GetAppoitmentCatDTO>();
            CreateMap<Appoitment, GetAppoitmentDTO>();
            CreateMap<Client, GetCatClientDTO>();
            CreateMap<UpsertAppoitmentDTO, Appoitment>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => Guid.NewGuid()));
        }
    }
}