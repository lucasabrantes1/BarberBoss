namespace BarberBoss.Domain.Repositories;
public interface IUniteOfWork
{
    Task Commit();
}
