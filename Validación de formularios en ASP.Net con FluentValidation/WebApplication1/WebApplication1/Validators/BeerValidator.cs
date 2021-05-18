using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Validators
{
    public class BeerValidator : AbstractValidator<Beer>
    {
        public BeerValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("No puede estar vacio");
            RuleFor(x => x.Name).MaximumLength(10).WithMessage("No puede superar los 10 caracteres");
            RuleFor(x => x.Brand).NotNull().WithMessage("No puede estar vacio");
            RuleFor(x => x.Brand).MaximumLength(10).WithMessage("No puede superar los 10 caracteres");
        }
    }
}
