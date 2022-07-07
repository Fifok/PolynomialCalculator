namespace PolynomialCalc.Core;

public class Monomial
{
    public int Coefficient { get; set; }
    public char? Variable { get; set; }
    public int Exponent { get; set; }

    public Monomial(int coefficient, int exponent)
    {
        Coefficient = coefficient;
        Variable = 'x';
        Exponent = exponent;
    }

    public Monomial(int coefficient, char? variable, int exponent)
    {
        Coefficient = coefficient;
        Variable = variable;
        Exponent = exponent;
    }

    public Monomial Add(Monomial monomial)
    {
        if(Exponent != monomial.Exponent)
            throw new ArgumentException("Exponents must be equal values");

        if(Variable != monomial.Variable)
            throw new ArgumentException("Variable must be equal characters");

        Coefficient += monomial.Coefficient;
        return this;
    }

    public Monomial Clone()
    {
        return new Monomial(Coefficient, Variable, Exponent);
    }
}