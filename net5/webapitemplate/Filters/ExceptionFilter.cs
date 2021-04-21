using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace webapitemplate.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext exceptionContext)
        {
            exceptionContext.Result = new ObjectResult(exceptionContext.Exception.Message)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            base.OnException(exceptionContext);
        }
    }
}