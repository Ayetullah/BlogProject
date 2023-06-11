using AutoMapper;
using BlogP.Entity.Entities;
using BlogP.Entity.ModelDtos.Articles;
using BlogP.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BlogP.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _mapper = mapper;
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
        public async Task<IActionResult> Add(ArticleAddDto article)
        {
            await _articleService.CreateArticleAsync(article);
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
            var articleUpdateDto = _mapper.Map<ArticleUpdateDto>(article);
            articleUpdateDto.Categories = categories;
            return View(articleUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateDto article)
        {
            await _articleService.UpdateArticleAsync(article);
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            article.Categories = categories;
            return View(article);
        }
        #endregion
    }
}
