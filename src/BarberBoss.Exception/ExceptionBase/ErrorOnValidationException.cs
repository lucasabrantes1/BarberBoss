﻿using System.Net;

namespace BarberBoss.Exception.ExceptionBase;
public class ErrorOnValidationException : BarberBossException
{
    private readonly List<string> _erros; 

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
    {
        _erros = errorMessages; 
    }

    public override List<string> GetErrors()
    {
        return _erros;
    }
}
