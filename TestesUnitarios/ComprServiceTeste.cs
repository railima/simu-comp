using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.ICommandHandlers;
using Core.Services;
using NSubstitute;
using Xunit;

namespace TestesUnitarios
{
    public class ComprServiceTeste
    {
        [Fact]
        public void DeveRetornarTodosCorretamente()
        {
            var repository = Substitute.For<ICompraRepository>();
            var command = Substitute.For<ISalvarSimulacaoCommandHandler>();
            var service = new CompraService(command, repository);

            var ex = Record.Exception(() => service.GetAll());
            Assert.Null(ex);
            repository.Received(1).GetAll();
        }
        
        [Fact]
        public void DeveSalvarCorretamente()
        {
            var repository = Substitute.For<ICompraRepository>();
            var command = Substitute.For<ISalvarSimulacaoCommandHandler>();
            var service = new CompraService(command, repository);
            var compraDTO = new CompraDTO();
            var compra = new Compra();


            var ex = Record.Exception(() => command.Handle(compraDTO));
            Assert.Null(ex);
            command.Received(1).Handle(compraDTO);
            var exRepo = Record.Exception(() => repository.Salvar(compra));
            repository.Received(1).Salvar(compra);
        }
        
        [Fact]
        public void DeveRetornarCompraDTOCorretamente()
        {
            var repository = Substitute.For<ICompraRepository>();
            var command = Substitute.For<ISalvarSimulacaoCommandHandler>();
            var service = new CompraService(command, repository);
            var compra = new CompraDTO();

            var ex = Record.Exception(() => service.Simular(compra.Valor, compra.Juros, compra.QuantidadeParcela, compra.Data));
            Assert.Null(ex);
        }
    }
}
