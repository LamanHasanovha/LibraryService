using Core.CCC.Exception;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new BusinessException(string.Join("\n", result.Errors.Select(e=>e.ErrorMessage)));
            }
        }
    }
}
