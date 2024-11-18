using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.Payment.Extensions.Mappers;
using WebAPI.Moduls.Payment.ViewModels;

namespace WebAPI.Moduls.Payment.Handlers.CommandHandler;

public class DeletePaymentHandler(IUnitOfWork<Entities.Payment> unitOfWork) : IRequestHandler<PaymentDelete,BaseResult>
{
    public async Task<BaseResult> Handle(PaymentDelete request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<Entities.Payment> repository = unitOfWork.PaymentDeleteRepository;
        IGenericFindRepository<Entities.Payment> findRepository = unitOfWork.PaymentFindRepository;

        Entities.Payment? payment = await findRepository.GetByIdAsync(request.Id);
        if(payment is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));

        await repository.RemoveAsync(payment.ToDeleted());
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops! Data is not deleted🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}