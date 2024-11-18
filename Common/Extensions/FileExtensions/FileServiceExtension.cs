using Microsoft.Extensions.FileProviders;

namespace WebAPI.Common.Extensions.FileExtensions;

public static class FileServerExtensions
{
    public static void UseCustomFileServer(this WebApplication app)
    {

        app.UseFileServer(new FileServerOptions()
        {
            StaticFileOptions =
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/images")),
                RequestPath = new PathString("/images")
            },
            DirectoryBrowserOptions =
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/images")),
                RequestPath = new PathString("/images")
            },
            EnableDirectoryBrowsing = true
        });

        app.UseFileServer(new FileServerOptions()
        {
            StaticFileOptions =
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/videos")),
                RequestPath = new PathString("/videos")
            },
            DirectoryBrowserOptions =
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/videos")),
                RequestPath = new PathString("/videos")
            },
            EnableDirectoryBrowsing = true
        });
    }
}