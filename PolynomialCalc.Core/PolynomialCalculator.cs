namespace PolynomialCalc.Core;

public interface IPolynomialCalculator
{
    Polynomial Add(Polynomial left, Polynomial right);
}

public class PolynomialCalculator : IPolynomialCalculator
{
    public Polynomial Add(Polynomial left, Polynomial right)
    {
        foreach (var monomial in right.Monomials)
        {
            left.Add(monomial);
        }

        return left;
    }
}