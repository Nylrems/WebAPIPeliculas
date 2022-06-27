﻿using AutoMapper;
using WebAPIPeliculas.DTOs;
using WebAPIPeliculas.Entidades;

namespace WebAPIPeliculas.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genero, GeneroDTO>().ReverseMap();
            CreateMap<GeneroCreacionDTO, Genero>();

            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<ActorCreacionDTO, Actor>();

            
        }
    }
}
