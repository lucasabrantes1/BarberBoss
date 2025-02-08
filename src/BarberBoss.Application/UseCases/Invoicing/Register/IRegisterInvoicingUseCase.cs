using BarberBoss.Communication.Requests;
using BarberBoss.Communication.Responses;

namespace BarberBoss.Application.UseCases.Invoicing.Register;
public interface IRegisterInvoicingUseCase
{
    Task<ResponseRegisteredInvoicingJson> Execute(RequestInvoicingJson request);
}
