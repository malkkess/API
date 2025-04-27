using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Shared.ErrorModels;

namespace E_Commerce.Web.Factories
{
    public class ApiResponseFactory
    {
        public static IActionResult GenerateApiValidationErrorResponse(ActionContext Context)
        {
            
                var Error = Context.ModelState.Where(M => M.Value.Errors.Any())
                .Select(M => new ValidationError()
                {
                    Field = M.Key,
                    Errors = M.Value.Errors.Select(E => E.ErrorMessage)
                });
                var Response = new ValidationErrorToReturn()
                {
                    ValidationErrors = Error
                };
                return new BadRequestObjectResult(Response);
            

        }
    }
}
