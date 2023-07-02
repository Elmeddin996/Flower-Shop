using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Services.Dtos.SliderDto
{
    public class SliderPutDto
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public IFormFile ImageFile { get; set; }
    }

    public class SliderPutDtoValidator : AbstractValidator<SliderPutDto>
    {
        public SliderPutDtoValidator()
        {
            RuleFor(x => x.Order).NotNull();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50).MinimumLength(2);
            RuleFor(x => x.Desc).NotEmpty().MaximumLength(100).MinimumLength(2);

            RuleFor(x => x).Custom((x, context) =>
            {

                if (x.ImageFile.Length > 2097152)
                    context.AddFailure(nameof(x.ImageFile), "ImageFile must be less or equal than 2MB");

                if (x.ImageFile.ContentType != "image/jpeg" && x.ImageFile.ContentType != "image/png")
                    context.AddFailure(nameof(x.ImageFile), "ImageFile must be image/jpeg or image/png");

            });

        }
    }
}
