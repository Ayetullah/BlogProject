using AutoMapper;
using BlogP.Entity.Entities;
using BlogP.Entity.ModelDtos.Articles;
using BlogP.Service.Extensions;
using BlogP.Service.Services.Abstractions;
using BlogP.Web.Models;
using BlogP.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BlogP.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IValidator<Article> _validator;
        private readonly IToastNotification _toastNotification;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator, IToastNotification toastNotification)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _mapper = mapper;
            _validator = validator;
            _toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }

        #region Add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories });
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            var result = await _validator.ValidateAsync(article);
            if (result.IsValid)
            {
                await _articleService.CreateArticleAsync(articleDto);
                _toastNotification.AddSuccessToastMessage(Messages.GetToastMessage(articleDto.Title, ProcessType.Add), new ToastrOptions { Title ="Başarılı!" });
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);            
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ArticleAddDto { Categories = categories });
        }
        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> Update(Guid articleId)
        {
            var article = await _articleService.GetAllArticlesWithCategoryByIdAsync(articleId);
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            var articleUpdateDto = new ArticleUpdateDto
            {
                Title = article.Title,
                CategoryId= article.Category.Id,
                Content = article.Content,
                Id = articleId
            };
            articleUpdateDto.Categories = categories;
            return View(articleUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            var result = await _validator.ValidateAsync(article);
            if (result.IsValid)
            {
                var title = await _articleService.UpdateArticleAsync(articleDto);
                _toastNotification.AddSuccessToastMessage(Messages.GetToastMessage(title, ProcessType.Update), new ToastrOptions { Title = "Başarılı!" });
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);

            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            articleDto.Categories = categories;
            return View(article);
        }
        #endregion

        #region SafeDelete
        [HttpGet]
        public async Task<IActionResult> SafeDelete(Guid articleId)
        {
            var title = await _articleService.SafeDeleteArticleAsync(articleId);
            _toastNotification.AddSuccessToastMessage(Messages.GetToastMessage(title, ProcessType.Delete), new ToastrOptions { Title = "Başarılı!" });
            return RedirectToAction("Index","Article", new { Area = "Admin" });
        }

        #endregion
    }
}
