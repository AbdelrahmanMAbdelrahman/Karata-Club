using Microsoft.Extensions.Caching.Hybrid;
namespace KarataClub.Application.Features.People.Instructors.Commands.CreateInstructors;

public sealed class CreateInstructorHandler
    (IAppDbContext context,ILogger<CreateInstructorHandler>logger,HybridCache hybridCache)
    : IRequestHandler<CreateInstructorCommand, Result<InstructorDto>>
{
    public async Task<Result<InstructorDto>> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
    {
        bool isExist = await context.People.AnyAsync(
         p =>
           p.Email == request.Email ||
           p.Phone == request.Phone, cancellationToken);
        if (isExist)
        {
            logger.LogError("Instructor Already Exist");
            return ApplicationErrors.InstructorAlreadyExist;
        }
        Result<Person> createPersonResult = Person.Create(request.Name, request.Phone, request.Email, request.Address);
        if (createPersonResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", createPersonResult.Errors));
            return createPersonResult.Errors;
        }
        var person = createPersonResult.Value;
        Result<Instructor> createInstructorResult = Instructor.Create(person.Id,request.Qualifications);
        if (createInstructorResult.IsFailure)
        {
            logger.LogError(string.Join(" - ", createInstructorResult.Errors));
            return createInstructorResult.Errors;
        }
        var instructor = createInstructorResult.Value;

        instructor.Person = person;
        await context.Instructors.AddAsync(instructor, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        await hybridCache.RemoveByTagAsync("Instructor");
        return instructor.ToDto();
    }
}
