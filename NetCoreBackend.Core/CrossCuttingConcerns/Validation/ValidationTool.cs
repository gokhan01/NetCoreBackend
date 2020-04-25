using FluentValidation;

namespace NetCoreBackend.Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        //Tip bağımsız(entity,dto,vs.) validation uygulayabilmek için object kullanıldı
        public static void Validate(IValidator validator, object entity)
        {
            var validationResult = validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
