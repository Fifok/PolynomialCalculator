using NUnit.Framework;
using FluentAssertions;
using System.Linq;

namespace PolynomialCalc.Core.UnitTest;

public class PolynomialTests
{
    [Test]
    public void Add_Should_AddMonomial_WhenNonMonomial()
    {
        var polynomial = new Polynomial();
        var expectedMonomial = new Monomial(6,2);

        polynomial.Add(expectedMonomial);

        polynomial.Monomials.Count.Should().Be(1);

        var actualMonomial = polynomial.Monomials.Single();
        actualMonomial.Coefficient.Should().Be(expectedMonomial.Coefficient);
        actualMonomial.Exponent.Should().Be(expectedMonomial.Exponent);
        actualMonomial.Variable.Should().Be('x');
    }

    [Test]
    public void Add_Should_AddMonomialToExistingMonomial()
    {
        var polynomial = new Polynomial();
        var existingMonomial = new Monomial(6,2);
        var addingMonomial = new Monomial(4,2);

        polynomial.Add(existingMonomial);
        polynomial.Add(addingMonomial);

        polynomial.Monomials.Count.Should().Be(1);

        var expectedMonomial = new Monomial(10,2);

        var actualMonomial = polynomial.Monomials.Single();
        actualMonomial.Coefficient.Should().Be(expectedMonomial.Coefficient);
        actualMonomial.Exponent.Should().Be(expectedMonomial.Exponent);
        actualMonomial.Variable.Should().Be('x');
    }

    [Test]
    [TestCase(6)]
    [TestCase(-9)]
    [TestCase(0)]
    public void Add_ShouldRemoveMonomial_WhenResultedCoefficientIsZero(int coefficient)
    {
        var polynomial = new Polynomial();
        var existingMonomial = new Monomial(coefficient,2);
        var addingMonomial = new Monomial(-coefficient,2);

        polynomial.Add(existingMonomial);
        polynomial.Add(addingMonomial);

        polynomial.Monomials.Should().BeEmpty();
    }

    [Test]
    public void Add_ShouldAddValueToConstantMonomial_Correctly()
    {
        var polynomial = new Polynomial();
        var existingMonomial = new Monomial(5, 0);
        var addingMonomial = new Monomial(6, 'y', 0);

        polynomial.Add(existingMonomial);
        polynomial.Add(addingMonomial);

        polynomial.Monomials.Should().HaveCount(1);
        
        var monomial = polynomial.Monomials.Single();
        monomial.Exponent.Should().Be(0);
        monomial.Variable.Should().Be(null);
        monomial.Coefficient.Should().Be(11);
    }

     [Test]
    public void Add_Should_AddTwoPolynomials_Correctly()
    {
        //(5x^5+5x^3+6x^2-2x+5) + (6x^4-3x^3+7x^2-6x+12) = 6x^4+2x^3+13x^2-8x+17
        
        var left = new Polynomial();
        left.Add(new Monomial(-5,5))
            .Add(new Monomial(5,3))
            .Add(new Monomial(6,2))
            .Add(new Monomial(-2,1))
            .Add(new Monomial(5,0));

        var right = new Polynomial();
        right.Add(new Monomial(-5,5))
             .Add(new Monomial(6,4))
             .Add(new Monomial(-3,3))
             .Add(new Monomial(7,2))
             .Add(new Monomial(2,1))
             .Add(new Monomial(12,0));

        left.Add(right);

        var expectedPolynomial = new Polynomial();
        expectedPolynomial
            .Add(new Monomial(-10,5))
            .Add(new Monomial(6,4))
            .Add(new Monomial(2,3))
            .Add(new Monomial(13,2))
            .Add(new Monomial(17,0));

        left.Monomials.Should().BeEquivalentTo(expectedPolynomial.Monomials);
    }
}