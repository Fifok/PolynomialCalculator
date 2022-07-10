

using System.Text.RegularExpressions;

var regex = new Regex(@"(?:(?<coefficient>-?[1-9]*)(?:x\^?(?<exponent>[1-9]?)))|(?<constant>-?[1-9]+)");

var original = "-2x^3 + 4x^2 + 2x - 6";
var replace = Regex.Replace(original, @"\s", string.Empty);
Console.WriteLine(replace);
var matches = regex.Matches(replace);

var terms = new List<Term>();
var constants = new List<int>();

foreach (Match match in matches)
{
    var coefficientString = match.Groups["coefficient"].Value;
    if (!string.IsNullOrWhiteSpace(coefficientString))
    {
        var term = new Term();
        term.Coefficient = int.Parse(coefficientString);
        
        var exponentString = match.Groups["exponent"].Value;
        term.Exponent = !string.IsNullOrWhiteSpace(exponentString) ?  int.Parse(exponentString) : 1;
        
        terms.Add(term);
    }

    var constantString = match.Groups["constant"].Value;
    if (!string.IsNullOrWhiteSpace(constantString))
    {
        constants.Add(int.Parse(constantString));
    }
}

var polynomial = new Polynomial
{
    Terms = terms.ToArray(),
    Constants = constants.ToArray()
};

Console.WriteLine("=========ORIGINAL=========");
Console.WriteLine(original);
Console.WriteLine("=========ORIGINAL=========");

foreach (var term in polynomial.Terms)
{
    Console.WriteLine($"{term.Coefficient}x^{term.Exponent}");
}

foreach (var constant in polynomial.Constants)
{
    Console.WriteLine(constant);
}

public class Polynomial
{
    public Term[] Terms { get; set; }
    public int[] Constants { get; set; }
}

public class Term
{
    public int Coefficient { get; set; }
    public int Exponent { get; set; }
}