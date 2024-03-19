using API.Data;
using API.ViewModels;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route(template: "v1")]
    public class ContaController : ControllerBase
    {
        // Recebendo context via DI
        private readonly AppDbContext context;
        public ContaController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route(template: "contas")]
        public async Task<IActionResult> GetContasAsync()
        {
            var contas = await context
                .Contas
                .AsNoTracking()
                .ToListAsync();

            return contas != null ? Ok(contas) : NoContent();
        }

        [HttpGet]
        [Route(template: "contas/{id}")]
        public async Task<IActionResult> GetContaAsync(
            [FromRoute] int id
            )
        {
            var conta = await context
                .Contas
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            return conta != null ? Ok(conta) : NotFound();
        }

        [HttpPost]
        [Route(template: "contas")]
        public async Task<IActionResult> PostContaAsync(
            [FromBody] CreateContaViewModel model
            )
        {
            // Valida entrada de acordo com o modelo
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Atribui conta
            var conta = new Conta
            {
                Nome = model.Nome,
                ValorInicial = model.ValorInicial,
                DataVencimento = (DateOnly)model.DataVencimento,
                DataPagamento = (DateOnly)model.DataPagamento
            };

            // Calcula dias de atraso
            conta.DiasEmAtraso = Conta.CalculaDiasEmAtraso(conta.DataPagamento, conta.DataVencimento);
            
            // Calcula multa se houver atraso
            if (conta.DiasEmAtraso != 0)
            {
                var parametros = context
                .ParametrosCalculo
                .OrderByDescending(p => p.DiasEmAtraso)
                .FirstOrDefault(p => p.DiasEmAtraso <= conta.DiasEmAtraso);

                conta.ValorCorrigido = ParametrosCalculo.CalculaValorCorrigido(parametros, conta);
            }
            else
                conta.ValorCorrigido = conta.ValorInicial;

            // Insere registro no banco
            try
            {
                await context.Contas.AddAsync(conta);
                await context.SaveChangesAsync();

                return Created(uri: $"v1/contas/{conta.Id}", conta);
            }
            catch (Exception ex)
            {
                var retorno = Content(ex.Message);
                retorno.StatusCode = 500;

                return retorno;
            }
        }
    }
}