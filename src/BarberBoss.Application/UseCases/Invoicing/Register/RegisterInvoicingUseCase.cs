using AutoMapper;
using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;
using DomainInvoicing = BarberBoss.Domain.Entities.Invoicing;
using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Expenses;
using BarberBoss.Exception.ExceptionBase;

namespace BarberBoss.Application.UseCases.Invoicing.Register;
public class RegisterInvoicingUseCase : IRegisterInvoicingUseCase
{
    private readonly IInvoicingWriteOnlyRepository _repository;
    private readonly IUniteOfWork _uniteOfWork;
    private readonly IMapper _mapper;
    public RegisterInvoicingUseCase(
        IInvoicingWriteOnlyRepository repository,
        IUniteOfWork uniteOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _uniteOfWork = uniteOfWork;
        _mapper = mapper;

    }

    public async Task<ResponseRegisteredInvoicingJson> Execute(RequestInvoicingJson request)
    {
        try
        {
            Validate(request);

            // Utilize o alias DomainInvoicing para garantir que o tipo correto seja utilizado.
            var entity = _mapper.Map<DomainInvoicing>(request);

            await _repository.Add(entity);
            await _uniteOfWork.Commit();

            return _mapper.Map<ResponseRegisteredInvoicingJson>(entity);
        }
        catch (System.Exception ex)
        {
            // Registre o erro (por exemplo: _logger.LogError(ex, "Erro ao registrar a fatura."))
            throw; // Ou lance uma exceção mais detalhada, se necessário.
        }
    }



    private void Validate(RequestInvoicingJson request)
    {
        var validator = new InvoicingValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}

