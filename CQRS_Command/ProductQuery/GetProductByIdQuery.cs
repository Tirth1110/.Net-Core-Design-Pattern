using Entity;
using MediatR;
using Repository.DBContext;

namespace CQRS_Command.ProductQuery;

public record GetProductByIdQuery(int Id) : IRequest<Product>;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly AppDbContext _context;

    public GetProductByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products.FindAsync(request.Id);
    }
}