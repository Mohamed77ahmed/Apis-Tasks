using E_commerceApp.Factories;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceApp.Extentions
{
    public static class ServicesRegisteration
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection Services) 
        {
            
           Services.AddEndpointsApiExplorer();
           Services.AddSwaggerGen();

            return Services;
        }

        public static IServiceCollection AddWebApplicationService(this IServiceCollection Services)

        {
            //validitionError
          Services.Configure<ApiBehaviorOptions>(option => {
                option.InvalidModelStateResponseFactory = ApiResponseFactory.GenerateApiValiditionErrorResponsr;
            });

            return Services;
        }
    }
}
