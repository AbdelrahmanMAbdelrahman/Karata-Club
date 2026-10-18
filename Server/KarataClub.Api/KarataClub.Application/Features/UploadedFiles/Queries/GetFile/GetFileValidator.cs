namespace KarataClub.Application.Features.UploadedFiles.Queries.GetFile;

public sealed class GetFileValidator:AbstractValidator<GetFileQuery>
{
    public GetFileValidator()
    {
        RuleFor(f=>f.FileId).Must(id=>id!=Guid.Empty)
            .WithMessage("Provide a valid '{PropertyName}'");
    }
}
