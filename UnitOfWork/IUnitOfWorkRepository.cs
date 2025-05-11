using Repository;

namespace UnitOfWork;

public interface IUnitOfWorkRepository
{
    IProductRepository Products { get; }
    Task<bool> SaveAsync();
}