using BarberBoss.Communication.Responses;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BarberBoss.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BarberBossException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }

    }

    public void HandleProjectException(ExceptionContext context)
    {
        var BarberBossException = (BarberBossException)context.Exception;
        var errorResponse = new ResponseErrorJson(BarberBossException.GetErrors());

        context.HttpContext.Response.StatusCode = BarberBossException.StatusCode;
        context.Result =new ObjectResult(errorResponse);
    }

    public void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOW_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
