using PolynomialCalc.Core;

namespace PolynomialCalc.Applicatiob;

public interface IPolynomialParser
{
    Polynomial Parse(string text);
}