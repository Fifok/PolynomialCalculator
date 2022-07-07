using NUnit.Framework;
using FluentAssertions;

namespace PolynomialCalc.Core.UnitTest;

public class PolynomialCalculatorTests
{
    [Test]
    public void Add_Should_AddTwoPolynomials_Correctly()
    {
        //(5x^5+5x^3+6x^2-2x+5) + (6x^4-3x^3+7x^2-6x+12) = 6x^4+2x^3+13x^2-8x+17
        
        var left = new Polynomial();
        left.Add(new Monomial(-5,5));
        left.Add(new Monomial(5,3));
        left.Add(new Monomial(6,2));
        left.Add(new Monomial(-2,1));
        left.Add(new Monomial(5,0));

        var right = new Polynomial();
        right.Add(new Monomial(-5,5));
        right.Add(new Monomial(6,4));
        right.Add(new Monomial(-3,3));
        right.Add(new Monomial(7,2));
        right.Add(new Monomial(2,1));
        right.Add(new Monomial(12,0));

        var calculator = new PolynomialCalculator();
        var result = calculator.Add(left, right);
        
        var expectedPolynomial = new Polynomial();
        expectedPolynomial.Add(new Monomial(-10,5));
        expectedPolynomial.Add(new Monomial(6,4));
        expectedPolynomial.Add(new Monomial(2,3));
        expectedPolynomial.Add(new Monomial(13,2));
        expectedPolynomial.Add(new Monomial(17,0));

        result.Monomials.Should().BeEquivalentTo(expectedPolynomial.Monomials);
    }

}