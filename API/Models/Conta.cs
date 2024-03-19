using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Nome { get; set; }

        [Required]
        [Range(double.Epsilon, double.MaxValue)]
        public double ValorInicial { get; set; }

        public double ValorCorrigido { get; set; }

        [Required]
        public DateOnly DataVencimento { get; set; }

        [Required]
        public DateOnly DataPagamento { get; set; }

        public int DiasEmAtraso { get; set; }

        public static int CalculaDiasEmAtraso(DateOnly DataPagamento, DateOnly DataVencimento)
        {
            if (DataPagamento <= DataVencimento)
                return 0;

            else
                return DataPagamento.DayNumber - DataVencimento.DayNumber;
        }
    }
}
