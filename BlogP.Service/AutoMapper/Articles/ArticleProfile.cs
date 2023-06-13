using AutoMapper;
using BlogP.Entity.Entities;
using BlogP.Entity.ModelDtos.Articles;

namespace BlogP.Service.AutoMapper.Articles
{
    public class ArticleProfile : Profile
	{
		public ArticleProfile()
		{
			CreateMap<ArticleDto, Article>().ReverseMap();
			CreateMap<ArticleUpdateDto, Article>().ReverseMap();
			CreateMap<ArticleAddDto, Article>().ReverseMap();
		}
	}
}
