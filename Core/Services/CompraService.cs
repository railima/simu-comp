using Core.DTOs;
using Core.Entities;
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

            //TODO: SALVAR DESSA FORMA IN MEMORY E BUSCAR ASSIM
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
                    ValorTotalJurosComposto = 0,
                    Parcelas = new List<ParcelaInfo>()
                };

                for (int i = 0; i < compra.QuantidadeParcela; i++)
                {
                    var parcela = new ParcelaInfo
                    {
                        DataVencimento = compra.Data.AddDays(30*i),
                        ValorJurosSimples = Math.Round((compra.Valor / compra.QuantidadeParcela) * (1 + compra.Juros * compra.QuantidadeParcela), 4),
                        ValorJurosComposto = Math.Round((compra.Valor / compra.QuantidadeParcela) * Math.Pow((1 + compra.Juros), compra.QuantidadeParcela), 4)
                    };
                    compraDTO.ValorTotalJurosSimples += parcela.ValorJurosSimples;
                    compraDTO.ValorTotalJurosComposto += parcela.ValorJurosComposto;
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
    }
}
