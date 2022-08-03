using NUnit.Framework;
using FluentAssertions;
using System;

namespace PolynomialCalc.Core.UnitTest;

public class MonomialTests
{
    [Test]
    [TestCase(5,9,6,14)]
    [TestCase(-5,-9,2,-14)]
    [TestCase(-5,9,7,4)]
    [TestCase(-5,5,1,0)]
    public void Add_ShouldAddCoefficient_Correctly(
        int testedCoefficient, int addingCoeffcient,
        int exponent, int expectedResult)
    {
        var testedMonomial = new Monomial(testedCoefficient, exponent);
        var addingMonomial = new Monomial(addingCoeffcient, exponent);

        var result = testedMonomial.Add(addingMonomial);

        result.Coefficient.Should().Be(expectedResult);
        result.Exponent.Should().Be(exponent);
        result.Variable.Should().Be('x');
    }

    [Test]
    public void Add_ShouldThrowArgumentException_WhenExponentAreDifferent()
    {
        var testedMonomial = new Monomial(6, 3);
        var addingMonomial = new Monomial(9, 5);

        var action = () => testedMonomial.Add(addingMonomial);

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Exponents must be equal values");
    }

    [Test]
    public void Add_ShouldThrowArgumentException_WhenVariableAreDifferent()
    {
        var testedMonomial = new Monomial(6, 'a', 5);
        var addingMonomial = new Monomial(9, 'b', 5);

        var action = () => testedMonomial.Add(addingMonomial);

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Variable must be equal characters");
    }

}