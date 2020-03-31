using Calculadora.Lib.Tests.Unit.Builders;
using FluentAssertions;
using Xunit;

namespace Calculadora.Lib.Tests.Unit
{
    /// <summary>
    /// Desenvolvedores   com Salário maior que R$ 3.000,00 receberá 20% de desconto, caso contrário, o desconto é de 10%.
    /// DBAs e Testadores com Salário maior que R$ 2.500,00 receberá 25% de desconto, caso contrário, o desconto é de 15%.
    /// </summary>
    public class CalculadoraDeSalarioTest
    {
        readonly CalculadoraDeSalario _calculadora;
        public CalculadoraDeSalarioTest()
        {
            _calculadora = new CalculadoraDeSalario();
        }

        [Theory(DisplayName = "Cenário 01 - DEVs Com Salario Menor que R$ 3.000")]
        [InlineData(1500.0)]
        [InlineData(2500.0)]
        public void DeveCalcularSalarioParaDesenvolvedoresComSalarioAbaixoDoLimite(double salario)
        {
            //Arrange
            var funcionario = FuncionarBuilder.CriarDesenvolvedor(salario);
            var salarioEsperado = salario * 0.9;

            //Act
            var salarioCalculado = _calculadora.CalculaSalario(funcionario.Salario, new DezOuVintePorCento());

            //Assert
            Assert.Equal(salarioEsperado, salarioCalculado);
        }

        [Theory(DisplayName = "Cenário 02 - DEVs Com Salario Maior que R$ 3.000")]
        [InlineData(3500.0)]
        [InlineData(4000.0)]
        public void DeveCalcularSalarioParaDesenvolvedoresComSalarioAcimaDoLimite(double salario)
        {
            //Arrange
            var funcionario = FuncionarBuilder.CriarDesenvolvedor(salario);
            var salarioEsperado = salario * 0.8;

            //Act
            var salarioCalculado = _calculadora.CalculaSalario(funcionario.Salario, new DezOuVintePorCento());

            //Assert
            Assert.Equal(salarioEsperado, salarioCalculado);
        }

        [Theory(DisplayName = "Cenário 03 - DBAs Com Salario Menor que R$ 2.500")]
        [InlineData(500.0)]
        [InlineData(2000.0)]
        public void DeveCalcularSalarioParaDBAsComSalarioAbaixoDoLimite(double salario)
        {
            //Arrange
            var funcionario = FuncionarBuilder.CriarDBA(salario);
            var salarioEsperado = salario * 0.85;

            //Act
            var salarioCalculado = _calculadora.CalculaSalario(funcionario.Salario, new QuinzeOuVinteCincoPorCento());

            //Assert
            Assert.Equal(salarioEsperado, salarioCalculado);
        }

        [Theory(DisplayName = "Cenário 04 - DBAs Com Salario Maior que R$ 2.500")]
        [InlineData(2600.0)]
        [InlineData(4500.0)]
        public void DeveCalcularSalarioParaDBAsComSalarioAcimaDoLimite(double salario)
        {
            //Arrange
            var funcionario = FuncionarBuilder.CriarDBA(salario);
            var salarioEsperado = salario * 0.75;

            //Act
            var salarioCalculado = _calculadora.CalculaSalario(funcionario.Salario, new QuinzeOuVinteCincoPorCento());

            //Assert
            Assert.Equal(salarioEsperado, salarioCalculado);
        }

        [Theory(DisplayName = "Cenário 05 - TESTs Com Salario Menor que R$ 2.500")]
        [InlineData(500.0)]
        [InlineData(1000.0)]
        public void DeveCalcularSalarioParaTestadoresComSalarioAbaixoDoLimite(double salario)
        {
            //Arrange
            var funcionario = FuncionarBuilder.CriarTestador(salario);
            var salarioEsperado = salario * 0.85;

            //Act
            var salarioCalculado = _calculadora.CalculaSalario(funcionario.Salario, new QuinzeOuVinteCincoPorCento());

            //Assert
            Assert.Equal(salarioEsperado, salarioCalculado);
        }

        [Theory(DisplayName = "Cenário 06 - TESTs Com Salario Maior que R$ 2.500")]
        [InlineData(2600.0)]
        [InlineData(4500.0)]
        public void DeveCalcularSalarioParaTestadoresComSalarioAcimaDoLimite(double salario)
        {
            //Arrange
            var funcionario = FuncionarBuilder.CriarTestador(salario);
            var salarioEsperado = salario * 0.75;

            //Act
            var salarioCalculado = _calculadora.CalculaSalario(funcionario.Salario, new QuinzeOuVinteCincoPorCento());

            //Assert
            Assert.Equal(salarioEsperado, salarioCalculado);
        }
    }
}
