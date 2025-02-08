using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Expenses;
public interface IInvoicingUpdateOnlyRepository
{   
    Task<Invoicing?> GetById(long id); 
    void Update(Invoicing expense);

}
