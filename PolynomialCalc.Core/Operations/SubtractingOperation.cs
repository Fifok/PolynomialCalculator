namespace PolynomialCalc.Core.Operations
{
    public class SubtractingOperation : IOperation
    {
        public Polynomial Execute(Polynomial left, Polynomial right)
        {
            return left - right;
        }
    }
}