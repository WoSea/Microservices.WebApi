using Customer.Microservice.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Microservice.Features.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer.Microservice.Models.Customer>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer.Microservice.Models.Customer>>
        {
            private readonly IApplicationContext _context;
            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Customer.Microservice.Models.Customer>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Customers.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
