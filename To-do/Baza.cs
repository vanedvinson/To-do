using System.Data.Entity;

namespace To_do
{
    public class Baza : DbContext
    {
        public DbSet<ToDo> toDos { get; set; }
        public DbSet<Checked> cekiranos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().HasKey(a => a.ID);
            modelBuilder.Entity<Checked>().HasKey(b => b.ID);
        }

    }
}
