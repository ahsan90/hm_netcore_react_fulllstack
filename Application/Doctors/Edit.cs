using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Doctors
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Doctor Doctor { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var doctor = await _context.Doctors.FindAsync(request.Doctor.Id);

                _mapper.Map(request.Doctor, doctor);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}