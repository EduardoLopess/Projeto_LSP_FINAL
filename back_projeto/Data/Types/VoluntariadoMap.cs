using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class VoluntariadoMap : IEntityTypeConfiguration<Voluntariado>
    {
        public void Configure(EntityTypeBuilder<Voluntariado> builder)
        {
            builder.ToTable("Voluntariados");
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(v => v.Titulo)
                .HasColumnName("Titulo")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.Descricao)
                .HasColumnName("Descricao")
                .IsRequired()
                .HasMaxLength(800);

            // Configurar a relação com o Instituto (Many-to-One)
            builder.HasOne(v => v.Instituto)
                .WithMany(i => i.Voluntariados)
                .HasForeignKey(v => v.Id)
                .OnDelete(DeleteBehavior.Cascade); // Isso configura a exclusão em cascata se necessário

            // Configurar a relação com os usuários inscritos (Many-to-Many)
            builder.HasMany(v => v.UsuariosInscritos)
                .WithMany(u => u.VoluntariadosInscritos)
                .UsingEntity<Dictionary<string, object>>(
                    "VoluntariadoUsuario",
                    j => j
                        .HasOne<Usuario>()
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("FK_VoluntariadoUsuario_Usuario_UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Voluntariado>()
                        .WithMany()
                        .HasForeignKey("VoluntariadoId")
                        .HasConstraintName("FK_VoluntariadoUsuario_Voluntariado_VoluntariadoId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("UsuarioId", "VoluntariadoId");
                        j.ToTable("VoluntariadoUsuarios");
                    });

          builder.OwnsMany(v => v.Beneficios, b =>
            {
                b.Property<string>("Beneficio").HasMaxLength(100).HasColumnName("Beneficio");
                b.HasKey("Beneficio"); // Defina uma chave primária simples
                b.ToTable("VoluntariadoBeneficios");
            });

            builder.OwnsMany(v => v.Responsabilidade, r =>
            {
                r.Property<string>("Responsabilidade").HasMaxLength(100).HasColumnName("Responsabilidade");
                r.HasKey("Responsabilidade"); // Defina uma chave primária simples
                r.ToTable("VoluntariadoResponsabilidades");
            });
        }
    }
}