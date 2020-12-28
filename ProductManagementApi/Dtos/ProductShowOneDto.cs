using System;
using System.ComponentModel.DataAnnotations;

namespace ProductManagementApi.Dtos
{
    public class ProductShowOneDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome{ get; set; }
        [Required]
        public double ValorUnitario{ get; set; }
        [Required]
        public int QuantidadeEstoque{ get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
    }
}