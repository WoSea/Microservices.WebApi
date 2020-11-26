using MediatR;
using Product.Microservice.Context; 
using System.Threading;
using System.Threading.Tasks;

namespace Product.Microservice.Features.Command
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; } 
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateProductCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product.Microservice.Models.Product(); 
                product.Name = command.Name; 
                _context.Products.Add(product);
                await _context.SaveChanges();
                return product.Id;
            }
        }
    }
}
