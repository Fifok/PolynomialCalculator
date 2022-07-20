using System.Text;
using PolynomialCalc.Core;

namespace PolynomialCalc.Presenters
{
    public class PolynomialPresenter : IPresenter<Polynomial>
    {
        public string RepresentAsString(Polynomial toPresent)
        {
            IEnumerable<(char Sign, Monomial Monomial)> parts = toPresent.Monomials.Select(monomial => (character: monomial.Coefficient > 0 ? '+' : '-', monomial));

            var sb = new StringBuilder();

            var firstPart = parts.First();
            sb.Append(firstPart.Sign == '+'
                ? MonomialToString(firstPart.Monomial)
                : PartToSignedMonomialString(firstPart));
            
            
            foreach (var part in parts.Skip(1))
            {
                sb.Append(PartToSignedMonomialString(part));
            }

            return sb.ToString();
        }

        private string MonomialToString(Monomial monomial)
        {
            return $"{Math.Abs(monomial.Coefficient)}{monomial.Variable}{ExponentToString(monomial.Exponent)}";
        }

        private string ExponentToString(double exponent)
        {
            return exponent > 1 ? $"^{exponent}" : string.Empty;
        }

        private string PartToSignedMonomialString((char Sign, Monomial Monomial) part)
        {
            return $" {part.Sign} {MonomialToString(part.Monomial)}";
        }
    }
}