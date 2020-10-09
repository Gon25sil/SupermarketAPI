using AutoMapper;
using SupermarketAPI.Domain.Models;
using SupermarketAPI.DTO;
using SupermarketAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketAPI.Profiles
{
    public class SupermarketProfile : Profile
    {
        public SupermarketProfile()
        {
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();

            CreateMap<Product, ProductReadDto>().ForMember(d => d.UnitOfMeasurement, opt =>opt.MapFrom(src=>src.UnitOfMeasurement.ToDescription()));
            CreateMap<ProductCreateDTO, Product>().ForMember(d => d.UnitOfMeasurement, opt =>opt.MapFrom(src=>(EUnitOfMeasurement)src.UnitOfMeasurement));
            CreateMap<ProductUpdateDTO, Product>().ForMember(d => d.UnitOfMeasurement, opt => opt.MapFrom(src => (EUnitOfMeasurement)src.UnitOfMeasurement));

        }

    }
}
