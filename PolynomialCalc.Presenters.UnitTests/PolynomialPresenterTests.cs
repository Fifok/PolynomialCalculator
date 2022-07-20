using FluentAssertions;
using PolynomialCalc.Core;

namespace PolynomialCalc.Presenters.UnitTests;

public class PolynomialPresenterTests
{
    [Test]
    public void RepresentAsString_ShouldReturn_CorrectString()
    {
        var presenter = new PolynomialPresenter();

        var polynomial = new Polynomial()
            .Add(new Monomial(4, 5))
            .Add(new Monomial(-6, 2))
            .Add(new Monomial(-5, 'z', 1))
            .Add(new Monomial(7, 0));

        var result = presenter.RepresentAsString(polynomial);

        var expectedString = "4x^5 - 6x^2 - 5z + 7";
        result.Should().Be(expectedString);
    }
}