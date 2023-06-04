using BlogP.Data.UnitOfWorks;
using BlogP.Entity.Entities;
using BlogP.Service.Services.Abstractions;

namespace BlogP.Service.Services.Concretes
{
	public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ArticleService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<List<Article>> GetAllArticlesAsync()
		{
			return await _unitOfWork.GetRepository<Article>().GetAllAsync();
		}
	}
}
