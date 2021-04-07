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
            CreateMap<RestauranteRequestDto2, Restaurante>();
            CreateMap<RestauranteRequestDto, Restaurante>()       
                .AfterMap((source, destination) =>
                {
                    destination.CreatedAt = DateTime.Now;
                    destination.UpdatedAt = DateTime.Now;         
                });         
            CreateMap<RestauranteResponseDto, Restaurante>();
            //Usuarios
            CreateMap<Usuario, UsuarioResponseDto>();
            CreateMap<Usuario, UsuarioRequestDto>(); 
            CreateMap<UsuarioRequestDto2, Usuario>();          
            CreateMap<UsuarioRequestDto, Usuario>()               
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

            //RestauranteEiquetumDto
            CreateMap<RestauranteEtiquetumDto, RestauranteEtiquetum>();
            CreateMap<RestauranteEtiquetum, RestauranteEtiquetumDto>();  
        }
    }
}
