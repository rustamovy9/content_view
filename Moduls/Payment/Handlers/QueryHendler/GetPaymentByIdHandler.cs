using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.UOW;
using WebAPI.Moduls.Payment.Extensions.Mappers;
using WebAPI.Moduls.Payment.ViewModels;

namespace WebAPI.Moduls.Payment.Handlers.QueryHendler;

public class GetPaymentByIdHandler(IUnitOfWork<Entities.Payment> unitOfWork) : IRequestHandler<GetPaymentByIdVmRequest,Result<PaymentReadInfo>>
{
    public async Task<Result<PaymentReadInfo>> Handle(GetPaymentByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Entities.Payment>? repository = unitOfWork.PaymentFindRepository;
        Entities.Payment? payment = await repository.GetByIdAsync(request.Id);
        return payment is null
            ? Result<PaymentReadInfo>.Failure(Error.NotFound())
            : Result<PaymentReadInfo>.Success(payment.ToReadInfo());
    }
}