using TesteUnisystem.Context;
using TesteUniSystem.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TesteUnisystem.Recursos.Commands
{
    public class UsuarioUpdateCommandHandler : IRequestHandler<UsuarioUpdateCommand, Usuario>
    {
        private readonly AppDbContext _context;

        public UsuarioUpdateCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Handle(UsuarioUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Usuario = _context.Usuarios.Where(a => a.ID == request.ID).FirstOrDefault();
                if (Usuario == null)
                {
                    return default;
                }
                else
                {
                    Usuario.Nome = request.Nome;
                    Usuario.Email = request.Email;
                    Usuario.Telefone = request.Telefone;
                    Usuario.Idade = request.Idade;
                    await _context.SaveChangesAsync();
                    return Usuario;
                }
            }catch(Exception e)
            {
                throw new Exception("Ocorreu algum erro ao tentar atualizar o usuário: " + e.Message);
            }
        }
    }
}
