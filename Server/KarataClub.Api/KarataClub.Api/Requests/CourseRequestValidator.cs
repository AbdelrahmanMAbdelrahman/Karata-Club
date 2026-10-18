using FluentValidation;
using KarataClub.Infrastructure.Settings;
using QuestPDF.Infrastructure;

namespace KarataClub.Api.Requests
{
    public sealed class CourseRequestValidator:AbstractValidator<CourseReq>
    {
        public CourseRequestValidator()
        {
            RuleFor(c => c.Image)
                .Must(image => IsImageValid(image))
                .WithMessage("Provide a valid Image");
        }

        private bool IsImageValid(IFormFile image)
        {
            BinaryReader reader = new BinaryReader(image.OpenReadStream());
            byte[] bytes = reader.ReadBytes(2);
            string extn=BitConverter.ToString(bytes);
            return AppSettings.AllowedExtns.Contains(extn);
        }
    }
}
