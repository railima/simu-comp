using Core.Commands;
using Core.Entities;
using Core.Interfaces;
using System;

namespace Core.CommandHandlers
{
    public class SalvarSimulacaoCommandHandler
    {
        private readonly ICompraRepository _compraRepository;

        public SalvarSimulacaoCommandHandler(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        public bool Handle(CompraCommand command)
        {
            var compra = new Compra(command.Descricao, command.JurosSimples, 
                command.JurosCompostos, command.Data, command.Parcelas, command.Valor);

            try
            {
                _compraRepository.Salvar(compra);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
