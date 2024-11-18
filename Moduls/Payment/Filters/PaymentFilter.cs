using WebAPI.Common.Base.BaseFilter;

namespace WebAPI.Moduls.Payment.Filters;

public record PaymentFilter(decimal? MinAmount ,decimal? MaxAmount) : BaseFilter;