namespace PolynomialCalc.Core.Operations
{
    public interface IOperation
    {
        Polynomial Execute(Polynomial left, Polynomial right);
    }
}