using WebAPI.Common.Base.BaseEntity;

namespace WebAPI.Moduls.Video.Entities;

public sealed class Video : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string FilePath { get; set; } = null!;
    public bool IsPaid { get; set; }
    public decimal Price { get; set; } 
    public int CategoryId { get; set; }

    public Category.Entities.Category Category { get; set; }
    public ICollection<Payment.Entities.Payment> Payments { get; set; } = [];
}