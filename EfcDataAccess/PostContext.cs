using Microsoft.EntityFrameworkCore;
using Shared.Models;
using EfcDataAccess.DAOs;


namespace EfcDataAccess;

public class PostContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = C:/Users/catin/RiderProjects/AssignmentDNP/EfcDataAccess/Post.db");
        // C:\Users\catin\RiderProjects\DNP Assignment\EfcDataAccess\Todo.db
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);            
        optionsBuilder.LogTo(Console.WriteLine); // Add this line for logging

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasOne(post => post.Owner)
            .WithMany(user => user.Posts)
            .HasForeignKey(post => post.OwnerId);

        modelBuilder.Entity<Post>().HasKey(post => post.Id);
        modelBuilder.Entity<User>().HasKey(user => user.Id);
    }
   
}