using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
             builder.ToTable("Usuarios");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.SobreNome)
                .HasColumnName("SobreNome")
                .IsRequired()
                .HasMaxLength(100);

            // Outras configurações de propriedades...

            // Configurar o relacionamento um-para-um com Login
            builder.HasOne(u => u.Login)
                .WithOne(l => l.Usuario)
                .HasForeignKey<Login>(l => l.UsuarioId)
                .IsRequired(); // Defina como obrigatório se a relação é obrigatória

            // Configurar o relacionamento muitos-para-muitos com VoluntariadosInscritos
            builder
                .HasMany(u => u.VoluntariadosInscritos)
                .WithMany(v => v.UsuariosInscritos)
                .UsingEntity<Dictionary<string, object>>(
                    "VoluntariadoUsuario",
                    j => j
                        .HasOne<Voluntariado>()
                        .WithMany()
                        .HasForeignKey("VoluntariadoId")
                        .HasConstraintName("FK_VoluntariadoUsuario_Voluntariado_VoluntariadoId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Usuario>()
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_VoluntariadoUsuario_Usuario_UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("UsuarioId", "VoluntariadoId");
                        j.ToTable("VoluntariadoUsuarios");
                    });
        }
    }
}