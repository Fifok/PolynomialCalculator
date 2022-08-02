using PolynomialCalc.Core.Operations;

namespace PolynomialCalc.Console
{
    public static class OperationChooser
    {
        private static readonly IReadOnlyDictionary<char, IOperation> _operations = new Dictionary<char, IOperation>
        {
            { '+', new AddingOperation() }
        };

        public static IOperation ChooseOperation(char option)
        {
            return _operations[option] ?? throw new ArgumentOutOfRangeException(nameof(option),"This option is not avaiable for existing operations");
        }
    }
}