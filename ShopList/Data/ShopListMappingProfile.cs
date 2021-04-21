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
            CreateMap<Product, ProductViewModel>()
                .ForMember(p => p.Id, ex => ex.MapFrom(p => p.Id))
                .ReverseMap();

        }
    }
}
