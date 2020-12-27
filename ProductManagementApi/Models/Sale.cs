using System;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementApi.Models
{
    public class Sale
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required]
        public int QuantidadeComprada { get; set; }
        [Required]
        public Card Cartao { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
    }
}