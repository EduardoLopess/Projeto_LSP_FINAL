using Data.Types;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext() {}
        public string DbPath { get; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            string path = Directory.GetCurrentDirectory();
            DbPath = Path.Join(path, "bancoLocal.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source = {DbPath}");
    
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Instituto> Institutos { get; set; }
        public DbSet<Voluntariado> Voluntariados { get; set; }
        public DbSet<PontoDoacao> PontoDoacaos { get; set;}
        public DbSet<MaterialDoacao> MaterialDoacaos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Login> Logins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new VoluntariadoMap());
            // modelBuilder.ApplyConfiguration(new MaterialDoacaoMap());
            // modelBuilder.ApplyConfiguration(new InstitutoMap());
        }
    }
}