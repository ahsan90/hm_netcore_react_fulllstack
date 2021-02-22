using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Doctors
{
    public class List
    {
        public class Query : IRequest<List<Doctor>> { }

        public class Handler : IRequestHandler<Query, List<Doctor>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Doctor>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Doctors.ToListAsync();
            }
        }
    }
}
