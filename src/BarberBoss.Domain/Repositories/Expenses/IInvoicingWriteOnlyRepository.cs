using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Expenses;
public interface IInvoicingWriteOnlyRepository
{
    Task Add(Invoicing expense);

    /// <summary>
    /// This function returns TRUE if the deletion was successful, otherwise FALSE.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
}
