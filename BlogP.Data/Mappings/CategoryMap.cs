using BlogP.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogP.Data.Mappings
{
	public class CategoryMap : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(new Category
			{
				Id = Guid.Parse("A37C8C85-BA5D-49FE-8729-5C1B05A17CA0"),
				Name = "Asp.net Core",
				CreatedBy = "Admin Test",
				CreatedDate = DateTime.Now,
				IsDeleted = false,
			});
		}
	}
}
