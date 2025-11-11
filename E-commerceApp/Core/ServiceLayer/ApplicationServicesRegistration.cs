using Microsoft.Extensions.DependencyInjection;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services) 
        {
            //mapping auto mapper
            Services.AddAutoMapper(x => { }, typeof(ServiceLayerAssemblyReferance).Assembly);
            //service manager
            Services.AddScoped<IServiceManager, ServiceManager>();


            return Services;
        
        }
    }
}
