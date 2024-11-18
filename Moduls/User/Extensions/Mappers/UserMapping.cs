using WebAPI.Common.Constants;
using WebAPI.Common.FileService;
using WebAPI.Moduls.User.ViewModels;

namespace WebAPI.Moduls.User.Mappers;

public static class UserMapping
{
    public static UserReadInfo ToReadInfo(this Entities.User user)
    {
        return new()
        {
            Id = user.Id,
            UserBaseInfo = new()
            {
                UserName = user.UserName,
                PhoneNumber = user.Phone,
                Email = user.Email
            },
            Filename = user.AvatarPath
        };
    }

    public static async Task<Entities.User> ToUser(this UserCreateDto createInfo,IFileService fileService)
    {
        string? avatarPath = ImageName.Default;
        if (createInfo.File is not null)
            avatarPath = await fileService.CreateFile(createInfo.File, MediaFolders.Images);
        
        return new()
        {
            Phone = createInfo.Phone,
            Email = createInfo.Email,
            UserName = createInfo.UserName,
            Password = createInfo.Password,
            AvatarPath = avatarPath
        };
    }

    public static async Task<Entities.User> ToUpdate(this Entities.User user ,UserUpdateInfo updateInfo, IFileService fileService)
    {
        if (updateInfo.File is not null)
        { 
            fileService.DeleteFile(user.AvatarPath, MediaFolders.Images);
            
            user.AvatarPath = await fileService.CreateFile(updateInfo.File, MediaFolders.Images);
        }
        
        user.UserName = updateInfo.UserName;
        user.Phone = updateInfo.Phone;
        user.Email = updateInfo.Email;
        user.Version++;
        user.UpdatedAt = DateTime.UtcNow;
        return user;
    }

    public static Entities.User ToDeleted(this Entities.User user,IFileService fileService)
    {
        user.IsDeleted = true;
        user.DeletedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;
        fileService.DeleteFile(user.AvatarPath, MediaFolders.Images);
        user.Version++;
        return user;
    }
}