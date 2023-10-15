using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;

namespace api.Configuration
{
    public class AutoMapperConfigViewModels : Profile
    {
        public AutoMapperConfigViewModels()
        {
            CreateMap<UsuarioViewModel, Usuario>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.SobreNome, opt => opt.MapFrom(src => src.SobreNome))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone))
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.EnderecoViews)); // Mapeamento da lista de endereços

            
            CreateMap<EnderecoViewModel, Endereco>();
                
            
        }
    }
}