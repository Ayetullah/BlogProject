﻿using AutoMapper;
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

        public async Task CreateArticleAsync(ArticleAddDto articleDto)
        {
			var userId = Guid.Parse("FEB2B98B-8D5C-4E4B-92E0-2F7AEDE0A49A");
			var article = new Article
			{
				Title = articleDto.Title,
				Content = articleDto.Content,
				CategoryId = articleDto.CategoryId,
				UserId = userId
			};

			await _unitOfWork.GetRepository<Article>().AddAsync(article);
			await _unitOfWork.SaveAsync();
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
		{
			
			var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted,x => x.Category);
			var articleDtos = _mapper.Map<List<ArticleDto>>(articles);
			return articleDtos;
		}
	}
}
