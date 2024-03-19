using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class CreateContaViewModel
    {
        [Required(ErrorMessage = "O nome da conta é obrigatório")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "O campo deve conter de 1 a 255 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O valor inicial é obrigatório")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "O campo deve conter um valor positivo")]
        public double ValorInicial { get; set; }

        [Required(ErrorMessage = "A data de vencimento é obrigatória")]
        public DateOnly? DataVencimento { get; set; }

        [Required(ErrorMessage = "A data de pagamento é obrigatória")]
        public DateOnly? DataPagamento { get; set; }
    }
}
