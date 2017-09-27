using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace refactor_me.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(o =>
            {
                o.AddProfile<DomainToViewModelMappingProfile>();
                o.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}