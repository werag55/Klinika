using AutoMapper;
using Klinika.DTO;
using Klinika.Domain.Models;

namespace Klinika.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Appoitment, AppoitmentDTO>();

            CreateMap<Client, ClientDTO>();

            CreateMap<Cat, CatDTO>();   
        }
    }
}