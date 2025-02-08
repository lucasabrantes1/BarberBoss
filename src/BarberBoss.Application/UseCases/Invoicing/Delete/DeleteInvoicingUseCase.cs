using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Expenses;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionBase;

namespace BarberBoss.Application.UseCases.Invoicing.Delete;
public class DeleteInvoicingUseCase : IDeleteInvoicingUseCase
{
    private readonly IInvoicingWriteOnlyRepository _repository;
    private IUniteOfWork _unitOfWork;

    public DeleteInvoicingUseCase(
        IInvoicingWriteOnlyRepository repository,
        IUniteOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }


    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        await _unitOfWork.Commit();
    }

}
