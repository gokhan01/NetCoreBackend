using FluentValidation;
using NetCoreBackend.Entities.Concrete;

namespace NetCoreBackend.BLL.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.ProductName).Length(2, 30);
            RuleFor(x => x.UnitPrice).NotEmpty();
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(1);
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(10).When(x => x.CategoryID == 1);
            RuleFor(x => x.ProductName).Must(StartWithA);//custom
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
