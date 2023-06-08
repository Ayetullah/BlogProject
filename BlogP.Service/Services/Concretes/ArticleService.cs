using AutoMapper;
using BlogP.Data.UnitOfWorks;
using BlogP.Entity.Entities;
using BlogP.Entity.ModelDtos.Articles;
using BlogP.Service.Services.Abstractions;

namespace BlogP.Service.Services.Concretes
{
    public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<List<ArticleDto>> GetAllArticlesAsync()
		{
			
			var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync();
			var articleDtos = _mapper.Map<List<ArticleDto>>(articles);
			return articleDtos;
		}
	}
}
