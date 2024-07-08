using FluentValidation.Results;

namespace Activos.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException() : base("VALIDATION_ERROR")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

        }
    }
}
