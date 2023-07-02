using FluentValidation;

namespace Flowers.Services.Dtos.CategorieDto
{
    public class CategoriePutDto
    {
        public string Name { get; set; }    
    }

    public class CategoriePutValidator:AbstractValidator<CategoriePutDto>
    {
        public CategoriePutValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty!").MaximumLength(20).WithMessage("Maximum length should be 20!");

        }
    }
}
