namespace Cargo.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public object Value { get; }
    public string Key { get; }
    public string ErrorMessage { get; }

    public NotFoundException(object value) : base(value.ToString())
    {
        Value = value;
    }
    public NotFoundException(string key, string errorMessage) : base(errorMessage)
    {
        Key = key;
        ErrorMessage = errorMessage;
    }
    public NotFoundException() { }
}
