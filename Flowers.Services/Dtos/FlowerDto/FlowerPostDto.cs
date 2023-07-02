using FluentValidation;
using Microsoft.AspNetCore.Http;


namespace Flowers.Services.Dtos.FlowerDto
{
    public class FlowerPostDto
    {

        public int CategorieId { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public string Desc { get; set; }

        public IFormFile PosterImageFile { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
    }

    public class FlowerPostDtoValidator : AbstractValidator<FlowerPostDto>
    {
        public FlowerPostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20).MinimumLength(2);
            RuleFor(x => x.SalePrice).GreaterThanOrEqualTo(x => x.CostPrice);
            RuleFor(x => x.CostPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.PosterImageFile).NotNull();

            RuleFor(x => x).Custom((x, context) =>
            {
                
                if (x.PosterImageFile.Length > 2097152)
                    context.AddFailure(nameof(x.PosterImageFile), "ImageFile must be less or equal than 2MB");

                if (x.PosterImageFile.ContentType != "image/jpeg" && x.PosterImageFile.ContentType != "image/png")
                    context.AddFailure(nameof(x.PosterImageFile), "ImageFile must be image/jpeg or image/png");


                foreach (var img in x.ImageFiles)
                {
                    if (img.Length > 2097152)
                        context.AddFailure(nameof(img), "ImageFile must be less or equal than 2MB");

                    if (img.ContentType != "image/jpeg" && img.ContentType != "image/png")
                        context.AddFailure(nameof(img), "ImageFile must be image/jpeg or image/png");
                }
            });

        }
    }

}
