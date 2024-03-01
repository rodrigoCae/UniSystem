using TesteUnisystem.Context;
using TesteUniSystem.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TesteUniSystem.Recursos.Queries
{
    public class GetTodosUsuariosQueryHandler : IRequestHandler<GetTodosUsuariosQuery, IEnumerable<Usuario>>
    {
        private readonly AppDbContext _context;

        public GetTodosUsuariosQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> Handle(GetTodosUsuariosQuery request, CancellationToken cancellationToken)
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}
