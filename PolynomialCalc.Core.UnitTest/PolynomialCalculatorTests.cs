using NUnit.Framework;
using FluentAssertions;

namespace PolynomialCalc.Core.UnitTest;

public class PolynomialCalculatorTests
{
    [Test]
    public void Add_Should_AddTwoPolynomials_Correctly()
    {
        //(5x^5+5x^3+6x^2-2x+5) + (6x^4-3x^3+7x^2-6x+12) = 6x^4+2x^3+13x^2-8x+17
        
        var left = new Polynomial()
            .Add(new Monomial(-5,5))
            .Add(new Monomial(5,3))
            .Add(new Monomial(6,2))
            .Add(new Monomial(-2,1))
            .Add(new Monomial(5,0));

        var right = new Polynomial()
            .Add(new Monomial(-5,5))
            .Add(new Monomial(6,4))
            .Add(new Monomial(-3,3))
            .Add(new Monomial(7,2))
            .Add(new Monomial(2,1))
            .Add(new Monomial(12,0));

        var calculator = new PolynomialCalculator();
        var result = calculator.Add(left, right);
        
        var expectedPolynomial = new Polynomial()
            .Add(new Monomial(-10,5))
            .Add(new Monomial(6,4))
            .Add(new Monomial(2,3))
            .Add(new Monomial(13,2))
            .Add(new Monomial(17,0));

        result.Monomials.Should().BeEquivalentTo(expectedPolynomial.Monomials);
    }

}