using FluentAssertions;
using PolynomialCalc.Applicatiob;
using PolynomialCalc.Core;
using PolynomialCalc.Core.Operations;
using PolynomialCalc.Parsers;

namespace PolynomialCalc.Application.IntegrationTests;

public class PolynomialServiceTests
{
    [Test]
    public void ExecuteOperation_WorksCorrectly_ForAdding()
    {
        var service = new PolynomialService(new PolynomialParser(), new PolynomialCalculator());
        
        var leftPolynomial = "2x^3 + 5x^2 + 7y^2 - 3x - 5";
        var rightPolynomial = "4x^3 + 7x^2 - 5y^2 + 6x - 52";

        service.SetOperation(new AddingOperation());
        var result = service.ExecuteOperation(leftPolynomial, rightPolynomial);

        var expected = new Polynomial()
            .Add(new Monomial(6, 'x', 3))
            .Add(new Monomial(12, 'x', 2))
            .Add(new Monomial(2, 'y', 2))
            .Add(new Monomial(3, 'x', 1))
            .Add(new Monomial(-57, 0));
        result.Should().BeEquivalentTo(expected);

    }
}