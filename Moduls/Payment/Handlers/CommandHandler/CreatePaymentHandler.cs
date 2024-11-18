using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.Payment.Extensions.Mappers;
using WebAPI.Moduls.Payment.ViewModels;

namespace WebAPI.Moduls.Payment.Handlers.CommandHandler;

public sealed class CreatePaymentHandler(IUnitOfWork<Entities.Payment> unitOfWork) : IRequestHandler<PaymentCreateDto,BaseResult>
{
    public async Task<BaseResult> Handle(PaymentCreateDto request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<Entities.Payment> repository = unitOfWork.PaymentAddRepository;

        

        await repository.AddAsync(request.ToPayment());
        int res = await unitOfWork.Complete();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops...!!! Data not saved🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}