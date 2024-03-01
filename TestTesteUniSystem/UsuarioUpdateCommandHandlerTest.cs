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

namespace TestTesteUniSystem
{
    public class UsuarioUpdateCommandHandlerTest
    {
        private readonly UsuarioUpdateCommandHandler _handler;

        public UsuarioUpdateCommandHandlerTest()
        {
            _handler = new UsuarioUpdateCommandHandler(new Mock<AppDbContext>().Object);
        }

        [Fact]
        public void PutUsuarioErroNome()
        {
            var result = _handler.Handle(new UsuarioUpdateCommand() { ID=2, Nome = "A", Email = "teste@teste.com", Idade = 10, Telefone = "119876-1234" }, new CancellationToken());
            Assert.Null(result);
        }

        [Fact]
        public void PutUsuarioErroEmail()
        {
            var result = _handler.Handle(new UsuarioUpdateCommand() { ID = 2, Nome = "Novo Teste", Email = "", Idade = 50, Telefone = "119876-1235" }, new CancellationToken());
            Assert.Null(result);
        }

        [Fact]
        public void PutUsuarioErroIdade()
        {
            var result = _handler.Handle(new UsuarioUpdateCommand() {ID = 2, Nome = "Novo Teste", Email = "teste@teste.com.br", Idade = 40, Telefone = "119876-1235" }, new CancellationToken());
            Assert.Null(result);
        }

        [Fact]
        public void PutUsuarioErroTelefone()
        {
            var result = _handler.Handle(new UsuarioUpdateCommand() {ID = 2, Nome = "Novo Teste", Email = "teste@teste.com.br", Idade = 40, Telefone = "" }, new CancellationToken());
            Assert.Null(result);
        }

        [Fact]
        public void PutUsuarioCorreto()
        {
            var result = _handler.Handle(new UsuarioUpdateCommand() {ID = 2, Nome = "Novo Teste", Email = "teste@teste.com.br", Idade = 40, Telefone = "119876-1235" }, new CancellationToken());
            Assert.NotNull(result);
        }

    }
}
