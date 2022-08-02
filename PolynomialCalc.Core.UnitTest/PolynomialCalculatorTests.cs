using NUnit.Framework;
using FluentAssertions;
using PolynomialCalc.Core.Operations;

namespace PolynomialCalc.Core.UnitTest;

public class PolynomialCalculatorTests
{
    [Test]
    public void Add_Should_AddTwoPolynomials_Correctly()
    {
        //(5x^5+5x^3+6x^2-2x+5) + (6x^4-3x^3+7x^2-6x+12) = 6x^4+2x^3+13x^2-8x+17

        var left = PrepareLeftPolynomial();
        var right = PrepareRightPolynomial();

        var calculator = new PolynomialCalculator();
        calculator.SetOperation(new AddingOperation());
        var result = calculator.Execute(left, right);
        
        CheckAddedPolynomialsConstancy(left, right);
        CheckExpectedPolymonialAddResult(result);
    }

    private static void CheckExpectedPolymonialAddResult(Polynomial result)
    {
        var expectedPolynomial = PrepareExpectedPolynomialAddResult();
        result.Monomials.Should().BeEquivalentTo(expectedPolynomial.Monomials);
    }

    private void CheckAddedPolynomialsConstancy(Polynomial left, Polynomial right)
    {
        left.Should().BeEquivalentTo(PrepareLeftPolynomial());
        right.Should().BeEquivalentTo(PrepareRightPolynomial());
    }

    private static Polynomial PrepareExpectedPolynomialAddResult()
    {
        return new Polynomial()
            .Add(new Monomial(-10, 5))
            .Add(new Monomial(6, 4))
            .Add(new Monomial(2, 3))
            .Add(new Monomial(13, 2))
            .Add(new Monomial(17, 0));
    }

    private static Polynomial PrepareRightPolynomial()
    {
        return new Polynomial()
            .Add(new Monomial(-5, 5))
            .Add(new Monomial(6, 4))
            .Add(new Monomial(-3, 3))
            .Add(new Monomial(7, 2))
            .Add(new Monomial(2, 1))
            .Add(new Monomial(12, 0));
    }

    private Polynomial PrepareLeftPolynomial()
    {
        return new Polynomial()
            .Add(new Monomial(-5,5))
            .Add(new Monomial(5,3))
            .Add(new Monomial(6,2))
            .Add(new Monomial(-2,1))
            .Add(new Monomial(5,0));
    }

}