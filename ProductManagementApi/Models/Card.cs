using System.ComponentModel.DataAnnotations;

namespace ProductManagementApi.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titular { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string DataExpiracao { get; set; }
        [Required]
        public string Bandeira { get; set; }
        [Required]
        public int Cvv { get; set; }

    }
}