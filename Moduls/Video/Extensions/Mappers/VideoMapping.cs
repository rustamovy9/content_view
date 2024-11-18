using WebAPI.Common.Constants;
using WebAPI.Common.FileService;
using WebAPI.Moduls.Video.ViewModels;

namespace WebAPI.Moduls.Video.Extensions.Mappers;

public static class VideoMapping
{
    public static VideoReadInfo ToReadInfo(this Entities.Video video)
    {
        return new()
        {
            Id = video.Id,
            VideoBaseInfo = new()
            {
                Title = video.Title,
                Description = video.Description,
                Price = video.Price,
                CategoryId = video.CategoryId,
                IsPaid = video.IsPaid
            },
            Filename = video.FilePath
        };
    }

    public static async Task<Entities.Video> ToVideo(this VideoCreateDto createInfo,IFileService fileService)
    {
        string path = await fileService.CreateFile(createInfo.File, MediaFolders.Videos);
        
        return new()
        {
            Title = createInfo.Title,
            Description = createInfo.Description,
            Price = createInfo.Price,
            IsPaid = createInfo.Price > 0,
            CategoryId = createInfo.CategoryId,
            FilePath = path
        };
    }

    public static async Task<Entities.Video> ToUpdate(this Entities.Video video ,VideoUpdateInfo updateInfo, IFileService fileService)
    {
        if (updateInfo.File is not null)
        { 
            fileService.DeleteFile(video.FilePath, MediaFolders.Videos);
            
            video.FilePath = await fileService.CreateFile(updateInfo.File, MediaFolders.Videos);
        }
        
        video.Title = updateInfo.Title;
        video.Description = updateInfo.Description;
        video.CategoryId = updateInfo.CategoryId;
        video.Price = updateInfo.Price;
        video.IsPaid = updateInfo.Price > 0;
        video.Version++;
        video.UpdatedAt = DateTime.UtcNow;
        return video;
    }

    public static Entities.Video ToDeleted(this Entities.Video video,IFileService fileService)
    {
        video.IsDeleted = true;
        video.DeletedAt = DateTime.UtcNow;
        video.UpdatedAt = DateTime.UtcNow;
        fileService.DeleteFile(video.FilePath, MediaFolders.Videos);
        video.Version++;
        return video;
    }
}