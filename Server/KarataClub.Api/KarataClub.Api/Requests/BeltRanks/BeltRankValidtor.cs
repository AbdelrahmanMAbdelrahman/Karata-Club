using FluentValidation;
using KarataClub.Infrastructure.Settings;

namespace KarataClub.Api.Requests.BeltRanks
{
    public class BeltRankValidtor:AbstractValidator<BeltRankReq>
    {
        public BeltRankValidtor()
        {
            RuleFor(c => c.Image)
                .Must(image => IsImageValid(image))
                .WithMessage("Provide a valid Image");
        }

        private bool IsImageValid(IFormFile image)
        {
            BinaryReader reader = new BinaryReader(image.OpenReadStream());
            byte[] bytes = reader.ReadBytes(2);
            string extn = BitConverter.ToString(bytes);
            return AppSettings.AllowedExtns.Contains(extn);
        }
    }
}
