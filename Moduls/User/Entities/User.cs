using WebAPI.Common.Base.BaseEntity;
using WebAPI.Common.Constants;

namespace WebAPI.Moduls.User.Entities;

public sealed class User : BaseEntity
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string AvatarPath { get; set; } = ImageName.Default;

    public ICollection<Payment.Entities.Payment> Payments { get; set; } = [];
}