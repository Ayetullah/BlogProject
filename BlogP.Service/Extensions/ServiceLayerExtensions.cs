using BlogP.Service.Services.Abstractions;
using BlogP.Service.Services.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogP.Service.Extensions
{
	public static class ServiceLayerExtensions
	{
		public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services, IConfiguration conf)
		{
			services.AddScoped<IArticleService, ArticleService>();
			return services;
		}
	}
}
