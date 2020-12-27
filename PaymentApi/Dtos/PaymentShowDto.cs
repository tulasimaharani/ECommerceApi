using System.ComponentModel.DataAnnotations;
using PaymentApi.Models;

namespace PaymentApi.Dtos
{
    public class PaymentShowDto
    {
        [Required]
        public double Valor { get; set; }
        [Required]
        public string Estado { get; set; }
    }
}