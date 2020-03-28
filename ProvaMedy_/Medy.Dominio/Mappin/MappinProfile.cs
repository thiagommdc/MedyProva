using AutoMapper;

namespace Medy.Dominio
{
    public class MappinProfile : Profile
    {
        public MappinProfile()
        {
            CreateMap<Contato, ContatoDTO>().ReverseMap();
        }
    }
}