﻿using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;
using System.Runtime;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();
            CreateMap<Room, RoomUpdateDto>().ReverseMap();
        }
    }
}