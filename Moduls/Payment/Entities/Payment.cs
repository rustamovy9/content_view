using WebAPI.Common.Base.BaseEntity;

namespace WebAPI.Moduls.Payment.Entities;

public sealed class Payment : BaseEntity
{
    public int UserId { get; set; }
    public int VideoId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }=DateTime.UtcNow;
    public bool IsSuccessful { get; set; }

    public User.Entities.User User { get; set; }
    
    public Video.Entities.Video Video { get; set; }
}