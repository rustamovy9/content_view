using WebAPI.Common.Base.BaseEntity;

namespace WebAPI.Moduls.Category.Entities;

public sealed class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<Video.Entities.Video> Videos { get; set; } = [];
}