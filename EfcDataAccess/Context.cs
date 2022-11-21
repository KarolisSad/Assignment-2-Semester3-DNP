namespace EfcDataAccess;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<User> Users {get; set;}
    public DbSet<Post> Posts {get; set;}
    public DbSet<SubForum> SubForums {get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/DNP-Assignment3.db");
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasKey(post => post.Id);
            modelBuilder.Entity<User>().HasKey(user => user.Username);
            modelBuilder.Entity<SubForum>().HasKey(forum => forum.Id);
        }
}