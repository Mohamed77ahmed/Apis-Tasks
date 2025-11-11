using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersistenceLayer.Data;
using PersistenceLayer.Repositories;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer
{
    public static class InfraStructureServicesRegisteration
    {
        public static IServiceCollection AddInfraStructureServices(this IServiceCollection Services,IConfiguration _configuration)
        {

            //dbcontext
            Services.AddDbContext<StoreDbContext>(option =>
            {
                option.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            });
            //Data seeding
           Services.AddScoped<IDataSeeding, DataSeed>();
            //unit of work
          Services.AddScoped<IUnitOfWork, UnitOfWork>();

            Services.AddScoped<IBasketRepository, BasketRepository>();

            Services.AddSingleton<IConnectionMultiplexer>( (_) => 
            {
                return ConnectionMultiplexer.Connect(_configuration.GetConnectionString("RedisConnectionString"));
            });
            return Services;

            
           
        }
    }
}
