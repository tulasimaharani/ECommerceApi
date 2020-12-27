using System.ComponentModel.DataAnnotations;

namespace PaymentApi.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public Card Cartao { get; set; }
        public string Estado { get; set; }
    }
}