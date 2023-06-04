using BlogP.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogP.Data.Mappings
{
	public class ImageMap : IEntityTypeConfiguration<Image>
	{
		public void Configure(EntityTypeBuilder<Image> builder)
		{
			builder.HasData(new Image
			{
				Id = Guid.Parse("821A63A5-3942-47E5-B4F8-D338BE7438A2"),
				CreatedBy = "Admin Core",
				CreatedDate = DateTime.Now,
				IsDeleted = false,
				FileName = "images/testimage",
				FileType="jpg"
			});
		}
	}
}
