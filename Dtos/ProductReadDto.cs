using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.Dtos
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Nome{ get; set; }
        public double ValorUnitario{ get; set; }
        public int QuantidadeEstoque{ get; set; }
    }
}