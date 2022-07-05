namespace PolynomialCalc.Core;
public class Polynomial
{
    public List<Monomial> Monomials = new List<Monomial>();

    public void Add(Monomial monomial)
    {
        if(monomial.Coefficient == 0)
        {
            return;
        }

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
