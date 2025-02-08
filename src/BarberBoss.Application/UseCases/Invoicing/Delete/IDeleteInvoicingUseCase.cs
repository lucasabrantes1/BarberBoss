namespace BarberBoss.Application.UseCases.Invoicing.Delete;
public interface IDeleteInvoicingUseCase
{
    Task Execute(long id);
}
