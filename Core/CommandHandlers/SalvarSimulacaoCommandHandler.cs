using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.ICommandHandlers;
using System;

namespace Core.CommandHandlers
{
    public class SalvarSimulacaoCommandHandler : ISalvarSimulacaoCommandHandler
    {
        private readonly ICompraRepository _compraRepository;

        public SalvarSimulacaoCommandHandler(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        public bool Handle(CompraDTO dto)
        {
            var novaCompra = new Compra(dto.Descricao, dto.Juros, dto.Data, dto.QuantidadeParcela, dto.Valor);

            try
            {
                _compraRepository.Salvar(novaCompra);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
