using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Invoicing.GetAll;
public interface IGetAllInvoicingUseCase
{
    Task<ResponsesInvoicingJson> Execute();
}
