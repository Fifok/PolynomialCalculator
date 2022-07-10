using PolynomialCalc.Core;

namespace PolynomialCalc.Parsers;

public interface IPolynomialParser
{
    Polynomial Parse(string text);
}