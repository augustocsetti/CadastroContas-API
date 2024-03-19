using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class GetContaViewModel
    {
        public string Nome { get; set; }

        public double ValorInicial { get; set; }

        public double ValorCorrigido { get; set; }

        public DateOnly DataVencimento { get; set; }

        public DateOnly DataPagamento { get; set; }

        public int DiasEmAtraso { get; set; }
    }
}
