using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Microservice.Context;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Microservice.Features.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product.Microservice.Models.Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product.Microservice.Models.Product>>
        {
            private readonly IApplicationContext _context;
            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Product.Microservice.Models.Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
