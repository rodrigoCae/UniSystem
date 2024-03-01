using TesteUniSystem.Models;
using MediatR;

namespace TesteUniSystem.Recursos.Queries
{
    public class GetUsuarioPorIdQuery : IRequest<Usuario>
    {
        public int Id { get; set; }
    }
}
