using BitBasket.ProductService.BusinessLogic.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBasket.ProductService.BusinessLogic.Validators
{
    public class ProductAddRequestValidator : AbstractValidator<ProductAddRequest>
    {
        public ProductAddRequestValidator() {
            RuleFor(temp => temp.ProductName)
                .NotEmpty()
                .WithMessage("ProductName Should not be empty");

            RuleFor(temp => temp.UnitPrice)
                .NotEmpty().WithMessage("Unit Price should not be empty")
                .InclusiveBetween(1, 10000).WithMessage("Unit price should be in range 1 to 10000");
        }
    }
}
