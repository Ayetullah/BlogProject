using AutoMapper;
using BlogP.Entity.Entities;
using BlogP.Entity.ModelDtos.Categories;

namespace BlogP.Service.AutoMapper.Categories
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}
