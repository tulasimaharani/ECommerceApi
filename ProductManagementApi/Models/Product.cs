using System.ComponentModel.DataAnnotations;

namespace ProductManagementApi.Models
{
    public class Product
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