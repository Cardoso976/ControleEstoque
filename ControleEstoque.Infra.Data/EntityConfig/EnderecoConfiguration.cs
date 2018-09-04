using System.Data.Entity.ModelConfiguration;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Infra.Data.EntityConfig
{
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            HasKey(e => e.EnderecoId);

            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(200);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(10);

            Property(e => e.Cep)
                .IsRequired()
                .HasMaxLength(8);

            Property(e => e.Complemento)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(e => e.Cidade)
                .WithMany()
                .HasForeignKey(e => e.CidadeId);
        }
    }
}
