using PolynomialCalc.Core;
using PolynomialCalc.Core.Operations;

namespace PolynomialCalc.Applicatiob;

public interface IPolynomialServiceSetOperation
{
    IPolynomialServiceExecuteOperation SetOperation(IOperation operation);
}

public interface IPolynomialServiceExecuteOperation
{
    Polynomial ExecuteOperation(string leftPolynomialText, string rightPolynomialText);
}

public class PolynomialService : IPolynomialServiceSetOperation, IPolynomialServiceExecuteOperation
{
    private IPolynomialParser _parser;
    private IPolynomialCalculator _calculator;

    public PolynomialService(IPolynomialParser parser, IPolynomialCalculator calculator)
    {
        _parser = parser;
        _calculator = calculator;
    }

    public Polynomial ExecuteOperation(string leftPolynomialText, string rightPolynomialText)
    {
        var leftPolynomial = _parser.Parse(leftPolynomialText);
        var rightPolynomial = _parser.Parse(rightPolynomialText);

        return _calculator.Execute(leftPolynomial, rightPolynomial);
    }

    public IPolynomialServiceExecuteOperation SetOperation(IOperation operation)
    {
        _calculator.SetOperation(operation);
        return this;
    }
}