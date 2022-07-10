using System.Text.RegularExpressions;
using PolynomialCalc.Core;

namespace PolynomialCalc.Parsers;

public class PolynomialParser : IPolynomialParser
{
    private static Regex _polynomialRegex = new(@"(?:(?<coefficient>-?[1-9]*)(?:x\^?(?<exponent>[1-9]?)))|(?<constant>-?[1-9]+)");
    
    public Polynomial Parse(string text)
    {

        var polynomial = new Polynomial();
        var replace = Regex.Replace(text, @"\s", string.Empty);
        var matches = _polynomialRegex.Matches(replace);
        
        foreach (Match match in matches)
        {
            var coefficientString = match.Groups["coefficient"].Value;
            if (!string.IsNullOrWhiteSpace(coefficientString))
            {
                var coefficient = int.Parse(coefficientString);
        
                var exponentString = match.Groups["exponent"].Value;
                var exponent = !string.IsNullOrWhiteSpace(exponentString) ?  int.Parse(exponentString) : 1;
                var monomial = new Monomial(coefficient, exponent);
        
                polynomial.Add(monomial);
            }

            var constantString = match.Groups["constant"].Value;
            if (!string.IsNullOrWhiteSpace(constantString))
            {
                var monomial = new Monomial(int.Parse(constantString), 0);
                polynomial.Add(monomial);
            }
        }

        return polynomial;
    }
}