using FluentValidation.Results;

namespace Cargo.Application.Exceptions
{
    public class CustomValidationException : ApplicationException
    {
        public List<ValidationFailure> Errors { get; }

        public CustomValidationException(List<ValidationFailure> errors)
        {
            Errors = errors;
        }
    }
}
