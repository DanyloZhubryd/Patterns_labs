using Microsoft.EntityFrameworkCore;
using Instagram.Models;

namespace Instagram.Data;

public class StoryContext : DbContext
{
    private readonly string _connectionString;
    public StoryContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
                .Entity<Reaction>()
                .Property(p => p.Type)
                .HasConversion<int>();

        modelBuilder.Entity<User>()
            .HasMany(y => y.CommentCollection)
            .WithOne(x => x.User)
            .OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<User>()
            .HasMany(y => y.ReactionCollection)
            .WithOne(x => x.User)
            .OnDelete(DeleteBehavior.SetNull);
    }

    public DbSet<User> UserCollection { get; set; }
    public DbSet<Story> StoryCollection { get; set; }
    public DbSet<Media> MediaCollection { get; set; }
    public DbSet<Reaction> ReactionCollection { get; set; }
    public DbSet<Comment> CommentCollection { get; set; }
}
