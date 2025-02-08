using BarberBoss.Communication.Requests;
using System.Threading.Tasks;

namespace BarberBoss.Application.UseCases.Invoicing.Update;
public interface IUpdateInvoicingUseCase
{
    Task Execute(long id, RequestInvoicingJson request);
}
