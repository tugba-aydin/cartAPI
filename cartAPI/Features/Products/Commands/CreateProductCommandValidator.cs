using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cartAPI.Features.Products.Commands
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(product => product.Id).GreaterThan(0);
            RuleFor(product => product.Name).NotNull();
            RuleFor(product => product.Photo).MinimumLength(10);
            RuleFor(product => product.Price).GreaterThan(0);
            RuleFor(product => product.Stock).GreaterThan(0);
        }
    }
}
