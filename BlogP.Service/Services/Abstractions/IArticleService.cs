﻿using BlogP.Entity.ModelDtos.Articles;

namespace BlogP.Service.Services.Abstractions
{
    public interface IArticleService
	{
		Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
		Task<ArticleDto> GetAllArticlesWithCategoryByIdAsync(Guid id);
		Task CreateArticleAsync(ArticleAddDto article);
		Task UpdateArticleAsync(ArticleUpdateDto article);
		Task SafeDeleteArticleAsync(Guid id);
	}
}
