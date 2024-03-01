using TesteUnisystem.Context;
using TesteUniSystem.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace TesteUniSystem.Recursos.Queries
{
    public class GetUsuarioPorIdQueryHandler : IRequestHandler<GetUsuarioPorIdQuery, Usuario>
    {
        private readonly AppDbContext _context;

        public GetUsuarioPorIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario> Handle(GetUsuarioPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.ID == request.Id, cancellationToken);
        }
    }
}
