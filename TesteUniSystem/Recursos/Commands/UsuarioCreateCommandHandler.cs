using TesteUniSystem.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TesteUnisystem.Context;

namespace TesteUniSystem.Recursos.Commands
{
    public class UsuarioCreateCommandHandler : IRequestHandler<UsuarioCreateCommand, Usuario>
    {
        private readonly AppDbContext _context;

        public UsuarioCreateCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Usuario = new Usuario();
                Usuario.Nome = request.Nome;
                Usuario.Email = request.Email;
                Usuario.Telefone = request.Telefone;
                Usuario.Idade = request.Idade;

                _context.Usuarios.Add(Usuario);
                await _context.SaveChangesAsync();
                return Usuario;
            }catch(Exception e)
            {
                throw new Exception(@"Ocorreu algum erro ao tentar incluir um novo usuário: \n" + e.Message);
            }
        }
    }
}
