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
}