using System.ComponentModel.DataAnnotations;

namespace ProductManagementApi.Dtos
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