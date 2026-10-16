using KarataClub.Application.Features.Subscriptions.Dtos;
using KarataClub.Domain.Subscriptions;

namespace KarataClub.Application.Features.Subscriptions.Commands.CreateSubscriptions;

//public class CreateSubscriptionHandler(
//    IAppDbContext context, ILogger<CreateSubscriptionHandler> logger
//    ) : IRequestHandler<CreateSubscriptionCommand, Result<SubscriptionDto>>
//{
//    async Task<Result<SubscriptionDto>> IRequestHandler<CreateSubscriptionCommand, 
//        Result<SubscriptionDto>>.Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
//    {
//       bool exist = await context.Members.AnyAsync(m => m.Id == request.MemberId && m.Active);
//        if (!exist)
//        {
//            logger.LogError("No Member found for this id : {memberId}",request.MemberId);
//            return ApplicationErrors.MemberNotFound(request.MemberId);
//        }
//        Result<Payment> createPaymentResult = Payment.Create(request.MemberId,
//            DateTime.UtcNow,request.Fees,request.Notes??"");
//        if (createPaymentResult.IsFailure)
//        {
//            logger.LogError(string.Join(" - ",createPaymentResult.Errors));
//            return createPaymentResult.Errors;
//        }
//        DateTime now=DateTime.UtcNow;

//        DateTime defaultEndDate = new DateTime(now.Year,now.Month,DateTime.DaysInMonth(now.Year,now.Month));
//        Result<Subscription> createSubResult = Subscription.Create(createPaymentResult.Value.Id,
//            request.MemberId,now,defaultEndDate,request.Fees);
//    }
//}
