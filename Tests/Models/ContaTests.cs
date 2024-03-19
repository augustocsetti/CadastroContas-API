using API.Models;

namespace Tests.Models
{
    public class ContaTests
    {
        [Fact(DisplayName = "Criação de nova conta com sucesso")]
        public void Conta_CriarConta_ComSucesso()
        {
            // Arrange
            string nome = "Tarefa Teste";
            double valorInicial = 100.00;
            DateOnly dataVencimento = DateOnly.Parse("2024-01-01");
            DateOnly dataPagamento = DateOnly.Parse("2024-01-01");

            // Act
            var conta = new Conta
            {
                Nome = nome,
                ValorInicial = valorInicial,
                DataVencimento = dataVencimento,
                DataPagamento = dataPagamento,
            };

            // Assert
            Assert.Equal(conta.Nome, nome);
            Assert.Equal(conta.ValorInicial, valorInicial);
            Assert.Equal(conta.DataVencimento, dataVencimento);
            Assert.Equal(conta.DataPagamento, dataPagamento);
        }

        [Theory(DisplayName = "Cálculo do(s) dia(s) de atraso com sucesso")]
        [InlineData("2000-01-09", "2000-01-10", 0)]
        [InlineData("2000-01-10", "2000-01-10", 0)]
        [InlineData("2000-01-11", "2000-01-10", 1)]
        [InlineData("2000-01-12", "2000-01-10", 2)]
        public void Conta_CalcularDiasDeAtraso_ComSucesso(string dataPagamentoStr, string dataVencimentoStr, int resultadoEsperado)
        {
            // Arrange
            DateOnly dataPagamento = DateOnly.Parse(dataPagamentoStr);
            DateOnly dataVencimento = DateOnly.Parse(dataVencimentoStr);

            //// Act
            int resultado = Conta.CalculaDiasEmAtraso(dataPagamento, dataVencimento);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}