using API.Data;
using API.ViewModels;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace API.Controllers
{
    [ApiController]
    [Route(template: "v1")]
    public class ParametrosCalculoController : ControllerBase
    {
        // Recebendo context via DI
        private readonly AppDbContext context;
        public ParametrosCalculoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route(template: "parametros")]
        public async Task<IActionResult> GetParametrosAsync()
        {
            var parametros = await context
                .ParametrosCalculo
                .AsNoTracking()
                .ToListAsync();

            return parametros != null ? Ok(parametros) : NoContent();
        }

        [HttpGet]
        [Route(template: "parametros/{id}")]
        public async Task<IActionResult> GetParametroAsync(
            [FromRoute] int id
            )
        {
            var parametro = await context
                .ParametrosCalculo
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id>= id);

            return parametro != null ? Ok(parametro) : NotFound();
        }

        [HttpPost]
        [Route(template: "parametros")]
        public async Task<IActionResult> PostParametroCalculoAsync(
            [FromBody] CreateParametrosCalculoViewModel model
            )
        {
            // Valida entrada de acordo com o modelo
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Atribui conta
            var parametrosCalculo = new ParametrosCalculo
            {
                DiasEmAtraso = (int) model.DiasEmAtraso,
                Multa = model.Multa,
                JurosPorDia = model.JurosPorDia,
            };

            // Insere registro no banco
            try
            {
                await context.ParametrosCalculo.AddAsync(parametrosCalculo);
                await context.SaveChangesAsync();

                return Created(uri: $"v1/parametros/{parametrosCalculo.Id}", parametrosCalculo);
            }
            // Caso ocorra erro na unique constraint do campo dias de atraso
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            // Erro no servidor
            catch (Exception ex)
            {
                var retorno = Content(ex.Message);
                retorno.StatusCode = 500;

                return retorno;
            }
        }
    }
}
