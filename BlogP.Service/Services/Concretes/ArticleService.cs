using AutoMapper;
using BlogP.Data.UnitOfWorks;
using BlogP.Entity.Entities;
using BlogP.Entity.ModelDtos.Articles;
using BlogP.Service.Extensions;
using BlogP.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BlogP.Service.Services.Concretes
{
    public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClaimsPrincipal _user;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
            _httpContextAccessor = contextAccessor;
            _user = _httpContextAccessor.HttpContext.User;
        }

        public async Task CreateArticleAsync(ArticleAddDto articleDto)
        {
			var userId = _user.GetLoggedInUserId();
			var email = _user.GetLoggedInUserName();

			var article = new Article(
				 articleDto.Title,
				articleDto.Content,
				articleDto.CategoryId,
				userId,
                email
            );

			await _unitOfWork.GetRepository<Article>().AddAsync(article);
			await _unitOfWork.SaveAsync();
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
		{
			
			var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted,x => x.Category);
			var articleDtos = _mapper.Map<List<ArticleDto>>(articles);
			return articleDtos;
		}

		public async Task<ArticleDto> GetAllArticlesWithCategoryByIdAsync(Guid id)
		{
            var articles = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.Id == id && !x.IsDeleted, x => x.Category);
            var articleDtos = _mapper.Map<ArticleDto>(articles);
            return articleDtos;
        }

        public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
           var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.Id == articleUpdateDto.Id && !x.IsDeleted, x => x.Category);

			article.Title = articleUpdateDto.Title;
			article.Content = articleUpdateDto.Content;
			article.CategoryId = articleUpdateDto.CategoryId;
			article.ModifiedDate = DateTime.Now;
			article.ModifiedBy = _user.GetLoggedInUserName();

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
			return article.Title;
        }

        public async Task<string> SafeDeleteArticleAsync(Guid id)
        {
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.Id == id && !x.IsDeleted);

            article.IsDeleted = true;
			article.DeletedDate = DateTime.Now;
			article.DeletedBy = _user.GetLoggedInUserName();

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
			return article.Title;
        }
    }
}
