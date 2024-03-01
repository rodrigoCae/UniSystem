using TesteUniSystem.Models;
using MediatR;
using System.Collections.Generic;

namespace TesteUniSystem.Recursos.Queries
{
    public class GetTodosUsuariosQuery : IRequest<IEnumerable<Usuario>>
    {
    }
}

