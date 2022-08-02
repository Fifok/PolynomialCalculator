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

        polynomial.Monomials.Length.Should().Be(1);

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

        polynomial.Monomials.Length.Should().Be(1);

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
    public void Add_ShouldNotAddValueToAnyMonomial_WhenCoefficientIsZero()
    {
        var polynomial = new Polynomial();
        var existingMonomial = new Monomial(5, 1);

        polynomial.Add(existingMonomial);

        polynomial.Add(new Monomial(0, 1));

        polynomial.Monomials.Should().HaveCount(1);
        
        var monomial = polynomial.Monomials.Single();
        monomial.Exponent.Should().Be(1);
        monomial.Variable.Should().Be('x');
        monomial.Coefficient.Should().Be(5);
    }
    
    [Test]
    public void Add_ShouldNotAddMonomial_WhenCoefficientIsZero()
    {
        var polynomial = new Polynomial();

        polynomial.Add(new Monomial(0, 1));

        polynomial.Monomials.Should().BeEmpty();
    }
}