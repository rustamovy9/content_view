using WebAPI.Common.Base.BaseFilter;

namespace WebAPI.Moduls.Video.Filters;

public record VideoFilter(string? Title,string? Description,decimal? MinPrice,decimal? MaxPrice) : BaseFilter;