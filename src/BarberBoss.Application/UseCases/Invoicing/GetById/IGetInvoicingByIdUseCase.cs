using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Invoicing.GetById;
public interface IGetInvoicingByIdUseCase
{
    Task<ResponseExpenseJson> Execute(long id);
}
