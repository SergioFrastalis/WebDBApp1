using AutoMapper;
using WebDBApp1.DTO;
using WebDBApp1.Models;

namespace WebDBApp1.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ClientInsertDTO, Client>().ReverseMap();
            CreateMap<ClientUpdateDTO, Client>().ReverseMap();
            CreateMap<ClientReadOnlyDTO, Client>().ReverseMap();
        }
    }
}
