﻿using BlogP.Entity.Entities;
using BlogP.Service.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogP.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class HomeController : Controller
	{
		private readonly IArticleService articleService;

		public HomeController(IArticleService articleService)
		{
			this.articleService = articleService;
		}

		public async Task<IActionResult> Index()
		{
			var articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
			return View(articles);
		}
	}
}
