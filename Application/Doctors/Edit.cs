using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;
using Application.Core;

namespace Application.Doctors
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Doctor Doctor { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Doctor).SetValidator(new DoctorValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var doctor = await _context.Doctors.FindAsync(request.Doctor.Id);

                if(doctor == null) return null;

                _mapper.Map(request.Doctor, doctor);
                var result = await _context.SaveChangesAsync() > 0;
                
                if(!result) return Result<Unit>.Failure("Failed to update doctor's data");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}