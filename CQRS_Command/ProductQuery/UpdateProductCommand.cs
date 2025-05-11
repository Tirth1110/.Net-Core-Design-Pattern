using MediatR;
using Repository.DBContext;

namespace CQRS_Command.ProductQuery;

public record UpdateProductCommand(int Id, string Name, decimal Price) : IRequest<bool>;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly AppDbContext _context;

    public UpdateProductCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.Id);
        if (product == null) return false;

        product.Name = request.Name;
        product.Price = request.Price;

        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return true;
    }
}