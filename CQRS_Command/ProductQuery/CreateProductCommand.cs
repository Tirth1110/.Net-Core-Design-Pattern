using Entity;
using MediatR;
using Repository.DBContext;

namespace CQRS_Command.ProductQuery;

public record CreateProductCommand(string Name, decimal Price) : IRequest<Product>;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly AppDbContext _context;

    public CreateProductCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product? product = new() { Name = request.Name, Price = request.Price };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }
}