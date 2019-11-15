using Core.CommandHandlers;
using Core.Commands;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.IServices;
using System.Collections.Generic;

namespace Core.Services
{
    public class CompraService : ICompraService
    {
        private readonly SalvarSimulacaoCommandHandler _salvarSimulacao;
        private readonly ICompraRepository _compraRepository;

        public CompraService(SalvarSimulacaoCommandHandler salvarSimulacao, ICompraRepository compraRepository)
        {
            _salvarSimulacao = salvarSimulacao;
            _compraRepository = compraRepository;
        }

        public IEnumerable<Compra> GetAll()
        {
            return _compraRepository.GetAll();
        }

        public bool Salvar(CompraCommand compra)
        {
            if (_salvarSimulacao.Handle(compra))
            {
                return true;
            }
            return false;
        }
    }
}
