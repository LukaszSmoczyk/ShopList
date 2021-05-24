using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopList.Data.Entities;
using ShopList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Data
{
    public class ShopListMappingProfile : Profile
    {
        public ShopListMappingProfile()
        {
            CreateMap<Item, ItemViewModel>()
                .ReverseMap();

            CreateMap<List, ListViewModel>()
                .ReverseMap();

            CreateMap<List, ItemListViewModel>()
                .ForMember(dest => dest.ListId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ListName, opt => opt.MapFrom(src => src.ListName))
                .ReverseMap();

            CreateMap<Item, ItemListViewModel>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemName))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ReverseMap();



        }
    }
}
