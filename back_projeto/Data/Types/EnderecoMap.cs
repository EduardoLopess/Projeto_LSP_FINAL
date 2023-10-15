using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos"); 
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Logradouro)
                .HasColumnName("Logradouro")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.NumeroCasa)
                .HasColumnName("NumeroCasa")
                .IsRequired();

            builder.Property(e => e.Bairro)
                .HasColumnName("Bairro")
                .HasMaxLength(255);

            builder.Property(e => e.Complemento)
                .HasColumnName("Complemento")
                .HasMaxLength(255);

            builder.Property(e => e.Cep)
                .HasColumnName("Cep")
                .IsRequired();

            builder.Property(e => e.Cidade)
                .HasColumnName("Cidade")
                .HasMaxLength(255);

            // Relação de muitos endereços para um usuário (N:1)
            builder.HasOne(e => e.Usuario)
                .WithMany(u => u.Enderecos)
                .HasForeignKey(e => e.UsuarioId) // Chave estrangeira em Endereco
                .IsRequired();
        }

    }
}