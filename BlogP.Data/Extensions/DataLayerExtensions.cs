using BlogP.Data.Context;
using BlogP.Data.Repositories.Abstractions;
using BlogP.Data.Repositories.Concretes;
using BlogP.Data.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogP.Data.Extensions
{
	public static class DataLayerExtensions
	{
		public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration conf)
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

			services.AddDbContext<AppDbContext>(opt =>
			{
				opt.UseSqlServer(conf.GetConnectionString("SqlConnection"));
			});

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			return services;
		}
	}
}
