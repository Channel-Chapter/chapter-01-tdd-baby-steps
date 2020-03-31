namespace Calculadora.Lib
{
    public class QuinzeOuVinteCincoPorCento : RegraDeCalculo
    {
        protected override double PorcentagemBase => 0.85;
        protected override double PorcentagemAcimaDoLimite => 0.75;
        protected override int Limite => 2500;
    }
}