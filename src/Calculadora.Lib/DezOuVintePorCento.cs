namespace Calculadora.Lib
{
    public class DezOuVintePorCento : RegraDeCalculo
    {
        protected override double PorcentagemBase => 0.9;
        protected override double PorcentagemAcimaDoLimite => 0.8;
        protected override int Limite => 3000;
    }
}
