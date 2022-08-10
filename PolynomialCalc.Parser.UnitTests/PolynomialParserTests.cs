using FluentAssertions;
using PolynomialCalc.Core;
using PolynomialCalc.Parsers;

namespace PolynomialCalc.Parser.UnitTests;

public class PolynomialParserTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Parse_ShouldParse_PolynomialWithXVariable()
    {
        var parser = new PolynomialRegexParser();
        var textPolynomial = "5x^5 + 4x^3 - 5x^2 + 2x - 4"; 
        
        var result = parser.Parse(textPolynomial);

        var expectedPolynomial = new Polynomial()
            .Add(new Monomial(5, 5))
            .Add(new Monomial(4, 3))
            .Add(new Monomial(-5, 2))
            .Add(new Monomial(2, 1))
            .Add(new Monomial(-4, 0));

        result.Should().BeEquivalentTo(expectedPolynomial);
    }
    
    [Test]
    public void Parse_ShouldParse_PolynomialWithDifferentVariables()
    {
        var parser = new PolynomialRegexParser();
        var textPolynomial = "5x^5 + 4y^3 - 5z^2 + 2x - 4y^2 + 5z + 4"; 
        
        var result = parser.Parse(textPolynomial);

        var expectedPolynomial = new Polynomial()
            .Add(new Monomial(5, 5))
            .Add(new Monomial(4, 'y',3))
            .Add(new Monomial(-5, 'z',2))
            .Add(new Monomial(2, 1))
            .Add(new Monomial(-4, 'y',2))
            .Add(new Monomial(5, 'z',1))
            .Add(new Monomial(4,0));

        result.Should().BeEquivalentTo(expectedPolynomial);
    }
}