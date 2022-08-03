using NUnit.Framework;
using FluentAssertions;
using PolynomialCalc.Core.Operations;

namespace PolynomialCalc.Core.UnitTest;

public class PolynomialCalculatorTests
{
    [Test]
    public void Add_Should_AddTwoPolynomials_Correctly()
    {
        var left = PrepareLeftPolynomial();
        var right = PrepareRightPolynomial();

        var calculator = new PolynomialCalculator();
        calculator.SetOperation(new AddingOperation());
        var result = calculator.Execute(left, right);
        
        CheckPolynomialsConstancy(left, right);
        CheckExpectedPolynomialResult(result, PrepareExpectedPolynomialAddResult());
    }
    
    [Test]
    public void Subtract_Should_SubtractTwoPolynomials_Correctly()
    {
        var left = PrepareLeftPolynomial();
        var right = PrepareRightPolynomial();

        var calculator = new PolynomialCalculator();
        calculator.SetOperation(new SubtractingOperation());
        var result = calculator.Execute(left, right);
        
        CheckPolynomialsConstancy(left, right);
        CheckExpectedPolynomialResult(result, PrepareExpectedPolynomialSubtractResult());
    }

    private static void CheckExpectedPolynomialResult(Polynomial result, Polynomial expected)
    {
        result.Monomials.Should().BeEquivalentTo(expected.Monomials);
    }

    private void CheckPolynomialsConstancy(Polynomial left, Polynomial right)
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
    
    private static Polynomial PrepareExpectedPolynomialSubtractResult()
    {
        return new Polynomial()
            .Add(new Monomial(-6, 4))
            .Add(new Monomial(8, 3))
            .Add(new Monomial(-1, 2))
            .Add(new Monomial(-4, 1))
            .Add(new Monomial(-7, 0));
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

}