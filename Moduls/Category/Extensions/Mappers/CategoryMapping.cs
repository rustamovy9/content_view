using WebAPI.Moduls.Category.ViewModels;

namespace WebAPI.Moduls.Category.Extensions.Mappers;

public static class CategoryMapping
{
    public static CategoryReadInfo ToReadInfo(this Category.Entities.Category category)
    {
        return new()
        {
            Id = category.Id,
            CategoryBaseInfo = new()
            {
                CategoryName = category.Name
            }
        };
    }

    public static Entities.Category ToCategory(this CategoryCreateDto createInfo)
    {
        
        return new()
        {
            Name = createInfo.CategoryBaseInfo.CategoryName
        };
    }

    public static Category.Entities.Category ToUpdate(this Entities.Category category ,CategoryUpdateInfo updateInfo)
    {
 
        
        category.Name = updateInfo.CategoryBaseInfo.CategoryName;
        category.Version++;
        category.UpdatedAt = DateTime.UtcNow;
        return category;
    }

    public static Category.Entities.Category ToDeleted(this Entities.Category category)
    {
        category.IsDeleted = true;
        category.DeletedAt = DateTime.UtcNow;
        category.UpdatedAt = DateTime.UtcNow;
        category.Version++;
        return category;
    }
}