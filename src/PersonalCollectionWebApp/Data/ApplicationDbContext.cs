using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalCollectionWebApp.Models.Entities;

namespace PersonalCollectionWebApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne()
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<PersonalCollection>().OwnsOne(collection => collection.CustomFieldsSettings, builder => 
            {
                builder.OwnsMany(x => x.CustomStrings);
                builder.OwnsMany(x => x.CustomTexts);
                builder.OwnsMany(x => x.CustomInts);
                builder.OwnsMany(x => x.CustomBools);
                builder.OwnsMany(x => x.CustomDates);
                builder.ToJson(); 
            });
        }
        public DbSet<PersonalCollection> Collections { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
