using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class MaterialDoacaoMap : IEntityTypeConfiguration<MaterialDoacao>
    {
        public void Configure(EntityTypeBuilder<MaterialDoacao> builder)
        {
            builder.ToTable("MateriaisDoacao");
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Tipo)
                .HasColumnName("Tipo")
                .IsRequired()
                .HasMaxLength(50); // Defina o tamanho máximo adequado para o seu enum

            // Configurar o relacionamento com PontoDoacao (Many-to-One)
            builder.HasOne(m => m.PontoDoacao)
                .WithMany()
                .HasForeignKey(m => m.Id)
                .OnDelete(DeleteBehavior.Cascade); // Isso configura a exclusão em cascata se necessário

            // Configurar o relacionamento com Instituto (Many-to-One)
            builder.HasOne(m => m.Instituto)
                .WithMany()
                .HasForeignKey(m => m.Id)
                .OnDelete(DeleteBehavior.Cascade); // Isso 
        }
    }
}