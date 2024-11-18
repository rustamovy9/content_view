using System.Linq.Expressions;
using MediatR;
using WebAPI.Common.Extensions.PatternResultExtensions;
using WebAPI.Common.Repositories.BaseRepository;
using WebAPI.Common.Responses;
using WebAPI.Common.UOW;
using WebAPI.Moduls.Payment.Extensions.Mappers;
using WebAPI.Moduls.Payment.ViewModels;

namespace WebAPI.Moduls.Payment.Handlers.QueryHendler;

public sealed class GetPaymentsHandler(IUnitOfWork<Entities.Payment> unitOfWork) : IRequestHandler<GetPaymentVmRequest, Result<PagedResponse<IEnumerable<PaymentReadInfo>>>>
{

    public async Task<Result<PagedResponse<IEnumerable<PaymentReadInfo>>>> Handle(GetPaymentVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Entities.Payment> repository = unitOfWork.PaymentFindRepository;

        Expression<Func<Entities.Payment, bool>> filterExpression = p =>
            (request.Filter.MinAmount == null || p.Amount >= request.Filter.MinAmount ) &&
            (request.Filter.MaxAmount == null || p.Amount <= request.Filter.MaxAmount );

        IEnumerable<Entities.Payment> query = (await repository
            .FindAsync(filterExpression)).ToList(); 
        
        int totalRecords =  query.Count();
        
        IEnumerable<PaymentReadInfo> result =  query
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize)
            .Select(x => x.ToReadInfo()).ToList();
        

        PagedResponse<IEnumerable<PaymentReadInfo>> response = PagedResponse<IEnumerable<PaymentReadInfo>>.Create(
            request.Filter.PageNumber, 
            request.Filter.PageSize, 
            totalRecords, 
            result
        );

        return Result<PagedResponse<IEnumerable<PaymentReadInfo>>>.Success(response);
    }
}
