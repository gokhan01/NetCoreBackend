using Castle.DynamicProxy;
using FluentValidation;
using NetCoreBackend.Core.CrossCuttingConcerns.Validation;
using NetCoreBackend.Core.Utilities.Interceptors;
using NetCoreBackend.Core.Utilities.Messages;
using System;
using System.Linq;

namespace NetCoreBackend.Core.Aspects.Validation
{
    public class ValidationAspect : MethodInterception
    {
        Type _validatorType;

        //Örnek => ProductValidator : AbstractValidator<Product>
        //FluentValidation'a ait AbstractValidator sınıfı IValidator interface'inden türemiştir
        public ValidationAspect(Type validatorType)
        {
            //Gelen tipin FluentValidation.IValidator interface'ine atanabilirlik kontrolü yapılır
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //Validator sınıfı için yeni örnek oluşturulur
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //Validator sınıfının türediği AbstractValidator'a generic olarak gönderilen tip ele alınır 
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //Metod argümanları alınır. Örnek => Add(Product product)
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            foreach (var item in entities)
            {
                ValidationTool.Validate(validator, item);
            }
        }
    }
}
