
using FluentValidation;

namespace Flowers.Services.Dtos.CategorieDto
{
    public class CategoriePostDto
    {
        public string Name { get; set; }
    }

    public class CategoriePostValidator:AbstractValidator<CategoriePostDto>
    {
        public CategoriePostValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty!").MaximumLength(20).WithMessage("Maximum length should be 20!");
        }
    }
}
