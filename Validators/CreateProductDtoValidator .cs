using FluentValidation;
using ProductManagementAPI.Application.DTOs;

namespace ProductManagementAPI.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required")
                .MinimumLength(3).WithMessage("Product name must be at least 3 characters")
                .MaximumLength(255).WithMessage("Product name cannot exceed 255 characters");
        }
    }
}