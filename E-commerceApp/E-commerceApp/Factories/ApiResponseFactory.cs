using Microsoft.AspNetCore.Mvc;
using Shared.ErrorModels;

namespace E_commerceApp.Factories
{
    public static class ApiResponseFactory
    {

        public static IActionResult GenerateApiValiditionErrorResponsr(ActionContext context) 
        {
            var errors = context.ModelState.Where(e => e.Value.Errors.Any())
                                         .Select(m => new ValiditionError()
                                         {
                                             Field=m.Key,
                                             Errors=m.Value.Errors.Select(e => e.ErrorMessage)
                                             

                                         });
            var response = new ValiditonErrorToReturn() 
            { validitionErrors=errors};

            return new BadRequestObjectResult(response);
        
        }
    }
}
