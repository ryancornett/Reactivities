using MediatR;
using Domain;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Application.Activities;

public class List
{
    public class Query : IRequest<List<Activity>> {}

    public class Handler : IRequestHandler<Query, List<Activity>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public ILogger<List> Logger { get; }

        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellation)
        {
            return await _context.Activities.ToListAsync();
        }
    }
}
