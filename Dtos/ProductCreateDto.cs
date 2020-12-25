using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Dtos
{
    public class ProductCreateDto
    {
        [Required]
        public string Nome{ get; set; }
        [Required]
        public double ValorUnitario{ get; set; }
        [Required]
        public int QuantidadeEstoque{ get; set; }
    }
}