using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class Compra
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }
        [Column(TypeName = "decimal(4, 4)")]
        public decimal? JurosSimples { get; set; }
        [Column(TypeName = "decimal(4, 4)")]
        public decimal? JurosCompostos { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public int Parcelas { get; set; }
        [Column(TypeName = "decimal(4, 2)")]
        [Required]
        public decimal Valor { get; set; }
    }
}
