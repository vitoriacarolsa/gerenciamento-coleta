using fiap.Models;
using Microsoft.EntityFrameworkCore;

namespace fiap.Data
{
    public class DataBaseContext : DbContext
    {

        public virtual DbSet<ColetaModel> Coletas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColetaModel>(entity =>
            {
                entity.ToTable("tb_coleta");
                entity.HasKey(e => e.ColetaId);
            });

        }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DataBaseContext()
        {
        }
    }
}
