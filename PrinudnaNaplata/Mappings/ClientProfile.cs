using AutoMapper;
using PrinudnaNaplata.Domain;
using PrinudnaNaplata.Models.Dtos.Client;

namespace PrinudnaNaplata.Mappings
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Klijent, ClientListResponseDto>().ReverseMap();
        }
    }
}
