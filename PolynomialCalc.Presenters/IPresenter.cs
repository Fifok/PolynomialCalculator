namespace PolynomialCalc.Presenters;

public interface IPresenter<T>
{
    string RepresentAsString(T toPresent);
}