using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class InstitutoMap : IEntityTypeConfiguration<Instituto>
    {
        public void Configure(EntityTypeBuilder<Instituto> builder)
        {
            builder.ToTable("Institutos");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(i => i.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Descricao)
                .HasColumnName("Descricao")
                .IsRequired()
                .HasMaxLength(800);

            // Relacionamento com Endereco (One-to-One)
            builder.HasOne(i => i.Endereco)
                .WithOne()
                .HasForeignKey<Endereco>(e => e.InstitutoId) // Adicione esta linha se Endereco tiver uma propriedade chamada InstitutoId
                .OnDelete(DeleteBehavior.Cascade); // Isso configura a exclusão em cascata se necessário

            // Relacionamento com PerfilAcesso (Enum)
            builder.Property(i => i.Perfil)
                .HasColumnName("Perfil")
                .IsRequired()
                .HasConversion<string>(); // Mapear o enum para string no banco de dados

            // Relacionamento com Voluntariados (One-to-Many)
            builder.HasMany(i => i.Voluntariados)
                .WithOne(v => v.Instituto)
                .HasForeignKey(v => v.Id)
                .OnDelete(DeleteBehavior.Cascade); // Isso configura a exclusão em cascata se necessário

            // Relacionamento com MateriasDoacao (One-to-Many)
            builder.HasMany(i => i.MateriasDoacao)
                .WithOne(m => m.Instituto)
                .HasForeignKey(m => m.Id)
                .OnDelete(DeleteBehavior.Cascade);           
        }
    }
}