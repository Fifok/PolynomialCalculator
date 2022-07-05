using NUnit.Framework;
using FluentAssertions;

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

}