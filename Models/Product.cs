namespace ECommerceApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nome{ get; set; }
        public double ValorUnitario{ get; set; }
        public int QuantidadeEstoque{ get; set; }

        public Product(int id, string nome, double valor_unitario, int qtde_estoque)
        {
            Id = id;
            Nome = nome;
            ValorUnitario = valor_unitario;
            QuantidadeEstoque = qtde_estoque;
        }
    }
}