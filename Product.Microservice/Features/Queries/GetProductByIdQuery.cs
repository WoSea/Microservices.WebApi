using MediatR;
using Product.Microservice.Context; 
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Microservice.Features.Queries
{
    public class GetProductByIdQuery : IRequest<Product.Microservice.Models.Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product.Microservice.Models.Product>
        {
            private readonly IApplicationContext _context;
            public GetProductByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<Product.Microservice.Models.Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = _context.Products.Where(a => a.Id == query.Id).FirstOrDefault();
                if (product == null) return null;
                return product;
            }
        }
    }
}
