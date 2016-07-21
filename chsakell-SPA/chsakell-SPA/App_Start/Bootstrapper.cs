using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using chsakell_SPA.Infrastructure.Mappings;

namespace chsakell_SPA.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            // Configure Autofac
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration, AutoMapperConfiguration.Configure());
            //Configure AutoMapper
           
        }
    }
}