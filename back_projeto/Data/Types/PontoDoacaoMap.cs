// using Domain.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;

// namespace Data.Types
// {
//     public class PontoDoacaoMap : IEntityTypeConfiguration<PontoDoacao>
//     {
//         public void Configure(EntityTypeBuilder<PontoDoacao> builder)
//         {
//             builder.ToTable("PontosDoacao");
//             builder.HasKey(p => p.Id);

//             builder.Property(p => p.Id)
//                 .HasColumnName("Id")
//                 .IsRequired()
//                 .ValueGeneratedOnAdd();

//             builder.Property(p => p.NomeLocal)
//                 .HasColumnName("NomeLocal")
//                 .IsRequired()
//                 .HasMaxLength(100);

//             builder.Property(p => p.MateriasAceito)
//                 .HasColumnName("MateriasAceito")
//                 .IsRequired()
//                 .HasMaxLength(50); // Defina o tamanho máximo adequado para o seu enum

//             // Configurar o relacionamento com Endereco (One-to-One)
//             builder.HasOne(p => p.Endereco)
//                 .WithOne()
//                 .HasForeignKey<PontoDoacao>(p => p.Id)
//                 .OnDelete(DeleteBehavior.Cascade); // Isso configura a exclusão em cascata se necessário

//             // Configurar o relacionamento com Instituto (Many-to-One)
//             builder.HasOne(p => p.Instituto)
//                 .WithMany(i => i.PontosDoacao)
//                 .HasForeignKey(p => p.InstitutoId)
//                 .OnDelete(DeleteBehavior.Cascade); // Is
//         }
//     }
// }