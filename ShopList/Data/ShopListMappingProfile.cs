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
                .ReverseMap();

            CreateMap<Item, ItemListViewModel>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemName))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.List.Items))
                .ForMember(dest => dest.DateOfAddingItem, opt => opt.MapFrom(src => src.DateOfAddingItem))
                .ForMember(dest => dest.ListId, opt => opt.MapFrom(src => src.List.Id))
                .ForMember(dest => dest.ListName, opt => opt.MapFrom(src => src.List.ListName))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ReverseMap();

            // .ForMember(i => i.ItemId, x => x.MapFrom(source => source.ItemId))

        }
    }
}
