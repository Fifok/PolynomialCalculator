namespace PolynomialCalc.Core;
public class Polynomial
{
    private List<Monomial> _monomials;
    public Monomial[] Monomials => _monomials.ToArray();

    public Polynomial()
    {
        _monomials = new List<Monomial>();
    }
    
    public Polynomial(List<Monomial> monomials)
    {
        _monomials = monomials;
    }

    public static Polynomial operator+(Polynomial left, Polynomial right)
    {
        return left.Add(right);
    }
    private Polynomial Add(Polynomial polynomial)
    {
        var result = new Polynomial();

        foreach (var monomial in _monomials)
        {
            result.Add(monomial);
        }

        foreach (var monomial in polynomial._monomials)
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
            AddToMonomial(monomial);
            return this;
        }

        AddToMonomial(monomial);
        return this;
    }

    private void AddToMonomial(Monomial monomial)
    {
         var existingMonomial = _monomials
            .SingleOrDefault(m => m.Variable == monomial.Variable && m.Exponent == monomial.Exponent);
        
        if(existingMonomial == null)
        {
            _monomials.Add(monomial.Clone());
            return;
        }

        var addingResult = existingMonomial.Add(monomial);

        if(addingResult.Coefficient == 0)
        {
            _monomials.Remove(addingResult);
        }
    }

    public Polynomial Clone()
    {
        var monomials = new List<Monomial>(_monomials.Count);

        foreach (var monomial in _monomials)
        {
            monomials.Add(monomial.Clone());
        }
        
        return new Polynomial(monomials);
    }
}
