using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class GetParametrosCalculoViewModel
    {
        public int DiasEmAtraso { get; set; }

        public double Multa { get; set; }

        public double JurosPorDia { get; set; }
    }
}
