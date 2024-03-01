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
    public class UsuarioCreateCommandHandlerTest
    {
        private readonly UsuarioCreateCommandHandler _handler;

        public UsuarioCreateCommandHandlerTest()
        {
            _handler = new UsuarioCreateCommandHandler(new Mock<AppDbContext>().Object);
        }

        [Fact]
        public void PostUsuarioErroNome()
        {
            var result = _handler.Handle(new UsuarioCreateCommand(){ Nome = "A", Email = "teste@teste.com", Idade = 10, Telefone = "119876-1234" }, new CancellationToken());
            Assert.Null(result);
        }

        [Fact]
        public void PostUsuarioErroEmail()
        {
            var result = _handler.Handle(new UsuarioCreateCommand() { Nome = "Novo Teste", Email = "", Idade = 50, Telefone = "119876-1235" }, new CancellationToken());
            Assert.Null(result);
        }

        [Fact]
        public void PostUsuarioErroIdade()
        {
            var result = _handler.Handle(new UsuarioCreateCommand() { Nome = "Novo Teste", Email = "teste@teste.com.br", Idade = 40, Telefone = "119876-1235" }, new CancellationToken());
            Assert.Null(result);
        }

        [Fact]
        public void PostUsuarioErroTelefone()
        {
            var result = _handler.Handle(new UsuarioCreateCommand() { Nome = "Novo Teste", Email = "teste@teste.com.br", Idade = 40, Telefone = "" }, new CancellationToken());
            Assert.Null(result);
        }

        [Fact]
        public void PostUsuarioCorreto()
        {
            var result = _handler.Handle(new UsuarioCreateCommand() { Nome = "Novo Teste", Email = "teste@teste.com.br", Idade = 40, Telefone = "119876-1235" }, new CancellationToken());
            Assert.NotNull(result);
        }
    }
}