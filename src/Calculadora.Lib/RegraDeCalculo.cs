namespace Calculadora.Lib
{
    public abstract class RegraDeCalculo : IRegraDeCalculo
    {
        public double Calcula(double salario)
        {
            if (salario > Limite)
            {
                return salario * PorcentagemAcimaDoLimite;
            }
            return salario * PorcentagemBase;
        }

        protected abstract int Limite { get; }
        protected abstract double PorcentagemAcimaDoLimite { get; }
        protected abstract double PorcentagemBase { get; }
    }
}
