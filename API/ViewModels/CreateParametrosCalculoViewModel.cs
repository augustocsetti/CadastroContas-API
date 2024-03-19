using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    [Index(nameof(DiasEmAtraso), IsUnique = true)]
    public class CreateParametrosCalculoViewModel
    {
        [Required(ErrorMessage = "A quantidade de dias em atraso é obrigatória")]
        public int? DiasEmAtraso { get; set; }

        [Required]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "O valor da multa é obrigatório e deve conter um valor positivo")]
        public double Multa { get; set; }

        [Required]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "O valor de juros por dia é obrigatório e deve conter um valor positivo")]
        public double JurosPorDia { get; set; }
    }
}
