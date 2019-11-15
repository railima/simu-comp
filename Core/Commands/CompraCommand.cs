using System;

namespace Core.Commands
{
    public abstract class CompraCommand
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public decimal? JurosSimples { get; set; }
        public decimal? JurosCompostos { get; set; }
        public DateTime Data { get; set; }
        public int Parcelas { get; set; }
        public decimal Valor { get; set; }
    }
}
