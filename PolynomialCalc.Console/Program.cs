

using PolynomialCalc.Parsers;

var original = "-2x^3 + 4x^2 + 2x - 6";

var parser = new PolynomialParser();

var polynomial = parser.Parse(original);

Console.WriteLine("=========ORIGINAL=========");
Console.WriteLine(original);
Console.WriteLine("=========ORIGINAL=========");

foreach (var term in polynomial.Monomials)
{
    Console.WriteLine($"{term.Coefficient}x^{term.Exponent}");
}