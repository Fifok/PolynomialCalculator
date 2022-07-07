namespace PolynomialCalc.Core;

public interface IPolynomialCalculator
{
    Polynomial Add(Polynomial left, Polynomial right);
}

public class PolynomialCalculator : IPolynomialCalculator
{
    public Polynomial Add(Polynomial left, Polynomial right)
    {
        var result = new Polynomial();

        foreach (var monomial in left.Monomials)
        {
            result.Add(monomial);
        }

        foreach (var monomial in right.Monomials)
        {
            result.Add(monomial);
        }

        return result;
    }
}