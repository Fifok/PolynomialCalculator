

using PolynomialCalc.Applicatiob;
using PolynomialCalc.Core;
using PolynomialCalc.Parsers;

Console.WriteLine("Welcome to Polynomial Calculator!");

Console.WriteLine("Enter first polynomial (eg. 2x^3 + 5x^2 - 3x - 5):\n");
var firstPolynomialText = Console.ReadLine();
Console.WriteLine("Enter second polynomial (eg. 2x^3 + 5x^2 - 3x - 5):\n");
var secondPolynomialText = Console.ReadLine();

var result = new PolynomialService(new PolynomialParser(), new PolynomialCalculator())
        .Add(firstPolynomialText, secondPolynomialText);

foreach (var mono in result.Monomials)
{
        Console.WriteLine($"{mono.Coefficient}{mono.Variable}^{mono.Exponent}");
}