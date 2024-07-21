using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BirrasBares.Models;

namespace BirrasBares.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bar> Bares { get; set; }
        public DbSet<Cerveza> Cervezas { get; set; }
        public DbSet<BarCerveza> BaresCervezas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<HorarioBar> HorariosBar { get; set; }
        public DbSet<PlatoMenu> PlatosMenu { get; set; }
        public DbSet<BarClasificacion> BarClasificaciones { get; set; }
        public DbSet<CervezaClasificacion> CervezaClasificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<BarCerveza>()
                .HasKey(bc => new { bc.BarId, bc.CervezaId });

            modelBuilder.Entity<BarCerveza>()
                .HasOne(bc => bc.Bar)
                .WithMany(b => b.BaresCervezas)
                .HasForeignKey(bc => bc.BarId);

            modelBuilder.Entity<BarCerveza>()
                .HasOne(bc => bc.Cerveza)
                .WithMany(c => c.BaresCervezas)
                .HasForeignKey(bc => bc.CervezaId);

            modelBuilder.Entity<HorarioBar>()
                .HasOne(h => h.Bar)
                .WithMany(b => b.Horarios)
                .HasForeignKey(h => h.BarId);

            modelBuilder.Entity<PlatoMenu>()
                 .HasOne(p => p.Bar)
                 .WithMany(b => b.PlatosMenu)
                 .HasForeignKey(p => p.BarId);

            modelBuilder.Entity<BarClasificacion>()
                .HasKey(bc => new { bc.UserId, bc.BarId });

            modelBuilder.Entity<BarClasificacion>()
                .HasOne(bc => bc.User)
                .WithMany(u => u.BaresClasificados)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<BarClasificacion>()
                .HasOne(bc => bc.Bar)
                .WithMany(b => b.Clasificaciones)
                .HasForeignKey(bc => bc.BarId);

            modelBuilder.Entity<CervezaClasificacion>()
                .HasKey(cc => new { cc.UserId, cc.CervezaId });

            modelBuilder.Entity<CervezaClasificacion>()
                .HasOne(cc => cc.User)
                .WithMany(u => u.CervezasClasificadas)
                .HasForeignKey(cc => cc.UserId);

            modelBuilder.Entity<CervezaClasificacion>()
                .HasOne(cc => cc.Cerveza)
                .WithMany(c => c.Clasificaciones)
                .HasForeignKey(cc => cc.CervezaId);
        }
    }
}
