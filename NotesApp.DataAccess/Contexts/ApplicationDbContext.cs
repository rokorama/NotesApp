using Microsoft.EntityFrameworkCore;
using NotesApp.Models;

namespace NotesApp.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>()
            .HasOne(a => a.Image)
            .WithOne(a => a.Note)
            .HasForeignKey<NoteImage>(c => c.NoteId);
    }

    public DbSet<Note> Notes { get; set; }
    public DbSet<NoteCategory> Categories { get; set; }
    public DbSet<NoteImage> Images { get; set; }
    public DbSet<User> Users { get; set; }
}