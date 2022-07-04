namespace PolynomialCalc.Core;
public class Polynomial
{
    public List<Monomial> Monomials = new List<Monomial>();

    public void Add(Monomial monomial)
    {
        var existingMonomial = Monomials
            .SingleOrDefault(m => m.Variable == monomial.Variable && m.Exponent == monomial.Exponent);
        
        if(existingMonomial == null)
        {
            Monomials.Add(monomial);
            return;
        }

        existingMonomial.Coefficient += monomial.Coefficient;
    }
}
