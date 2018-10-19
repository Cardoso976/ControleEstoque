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

            Property(x => x.Logradouro)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Numero)
                .HasMaxLength(20)
                .IsRequired();

            Property(x => x.Complemento)
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.Cep)
                .HasMaxLength(10)
                .IsOptional();

            Property(x => x.Ativo)
                .IsRequired();

            Property(x => x.PaisId)
                .IsRequired();
            HasRequired(x => x.Pais)
                .WithMany()
                .HasForeignKey(x => x.PaisId)
                .WillCascadeOnDelete(false);

            Property(x => x.EstadoId)
                .IsRequired();
            HasRequired(x => x.Estado)
                .WithMany()
                .HasForeignKey(x => x.EstadoId)
                .WillCascadeOnDelete(false);

            Property(x => x.CidadeId)
                .IsRequired();
            HasRequired(x => x.Cidade)
                .WithMany()
                .HasForeignKey(x => x.CidadeId)
                .WillCascadeOnDelete(false);

        }
    }
}
