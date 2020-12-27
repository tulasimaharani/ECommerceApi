using System.ComponentModel.DataAnnotations;
using PaymentApi.Models;

namespace PaymentApi.Dtos
{
    public class PaymentReadDto
    {
        [Required]
        public double Valor { get; set; }
        [Required]
        public Card Cartao { get; set; }
        public string Estado { get; set; }
    }
}