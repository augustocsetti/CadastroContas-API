using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    [Index(nameof(DiasEmAtraso), IsUnique = true)]
    public class ParametrosCalculo
    {
        [Key]
        public int Id { get; set;  }

        [Required]
        [Range(1, int.MaxValue)]
        public int DiasEmAtraso { get; set; }

        [Required]
        [Range(double.Epsilon, double.MaxValue)]
        public double Multa { get; set; }

        [Required]
        [Range(double.Epsilon, double.MaxValue)]
        public double JurosPorDia { get; set; }

        public static double CalculaValorCorrigido(ParametrosCalculo parametrosCalculo, Conta conta)
        {
            return conta.ValorInicial * (1.0 + parametrosCalculo.Multa + conta.DiasEmAtraso * parametrosCalculo.JurosPorDia);
        }

    }


}
