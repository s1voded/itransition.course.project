using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalCollection.Domain.Entities;

namespace PersonalCollection.Persistence.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(u => u.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                b.HasMany(u => u.Comments)
                    .WithOne(c => c.User)
                    .HasForeignKey(c => c.UserId);

                b.HasMany(u => u.Likes)
                    .WithOne(l => l.User)
                    .HasForeignKey(l => l.UserId);
            });

            modelBuilder.Entity<Collection>().OwnsOne(collection => collection.CustomFieldsSettings, builder => 
            {
                builder.OwnsMany(x => x.CustomStrings);
                builder.OwnsMany(x => x.CustomTexts);
                builder.OwnsMany(x => x.CustomInts);
                builder.OwnsMany(x => x.CustomBools);
                builder.OwnsMany(x => x.CustomDates);
                builder.ToJson();
            });

            modelBuilder.Entity<Theme>().HasData(
                new Theme { Id = 1, Name = "Other" },
                new Theme { Id = 2, Name = "Books" },
                new Theme { Id = 3, Name = "Stamps" });
        }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
