using BlogP.Entity.ModelDtos.Articles;

namespace BlogP.Service.Services.Abstractions
{
    public interface IArticleService
	{
		Task<List<ArticleDto>> GetAllArticlesAsync();
	}
}
