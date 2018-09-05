using System.Data.Entity.ModelConfiguration;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Infra.Data.EntityConfig
{
    public class FornecedorConfiguration : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfiguration()
        {
            HasKey(f => f.FornecedorId);

            Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(f => f.RazaoSocial)
                .HasMaxLength(150);

            Property(f => f.NumDocumento)
                .IsRequired()
                .HasMaxLength(14);

            Property(f => f.Tipo)
                .IsRequired();

            Property(f => f.Telefone)
                .IsRequired()
                .HasMaxLength(12);

            Property(f => f.Contato)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(f => f.Endereco)
                .WithMany()
                .HasForeignKey(f => f.EnderecoId);

        }
    }
}
