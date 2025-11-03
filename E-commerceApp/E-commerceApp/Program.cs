
using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer;
using PersistenceLayer.Data;
using PersistenceLayer.Repositories;
using ServiceAbstraction;
using ServiceLayer;
using System.Data;

namespace E_commerceApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //dbcontext
            builder.Services.AddDbContext<StoreDbContext>(option => 
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            //Data seeding
            builder.Services.AddScoped<IDataSeeding, DataSeed>();
            //unit of work
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            //mapping
            builder.Services.AddAutoMapper(x => { },typeof(ServiceLayerAssemblyReferance).Assembly);
            //service manager
            builder.Services.AddScoped<IServiceManager,ServiceManager>();
            #endregion

            var app = builder.Build();


            //add manual injection
            using var scope=app.Services.CreateScope();
            var seedObj=scope.ServiceProvider.GetRequiredService<IDataSeeding>();
             await seedObj.DataSeedAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
