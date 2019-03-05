using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebStore.Infrastucture.Filters
{
    public class TestActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
