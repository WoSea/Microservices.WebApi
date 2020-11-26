
using Customer.Microservice.Context;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Microservice.Features.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer.Microservice.Models.Customer>
    {
        public int  Id { get; set; }
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer.Microservice.Models.Customer>
        {
            private readonly IApplicationContext _context;
            public GetCustomerByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<Customer.Microservice.Models.Customer> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
            {
                var customer = _context.Customers.Where(a => a.Id == query.Id).FirstOrDefault();
                if (customer == null) return null;
                return customer;
            }
        }
    }
}
