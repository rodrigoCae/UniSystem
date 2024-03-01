using TesteUniSystem.Models;
using MediatR;

namespace TesteUniSystem.Recursos.Commands
{
    public class UsuarioDeleteCommand : IRequest<Usuario>
    {
        public int ID { get; set; }
    }
}
