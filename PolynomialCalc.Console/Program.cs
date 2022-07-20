

using PolynomialCalc.Applicatiob;
using PolynomialCalc.Core;
using PolynomialCalc.Parsers;
using PolynomialCalc.Presenters;

Console.WriteLine("Welcome to Polynomial Calculator!");

Console.Write("Enter first polynomial (eg. 2x^3 + 5x^2 + 7y^2 - 3x - 5): ");
var firstPolynomialText = Console.ReadLine();
Console.Write("Enter second polynomial (eg. 4x^3 + 7x^2 - 5y^2 + 6x - 52): ");
var secondPolynomialText = Console.ReadLine();

var result = new PolynomialService(new PolynomialParser(), new PolynomialCalculator())
        .Add(firstPolynomialText, secondPolynomialText);
        
var presenter = new PolynomialPresenter();

Console.WriteLine("Start calculation.");
Console.WriteLine();

Console.Write($"Adding: ({firstPolynomialText}) + ({secondPolynomialText}) = ");
Console.WriteLine(presenter.RepresentAsString(result));