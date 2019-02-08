namespace CalculatorLib.Interfaces
{
    public interface IInputValidator
    {
        bool IsInputValid(string userInput);
        string ErrorMessage { get; }
    }
}
