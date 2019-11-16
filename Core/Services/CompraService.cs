using Core.DTOs;
using Core.Interfaces;
using Core.Interfaces.ICommandHandlers;
using Core.Interfaces.IServices;
using System;
using System.Collections.Generic;

namespace Core.Services
{
    public class CompraService : ICompraService
    {
        private readonly ISalvarSimulacaoCommandHandler _salvarSimulacao;
        private readonly ICompraRepository _compraRepository;

        public CompraService(ISalvarSimulacaoCommandHandler salvarSimulacao, ICompraRepository compraRepository)
        {
            _salvarSimulacao = salvarSimulacao;
            _compraRepository = compraRepository;
        }

        public IEnumerable<CompraDTO> GetAll()
        {
            var compras = _compraRepository.GetAll();
            var comprasDTO = new List<CompraDTO>();

            foreach (var compra in compras)
            {
                var compraDTO = new CompraDTO
                {
                    Id = compra.Id,
                    Descricao = compra.Descricao,
                    Data = compra.Data,
                    Juros = compra.Juros,
                    QuantidadeParcela = compra.QuantidadeParcela,
                    Valor = compra.Valor,
                    ValorTotalJurosSimples = 0,
                    Parcelas = new List<ParcelaInfo>()
                };
                var compraCalculada = Simular(compra.Valor, compra.Juros, compra.QuantidadeParcela, compra.Data);
                compraDTO.Parcelas = compraCalculada.Parcelas;
                compraDTO.ValorTotalJurosSimples = compraCalculada.ValorTotalJurosSimples;
                comprasDTO.Add(compraDTO);
            }
            return comprasDTO;
        }

        public bool Salvar(CompraDTO compra)
        {
            if (_salvarSimulacao.Handle(compra))
            {
                return true;
            }
            return false;
        }

        public CompraDTO Simular(double valor, double juros, int quantidadeParcela, DateTime data)
        {
            var compraDTO = new CompraDTO
            {
                Parcelas = new List<ParcelaInfo>()
            };
            for (int i = 0; i < quantidadeParcela; i++)
            {
                var valorPrestacaoSimples = (valor * Math.Pow((1 + (juros / 100)), quantidadeParcela) * (juros / 100)) / (Math.Pow((1 + (juros / 100)), quantidadeParcela) - 1);
                var parcela = new ParcelaInfo
                {
                    DataVencimento = data.AddDays(30 * (i + 1)),
                    ValorJurosSimples = Math.Round(valorPrestacaoSimples, 2),
                    Valor = Math.Round(valor / quantidadeParcela, 2),
                    Numero = i + 1
                };
                compraDTO.ValorTotalJurosSimples = Math.Round(valorPrestacaoSimples * quantidadeParcela, 2);
                compraDTO.Parcelas.Add(parcela);
            }

            return compraDTO;
        }
    }
}
