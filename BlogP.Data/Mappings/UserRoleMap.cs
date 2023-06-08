using BlogP.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogP.Data.Mappings
{
	public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
	{
		public void Configure(EntityTypeBuilder<AppUserRole> b)
		{
			// Primary key
			b.HasKey(r => new { r.UserId, r.RoleId });

			// Maps to the AspNetUserRoles table
			b.ToTable("AppUserRoles");

			b.HasData(new AppUserRole
			{
				RoleId = Guid.Parse("403EEB54-A057-40B2-B90B-39D47ADD3FC7"),
				UserId = Guid.Parse("6348DCD3-BA89-4F1C-95AB-89F0CB2BCF15")
			}, new AppUserRole
			{
				RoleId = Guid.Parse("2F68FBBD-51A7-4125-8330-16FBC7D67689"),
				UserId = Guid.Parse("FEB2B98B-8D5C-4E4B-92E0-2F7AEDE0A49A")
			});
		}
	}
}
