using MediatR;
using Domain;
using System;
using System.Threading.Tasks;
using System.Threading;
using Persistence;

namespace Application.Doctors
{
    public class Details
    {
        public class Query : IRequest<Doctor>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Doctor>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Doctor> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Doctors.FindAsync(request.Id);
            }
        }
    }
}