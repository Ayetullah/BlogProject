using BlogP.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogP.Data.Mappings
{
	public class RoleMap : IEntityTypeConfiguration<AppRole>
	{
		public void Configure(EntityTypeBuilder<AppRole> b)
		{
			// Primary key

			b.HasKey(r => r.Id);

			// Index for "normalized" role name to allow efficient lookups
			b.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

			// Maps to the AspNetRoles table
			b.ToTable("AppRoles");

			// A concurrency token for use with the optimistic concurrency checking
			b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

			// Limit the size of columns to use efficient database types
			b.Property(u => u.Name).HasMaxLength(256);
			b.Property(u => u.NormalizedName).HasMaxLength(256);

			// The relationships between Role and other entity types
			// Note that these relationships are configured with no navigation properties

			// Each Role can have many entries in the UserRole join table
			b.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

			// Each Role can have many associated RoleClaims
			b.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

			b.HasData(new AppRole
			{
				Id = Guid.Parse("403EEB54-A057-40B2-B90B-39D47ADD3FC7"),
				Name = "SuperAdmin",
				NormalizedName = "SUPERADMIN",
				ConcurrencyStamp = Guid.NewGuid().ToString()
			}, new AppRole
			{
				Id = Guid.Parse("2F68FBBD-51A7-4125-8330-16FBC7D67689"),
				Name = "Admin",
				NormalizedName = "ADMIN",
				ConcurrencyStamp = Guid.NewGuid().ToString()
			}, new AppRole
			{
				Id = Guid.Parse("3CE5AC02-2D9E-432E-9B46-339090388BD2"),
				Name = "User",
				NormalizedName = "USER",
				ConcurrencyStamp = Guid.NewGuid().ToString()
			});
		}
	}
}
