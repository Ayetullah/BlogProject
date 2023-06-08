using BlogP.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogP.Data.Mappings
{
	public class RoleClaimMap : IEntityTypeConfiguration<AppRoleClaim>
	{
		public void Configure(EntityTypeBuilder<AppRoleClaim> b)
		{
			// Primary key
			b.HasKey(rc => rc.Id);

			// Maps to the AspNetRoleClaims table
			b.ToTable("AppRoleClaims");
		}
	}
}
