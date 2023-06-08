using BlogP.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogP.Data.Mappings
{
	public class ArticleMap : IEntityTypeConfiguration<Article>
	{
		public void Configure(EntityTypeBuilder<Article> builder)
		{
			builder.HasData(new Article
			{
				Id = Guid.NewGuid(),
				Title="Asp.Net Core Deneme Makalesi 1",
				Content = "Makale belirli bir konuda yazılan ve belli bir düşünceyi savunma amacı taşıyan yazılara verilen isimdir. Makale yazımında kanıt kaygısı olduğundan çeşitli dergi, gazete veya kitaplarda yayımlanır ve bu nedenle bilimsel metin türleri arasında yer alır.  Makalelerdeki en önemli nokta savunulan düşüncenin bilimsel temele dayandırılması ve alanında uzman kişiler tarafından yazılmasıdır.",
				ViewCount = 0,				
				CategoryId = Guid.Parse("A37C8C85-BA5D-49FE-8729-5C1B05A17CA0"),				
				ImageId = Guid.Parse("821A63A5-3942-47E5-B4F8-D338BE7438A2"),
				CreatedBy = "Admin Test",
				CreatedDate = DateTime.Now,
				UserId = Guid.Parse("6348DCD3-BA89-4F1C-95AB-89F0CB2BCF15")
			});
		}
	}
}
