using Repository;
using Repository.DBContext;

namespace UnitOfWork;

public class UnitOfWorkRepository(AppDbContext context) : IUnitOfWorkRepository
{
    private readonly AppDbContext _context = context;
    private IProductRepository _productRepository;

    public IProductRepository Products => _productRepository ??= new ProductRepository(_context);

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}