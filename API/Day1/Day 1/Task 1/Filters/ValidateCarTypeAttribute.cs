using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Task_1.Models;

namespace Task_1.Filters
{
    public class ValidateCarTypeAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Car? car = context.ActionArguments["shop"] as Car;

            var regex = new Regex("^(EG|USA|UAE)$",
                RegexOptions.IgnoreCase,
                TimeSpan.FromSeconds(2));

            if (car is null || !regex.IsMatch(car.Type))
            {
                //Short Circuit with BadRequest
                context.ModelState.AddModelError("Location", "Location is not covered");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }

}
