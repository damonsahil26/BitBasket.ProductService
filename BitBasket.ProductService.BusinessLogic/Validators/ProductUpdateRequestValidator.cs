using BitBasket.ProductService.BusinessLogic.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBasket.ProductService.BusinessLogic.Validators
{
    public class ProductUpdateRequestValidator : AbstractValidator<ProductUpdateRequest>
    {
        public ProductUpdateRequestValidator() {
        
            RuleFor(prop => prop.ProductId).NotEmpty().WithMessage("Product Id should not be empty!");
        }

    }
}
