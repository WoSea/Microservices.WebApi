using Customer.Microservice.Context;
using MediatR; 
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Microservice.Features.Command
{
    public class UpdateCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, int>
        {
            private readonly IApplicationContext _context;
            public UpdateCustomerCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = _context.Customers.Where(a => a.Id == command.Id).FirstOrDefault();
                if (customer == null)
                {
                    return default;
                }
                else
                {
                    customer.Name = command.Name;
                    customer.Email = command.Email; 
                    await _context.SaveChanges();
                    return customer.Id;
                }
            }
        }
    }
}
