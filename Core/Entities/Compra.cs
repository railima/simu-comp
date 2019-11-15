using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class Compra
    {
        public Compra(string descricao, double juros, DateTime data, int parcela, double valor) 
        {
            Descricao = descricao;
            Juros = juros;
            Data = data;
            QuantidadeParcela = parcela;
            Valor = valor;
        }

        public Compra()
        {

        }

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }
        [Required]
        [Column(TypeName = "decimal(15, 4)")]
        public double Juros { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Data { get; set; }
        [Required]
        public int QuantidadeParcela { get; set; }
        [Column(TypeName = "decimal(15, 2)")]
        [Required]
        public double Valor { get; set; }
    }
}
