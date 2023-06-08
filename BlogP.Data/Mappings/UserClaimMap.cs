using BlogP.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogP.Data.Mappings
{
	public class UserClaimMap : IEntityTypeConfiguration<AppUserClaim>
	{
		public void Configure(EntityTypeBuilder<AppUserClaim> b)
		{
			b.HasKey(uc => uc.Id);

			// Maps to the AspNetUserClaims table
			b.ToTable("AppUserClaims");
		}
	}
}
