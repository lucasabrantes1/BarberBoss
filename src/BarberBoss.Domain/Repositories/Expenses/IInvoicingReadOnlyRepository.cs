using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Expenses;
public interface IInvoicingReadOnlyRepository
{
    Task<List<Invoicing>> GetAll();
    Task<Invoicing?> GetById(long id);
    Task<List<Invoicing>> FilterByMonth(DateOnly month);
}
