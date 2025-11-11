using DomainLayer.Contracts;
using E_commerceApp.CustomMiddleWares;

namespace E_commerceApp.Extentions
{
    public static class WebApplicationRegisteration
    {
        public static async Task SeesDataBaseAsync(this WebApplication app) 
        {

            //add manual injection
            using var scope = app.Services.CreateScope();
            var seedObj = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await seedObj.DataSeedAsync();

        }
        public static IApplicationBuilder UseCustomExceptionMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionHandlerMiddleWare>();

            return app;
           
        }
    }
}
