using API.Models;

namespace Tests.Models
{
    public class ParametrosCalculoTests
    {

        [Fact(DisplayName = "Criação de nova conta com sucesso")]
        public void Parametros_CriarParametrosCalculo_ComSucesso()
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


        [Theory(DisplayName = "Cálculo do valor corrigido com sucesso")]
        [InlineData(1, 100.0, 102.1, 0.02, 0.001)]
        [InlineData(3, 100.0, 102.3, 0.02, 0.001)]
        [InlineData(4, 100.0, 103.8, 0.03, 0.002)]
        [InlineData(10, 100.0, 105.0, 0.03, 0.002)]
        [InlineData(11, 100.0, 108.3, 0.05, 0.003)]
        public void Parametros_CalcularValorCorrigido_ComSucesso(int diasEmAtraso, double valorInicial, double resultadoEsperado, double multa, double jurosPorDia)
        {
            // Arrange
            var conta = new Conta()
            {
                DiasEmAtraso = diasEmAtraso,
                ValorInicial = valorInicial,
            };

            var parametros = new ParametrosCalculo()
            {
                DiasEmAtraso = diasEmAtraso,
                Multa = multa,
                JurosPorDia = jurosPorDia
            };

            // Act
            double resultado = ParametrosCalculo.CalculaValorCorrigido(parametros, conta);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}