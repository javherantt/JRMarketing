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
            //Usuarios
            CreateMap<Usuario, UsuarioRequestDto>();
            CreateMap<Usuario, UsuarioResponseDto>();
            CreateMap<UsuarioRequestDto, Usuario>().AfterMap(
                (source, destination) =>
                {
                    destination.CreatedAt = DateTime.Now;
                    destination.UpdatedAt = DateTime.Now;
                });
            CreateMap<UsuarioResponseDto, Usuario>();
            //Etiqueta
            CreateMap<Etiquetum, EtiquetumRequestDto>();
            CreateMap<Etiquetum, EtiquetumResponseDto>();
            CreateMap<EtiquetumRequestDto, Etiquetum>();
            CreateMap<EtiquetumResponseDto, Etiquetum>();
            //Otro
            CreateMap<Restaurante, RestauranteRequestDto>();
            CreateMap<Restaurante, RestauranteResponseDto>();
            CreateMap<RestauranteRequestDto, Restaurante>().AfterMap(
                (source, destination) =>
                {
                    destination.CreatedAt = DateTime.Now;
                    destination.UpdatedAt = DateTime.Now;
                });
            CreateMap<RestauranteResponseDto, Restaurante>();
        }
    }
}
