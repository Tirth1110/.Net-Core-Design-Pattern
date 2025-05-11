using Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository.DBContext;

namespace CQRS_Command.ProductQuery;

public record GetAllProductsQuery : IRequest<IEnumerable<Product>>;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly AppDbContext _context;

    public GetAllProductsQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products.ToListAsync();
    }
}
