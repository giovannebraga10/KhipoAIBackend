namespace KhipoAI.Context
{
    using KhipoAI.Models;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cotacao> Cotacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PlanoCotacao> PlanosCotacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cotacao>()
            .HasOne(c => c.Plano)
            .WithMany()
            .HasForeignKey(c => c.PlanoId);



        }
    }

}
