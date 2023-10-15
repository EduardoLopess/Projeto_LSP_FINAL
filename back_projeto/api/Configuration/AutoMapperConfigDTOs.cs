using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace api.Configuration
{
    public class AutoMapperConfigDTOs : Profile
    {
        public AutoMapperConfigDTOs()
        {
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.NomeCompleto, map => map.MapFrom(src => $"{src.Nome} {src.SobreNome}"))
                .ForMember(dest => dest.EnderecosDTO, map => map.MapFrom(src => src.Enderecos));
                          
            CreateMap<Endereco, EnderecoDTO>()
            
                .ForMember(dest => dest.UsuarioDTO, opt => opt.MapFrom(src => new UsuarioDTO
                    {
                        Id = src.Usuario.Id,
                        NomeCompleto = $"{src.Usuario.Nome} {src.Usuario.SobreNome}",
                        Telefone = src.Usuario.Telefone,
                        CPF = src.Usuario.CPF,
                        Email = src.Usuario.Email,
                    }));
                      
                //.ForMember(dest => dest.UsuarioDTO, map => map.MapFrom(src => src.Usuario))// Mapeie o usuário relacionado
                
        
        }
    }
} 