using Microsoft.AspNetCore.Mvc;
using TesteUniSystem.Models;
using TesteUniSystem.Recursos.Commands;
using Xunit;
using TesteUnisystem.Context;
using TesteUniSystem.Recursos.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteUnisystem.Recursos.Commands;
using Moq;
using System.Reflection.Metadata;

namespace TestTesteUniSystem
{
    public class UsuarioCommandHandlerTest
    {
        private readonly UsuarioCommandHandler _handler;

        public UsuarioCommandHandlerTest()
        {
            _handler = new UsuarioCommandHandler(new Mock<AppDbContext>().Object);
        }

        [Fact]
        public void DeletarUsuarioErro()
        {
            var result = _handler.Handle(new UsuarioDeleteCommand() { ID = 'A' }, new CancellationToken());
            Assert.Null(result);
        }

        [Fact]
        public void DeletarUsuarioAcerto()
        {
            var result = _handler.Handle(new UsuarioDeleteCommand() { ID = 3 }, new CancellationToken());
            Assert.NotNull(result);
        }
    }
}
