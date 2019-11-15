using System;
using System.Collections.Generic;
using Core.Entities;

namespace Core.DTOs
{
    public class CompraDTO
    {
        public CompraDTO()
        {
        }
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public double Juros { get; set; }
        public DateTime Data { get; set; }
        public int QuantidadeParcela { get; set; }
        public double Valor { get; set; }
        public double ValorTotalJurosSimples { get; set; }
        public double ValorTotalJurosComposto { get; set; }
        public ICollection<ParcelaInfo> Parcelas { get; set; }
    }
    public class ParcelaInfo
    {
        public DateTime DataVencimento { get; set; }
        public double ValorJurosSimples { get; set; }
        public double ValorJurosComposto { get; set; }

    }
}

