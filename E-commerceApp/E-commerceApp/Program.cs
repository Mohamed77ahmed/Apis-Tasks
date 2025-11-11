
using DomainLayer.Contracts;
using E_commerceApp.CustomMiddleWares;
using E_commerceApp.Extentions;
using E_commerceApp.Factories;
using Microsoft.AspNetCore.Mvc;
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

            //register swagger 
            builder.Services.AddSwaggerService();

            //register infra structure services
            builder.Services.AddInfraStructureServices(builder.Configuration);
            

            //register services
            builder.Services.AddApplicationServices();

            //register validitionError
            builder.Services.AddWebApplicationService();          
            #endregion

          




            var app = builder.Build();


            //dataseed
          await  app.SeesDataBaseAsync();

          //use exception middleware
          app.UseCustomExceptionMiddleWare();

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
