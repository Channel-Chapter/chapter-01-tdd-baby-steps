namespace Calculadora.Lib
{
    public class CalculadoraDeSalario
    {
        public double CalculaSalario(double salario, IRegraDeCalculo regraDeCalculo) =>
             regraDeCalculo.Calcula(salario);
    }
}
