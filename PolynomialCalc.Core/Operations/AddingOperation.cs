namespace PolynomialCalc.Core.Operations
{
    public class AddingOperation : IOperation
    {
        public Polynomial Execute(Polynomial left, Polynomial right)
        {
            return left + right;
        }
    }
}