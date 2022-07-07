namespace PolynomialCalc.Core;
public class Polynomial
{
    public List<Monomial> Monomials = new List<Monomial>();
    private Monomial? Constant;

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
            Monomials.Add(monomial);
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
            Monomials.Add(monomial);
            return;
        }

        var addingResult = existingMonomial.Add(monomial);

        if(addingResult.Coefficient == 0)
        {
            Monomials.Remove(addingResult);
        }
    }
}
