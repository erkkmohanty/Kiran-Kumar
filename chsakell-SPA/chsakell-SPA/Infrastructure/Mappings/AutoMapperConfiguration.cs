using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace chsakell_SPA.Infrastructure.Mappings
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(cfg =>
           {
               cfg.AddProfile(new DomainToViewModelMappingProfile());
           });
        }
    }
}