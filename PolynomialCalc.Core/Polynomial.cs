namespace PolynomialCalc.Core;
public class Polynomial
{
    public List<Monomial> Monomials { get; } = new List<Monomial>();
    private Monomial? Constant;

    public static Polynomial operator+(Polynomial left, Polynomial right)
    {
        return left.Add(right);
    }
    public Polynomial Add(Polynomial polynomial)
    {
        var result = new Polynomial();

        foreach (var monomial in Monomials)
        {
            result.Add(monomial);
        }

        foreach (var monomial in polynomial.Monomials)
        {
            result.Add(monomial);
        }

        return result;
    }
    
    public Polynomial Add(Monomial monomial)
    {
        if(monomial.Coefficient == 0)
        {
            return this;
        }

        if(monomial.Exponent == 0)
        {
            monomial.Variable = null;
            AddToConstant(monomial);
            return this;
        }

        AddToMonomial(monomial);
        return this;
    }

    private void AddToConstant(Monomial monomial)
    {
        var existingMonomial = Monomials
            .SingleOrDefault(m => m.Exponent == monomial.Exponent);
        
        if(existingMonomial == null)
        {
            Monomials.Add(monomial.Clone());
            Constant = monomial;
            return;
        }

        var addingResult = existingMonomial.Add(monomial);

        if(addingResult.Coefficient == 0)
        {
            Monomials.Remove(addingResult);
            Constant = null;
        }
    }

    private void AddToMonomial(Monomial monomial)
    {
         var existingMonomial = Monomials
            .SingleOrDefault(m => m.Variable == monomial.Variable && m.Exponent == monomial.Exponent);
        
        if(existingMonomial == null)
        {
            Monomials.Add(monomial.Clone());
            return;
        }

        var addingResult = existingMonomial.Add(monomial);

        if(addingResult.Coefficient == 0)
        {
            Monomials.Remove(addingResult);
        }
    }
}
