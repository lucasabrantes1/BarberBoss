using BarberBoss.Domain.Repositories;

namespace BarberBoss.Infrastructure.DataAccess;
internal class UniteOfWork : IUniteOfWork
{
    private readonly BarberBossDbContext _dbContext;
    public UniteOfWork(BarberBossDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
