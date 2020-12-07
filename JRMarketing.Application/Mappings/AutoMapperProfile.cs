using AutoMapper;
using JRMarketing.Domain.DTOs;
using JRMarketing.Domain.Entities;
using System;

namespace JRMarketing.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Restaurante
            CreateMap<Restaurante, RestauranteRequestDto>();
            CreateMap<Restaurante, RestauranteResponseDto>();
            CreateMap<RestauranteRequestDto, TelefonoRestaurante>()
                .ForMember(destination => destination.NumeroRestaurante, act => act.MapFrom(source => source.TelefonoRestaurante));
            CreateMap<RestauranteRequestDto, Restaurante>()
                .ForMember(destination => destination.TelefonoRestaurante, act => act.MapFrom(source => source))
                .AfterMap((source, destination) =>
                {
                    destination.CreatedAt = DateTime.Now;
                    destination.UpdatedAt = DateTime.Now;
                    destination.TelefonoRestaurante.CreatedAt = DateTime.Now;
                    destination.TelefonoRestaurante.UpdatedAt = DateTime.Now;
                });
            CreateMap<RestauranteResponseDto, Restaurante>();
            //Usuarios
            CreateMap<Usuario, UsuarioRequestDto>();
            CreateMap<Usuario, UsuarioResponseDto>();
            CreateMap<UsuarioRequestDto, TelefonoUsuario>()
                .ForMember(destination => destination.NumeroUsuario, act => act.MapFrom(source => source.TelefonoUsuario));
            CreateMap<UsuarioRequestDto, Usuario>()
                .ForMember(destination => destination.TelefonoUsuario, act => act.MapFrom(source => source))
                .AfterMap((source, destination) =>
                {
                    destination.CreatedAt = DateTime.Now;
                    destination.UpdatedAt = DateTime.Now;
                });      
            CreateMap<UsuarioResponseDto, Usuario>();
            //Etiqueta
            CreateMap<Etiquetum, EtiquetumRequestDto>();
            CreateMap<Etiquetum, EtiquetumResponseDto>();
            CreateMap<EtiquetumRequestDto, Etiquetum>().AfterMap(
                (source, destination) =>
                {
                    destination.CreatedAt = DateTime.Now;
                    destination.UpdatedAt = DateTime.Now;
                });
            CreateMap<EtiquetumResponseDto, Etiquetum>();

            //Publicación
            CreateMap<Publicacion, PublicacionRequestDto>();
            CreateMap<Publicacion, PublicacionResponseDto>();
            CreateMap<PublicacionRequestDto, Publicacion>().AfterMap(

                (soruce, destination) =>
                {
                    destination.CreatedAt = DateTime.Now;
                    destination.UpdatedAt = DateTime.Now;                    
                });
            CreateMap<PublicacionResponseDto, Publicacion>();
        }
    }
}
