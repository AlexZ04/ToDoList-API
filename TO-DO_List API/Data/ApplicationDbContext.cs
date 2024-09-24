using Microsoft.EntityFrameworkCore;
using TO_DO_List_API.Data.Models;

namespace TO_DO_List_API.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasKey(x => x.Id);
            modelBuilder.Entity<Note>().Property(x => x.Text).ValueGeneratedOnAdd();

            modelBuilder.Entity<Note>().Property(x => x.Text).IsRequired();

            modelBuilder.Entity<Note>().ToTable("notes");

            base.OnModelCreating(modelBuilder);
        }
    }
}
