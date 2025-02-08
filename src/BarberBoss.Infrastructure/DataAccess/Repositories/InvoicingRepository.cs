using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace BarberBoss.Infrastructure.DataAccess.Repositories;
internal class InvoicingRepository : IInvoicingReadOnlyRepository, IInvoicingWriteOnlyRepository, IInvoicingUpdateOnlyRepository
{
    private readonly BarberBossDbContext _dbContext;
    public InvoicingRepository(BarberBossDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Invoicing expense)
    {
        await _dbContext.Invoicing.AddAsync(expense);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _dbContext.Invoicing.FirstOrDefaultAsync(expense => expense.Id == id);
        if(result is null)
        {
            return false;
        }

        _dbContext.Invoicing.Remove(result);

        return true;
    }

    public async Task<List<Invoicing>> GetAll()
    {
        return await _dbContext.Invoicing.AsNoTracking().ToListAsync();
    }

    async Task<Invoicing?> IInvoicingReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.Invoicing.AsNoTracking().FirstOrDefaultAsync(expense => expense.Id == id);
    }

    async Task<Invoicing?> IInvoicingUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Invoicing.FirstOrDefaultAsync(expense => expense.Id == id);
    }

    public void Update(Invoicing expense)
    {
        _dbContext.Invoicing.Update(expense);
    }

    public async Task<List<Invoicing>> FilterByMonth(DateOnly date)
    {
        
        var startDate = new DateTime
            (year: date.Year, 
            month: date.Month,
            day: 1).Date;

        var  daysInMonth = DateTime.DaysInMonth
            (year: date.Year,
             month: date.Month
             );

        var endDate = new DateTime
            (year: date.Year,
            month: date.Month,
            day: daysInMonth, 
            hour: 23,
            minute: 59, 
            second: 59);


        return await _dbContext
            .Invoicing
            .AsNoTracking()
            .Where(expense => expense.Date >= startDate && expense.Date <= endDate)
            .OrderBy(expense => expense.Date)
            .ThenBy(expense => expense.Title)
            .ToListAsync();
    }
}
