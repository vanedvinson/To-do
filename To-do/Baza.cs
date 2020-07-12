using System.Data.Entity;

namespace To_do
{
    public class Baza : DbContext
    {
        public DbSet<ToDo> toDos { get; set; }
        public DbSet<Cekirano> cekiranos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().HasKey(a => a.ID);
            modelBuilder.Entity<Cekirano>().HasKey(b => b.ID);
        }

    }
}
