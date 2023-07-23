using BlogP.Service.FluentValidations;
using BlogP.Service.Services.Abstractions;
using BlogP.Service.Services.Concretes;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace BlogP.Service.Extensions
{
	public static class ServiceLayerExtensions
	{
		public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
		{
			var assembly = Assembly.GetExecutingAssembly();
			services.AddScoped<IArticleService, ArticleService>();
			services.AddScoped<ICategoryService, CategoryService>();

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddAutoMapper(assembly);

			services.AddControllersWithViews().AddFluentValidation(opt =>
			{
				opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
				opt.DisableDataAnnotationsValidation = true;
				opt.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");
			});

            return services;
		}
	}
}
