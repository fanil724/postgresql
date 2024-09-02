using Microsoft.EntityFrameworkCore;


namespace postgresql
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Book> book { get; set; } = null!;
        public DbSet<Author> author { get; set; } = null!;

        public ApplicationContext()
        {
           // Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=192.168.50.240;Port=5432;Database=fan724;Username=fan724;Password=b070me716");
        }

    }
   
}
