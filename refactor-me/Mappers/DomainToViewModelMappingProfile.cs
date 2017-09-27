using AutoMapper;
using refactor_me.Model;
using refactor_me.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductVM>();
            CreateMap<ProductOption, ProductOptionVM>();
        }
    }
}