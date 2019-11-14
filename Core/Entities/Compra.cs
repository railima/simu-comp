using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Compra
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal JurosSimples { get; set; }
        public decimal JurosCompostos { get; set; }
        public DateTime Data { get; set; }
        public int Parcelas { get; set; }
    }
}
