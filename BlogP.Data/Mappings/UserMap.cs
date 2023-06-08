using BlogP.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogP.Data.Mappings
{
	public class UserMap : IEntityTypeConfiguration<AppUser>
	{
		public void Configure(EntityTypeBuilder<AppUser> b)
		{
			b.HasKey(u => u.Id);

			// Indexes for "normalized" username and email, to allow efficient lookups
			b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
			b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

			// Maps to the AspNetUsers table
			b.ToTable("AppUsers");

			// A concurrency token for use with the optimistic concurrency checking
			b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

			// Limit the size of columns to use efficient database types
			b.Property(u => u.UserName).HasMaxLength(256);
			b.Property(u => u.NormalizedUserName).HasMaxLength(256);
			b.Property(u => u.Email).HasMaxLength(256);
			b.Property(u => u.NormalizedEmail).HasMaxLength(256);

			// The relationships between User and other entity types
			// Note that these relationships are configured with no navigation properties

			// Each User can have many UserClaims
			b.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

			// Each User can have many UserLogins
			b.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

			// Each User can have many UserTokens
			b.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

			// Each User can have many entries in the UserRole join table
			b.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

			var superAdmin = new AppUser
			{
				Id = Guid.Parse("6348DCD3-BA89-4F1C-95AB-89F0CB2BCF15"),
				UserName = "superadmin@gmail.com",
				NormalizedUserName = "SUPERADMIN@GMAIL.COM",
				Email = "superadmin@gmail.com",
				NormalizedEmail = "SUPERADMIN@GMAIL.COM",
				PhoneNumber = "05451231144",
				FirstName="Ayetullah",
				LastName="Ünlü",
				PhoneNumberConfirmed=true,
				EmailConfirmed=true,
				SecurityStamp=Guid.NewGuid().ToString(),
				ImageId = Guid.Parse("821A63A5-3942-47E5-B4F8-D338BE7438A2")
			};
			superAdmin.PasswordHash = CreatePasswordHash(superAdmin, "123456");

			var admin = new AppUser
			{
				Id = Guid.Parse("FEB2B98B-8D5C-4E4B-92E0-2F7AEDE0A49A"),
				UserName = "admin@gmail.com",
				NormalizedUserName = "ADMIN@GMAIL.COM",
				Email = "admin@gmail.com",
				NormalizedEmail = "ADMIN@GMAIL.COM",
				PhoneNumber = "05451232211",
				FirstName="Ayo",
				LastName="Ünlü",
				PhoneNumberConfirmed=false,
				EmailConfirmed=false,
				SecurityStamp=Guid.NewGuid().ToString(),
				ImageId = Guid.Parse("821A63A5-3942-47E5-B4F8-D338BE7438A2")
			};
			admin.PasswordHash = CreatePasswordHash(admin, "123456");

			b.HasData(superAdmin, admin);
		}

		private string CreatePasswordHash(AppUser user, string password)
		{
			var hasher = new PasswordHasher<AppUser>();
			return hasher.HashPassword(user, password);
		}
	}
}
