using CompanyBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CompanyBox.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Suggestion> Suggestions { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Vote> Votes { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    public DbSet<SuggestionCategory> SuggestionCategories { get; set; }
    public DbSet<SuggestionTag> SuggestionTags { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SuggestionCategory>()
            .HasKey(sc => new { sc.SuggestionId, sc.CategoryId });

        modelBuilder.Entity<SuggestionTag>()
            .HasKey(st => new { st.SuggestionId, st.TagId });


        modelBuilder.Entity<Vote>()
            .HasKey(v => new { v.SuggestionId, v.UserId });


        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Suggestion)
            .WithMany(s => s.Comments)
            .HasForeignKey(c => c.SuggestionId)
            .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Vote>()
           .HasOne(v => v.Suggestion)
           .WithMany(s => s.Votes)
           .HasForeignKey(v => v.SuggestionId)
           .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Vote>()
            .HasOne(v => v.User)
            .WithMany(u => u.Votes)
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Feedback>()
            .HasOne(f => f.Sender)
            .WithMany(u => u.SentFeedbacks)
            .HasForeignKey(f => f.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Feedback>()
            .HasOne(f => f.Recipient)
            .WithMany(u => u.ReceivedFeedbacks)
            .HasForeignKey(f => f.RecipientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.ParentComment)
            .WithMany(c => c.Replies)
            .HasForeignKey(c => c.ParentCommentId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}