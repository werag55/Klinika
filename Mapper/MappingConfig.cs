using AutoMapper;
using Klinika.DTO;
using Klinika.Models;

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