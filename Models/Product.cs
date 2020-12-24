using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Models
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

        public Product(int Id, string Nome, double ValorUnitario, int QuantidadeEstoque)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.ValorUnitario = ValorUnitario;
            this.QuantidadeEstoque = QuantidadeEstoque;
        }
    }
}