using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.Payment.Extensions.Mappers;
using WebAPI.Moduls.Payment.ViewModels;

namespace WebAPI.Moduls.Payment.Handlers.CommandHandler;

public class UpdatePaymentHandler(IUnitOfWork<Entities.Payment> unitOfWork) : IRequestHandler<PaymentUpdateInfo,BaseResult>
{
    public async Task<BaseResult> Handle(PaymentUpdateInfo request, CancellationToken cancellationToken)
    {
        IGenericUpdateRepository<Entities.Payment> repository = unitOfWork.PaymentUpdateRepository;
        IGenericFindRepository<Entities.Payment> findRepository = unitOfWork.PaymentFindRepository;
        
        Entities.Payment? payment = await findRepository.GetByIdAsync(request.Id);
        if(payment is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));;

        
        await repository.UpdateAsync(payment.ToUpdate(request));
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("oops...!!! Data is not updated🤷‍♂️🤷‍♂️"))
             : BaseResult.Success();
    }
}