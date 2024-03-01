using TesteUniSystem.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TesteUnisystem.Context;

namespace TesteUniSystem.Recursos.Commands
{
    public class UsuarioCommandHandler : IRequestHandler<UsuarioDeleteCommand, Usuario>
    {
        private readonly AppDbContext _context;

        public UsuarioCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Handle(UsuarioDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Usuario = await _context.Usuarios.Where(a => a.ID == request.ID).FirstOrDefaultAsync();
                _context.Remove(Usuario);
                await _context.SaveChangesAsync();
                return Usuario;
            }catch(Exception e)
            {
                throw new Exception("Ocorreu algum erro ao tentar excluir o usuário: " + e.Message);
            }
        }
    }
}
