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

            ////TODO: SALVAR DESSA FORMA IN MEMORY E BUSCAR ASSIM
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

                for (int i = 0; i < compra.QuantidadeParcela; i++)
                {
                    var valorPrestacaoSimples = (compra.Valor * Math.Pow((1 + (compra.Juros / 100)), compra.QuantidadeParcela) * (compra.Juros / 100)) / (Math.Pow((1 + (compra.Juros / 100)), compra.QuantidadeParcela) - 1);
                    var parcela = new ParcelaInfo
                    {
                        DataVencimento = compra.Data.AddDays(30 * (i + 1)),
                        ValorJurosSimples = Math.Round(valorPrestacaoSimples, 2),
                        Valor = Math.Round(compra.Valor / compra.QuantidadeParcela, 2),
                        Numero = i + 1
                    };
                    compraDTO.ValorTotalJurosSimples = Math.Round(valorPrestacaoSimples * compra.QuantidadeParcela, 2);
                    compraDTO.Parcelas.Add(parcela);
                }

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
