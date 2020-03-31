namespace Calculadora.Lib.Tests.Unit.Builders
{
    internal static class FuncionarBuilder
    {
        internal static Funcionario CriarDesenvolvedor(double salario) =>
            new Funcionario("Funcionario", salario, Cargo.Desenvolvedor);

        internal static Funcionario CriarDBA(double salario) =>
            new Funcionario("Funcionario", salario, Cargo.DBA);

        internal static Funcionario CriarTestador(double salario) =>
            new Funcionario("Funcionario", salario, Cargo.Testador);
    }
}
