using System.Data.Entity.ModelConfiguration;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Infra.Data.EntityConfig
{
    class GrupoProdutoConfiguration : EntityTypeConfiguration<GrupoProduto>
    {
        public GrupoProdutoConfiguration()
        {
            HasKey(c => c.GrupoProdutoId);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
