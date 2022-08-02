using PolynomialCalc.Core.Operations;

namespace PolynomialCalc.Core;

public interface IPolynomialCalculator
{
    void SetOperation(IOperation operation);
    Polynomial Execute(Polynomial left, Polynomial right);
}

public class PolynomialCalculator : IPolynomialCalculator
{
    private IOperation _operation;

    public void SetOperation(IOperation operation)
    {
        _operation = operation;
    }

    public Polynomial Execute(Polynomial left, Polynomial right)
    {
        return _operation.Execute(left, right);
    }
}