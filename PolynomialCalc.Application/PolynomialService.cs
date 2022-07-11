using PolynomialCalc.Core;

namespace PolynomialCalc.Applicatiob;

public class PolynomialService
{
    private IPolynomialParser _parser;
    private IPolynomialCalculator _calculator;

    public PolynomialService(IPolynomialParser parser, IPolynomialCalculator calculator)
    {
        _parser = parser;
        _calculator = calculator;
    }

    public Polynomial Add(string leftPolynomialText, string rightPolynomialText)
    {
        var leftPolynomial = _parser.Parse(leftPolynomialText);
        var rightPolynomial = _parser.Parse(rightPolynomialText);

        return _calculator.Add(leftPolynomial, rightPolynomial);
    }
}