using System.ComponentModel.DataAnnotations;

namespace ProductManagementApi.Dtos
{
    public class ProductReadDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome{ get; set; }
        [Required]
        public double ValorUnitario{ get; set; }
        [Required]
        public int QuantidadeEstoque{ get; set; }
    }
}