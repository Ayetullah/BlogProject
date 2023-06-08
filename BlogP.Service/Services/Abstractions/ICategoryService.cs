using BlogP.Entity.ModelDtos.Categories;

namespace BlogP.Service.Services.Abstractions
{
    public interface ICategoryService
    {
        public Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
    }
}
