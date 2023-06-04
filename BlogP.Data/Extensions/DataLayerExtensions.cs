using BlogP.Data.Repositories.Abstractions;
using BlogP.Data.Repositories.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogP.Data.Extensions
{
	public static class DataLayerExtensions
	{
		public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration conf)
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			return services;
		}
	}
}
