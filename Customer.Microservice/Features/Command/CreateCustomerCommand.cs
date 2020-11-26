using Customer.Microservice.Context;
using MediatR; 
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Microservice.Features.Command
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateCustomerCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = new Customer.Microservice.Models.Customer();
                customer.Name = command.Name;
                customer.Email = command.Email; 
                _context.Customers.Add(customer);
                await _context.SaveChanges();
                return customer.Id;
            }
        }
    }
}
