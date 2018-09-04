using System.Data.Entity.ModelConfiguration;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Infra.Data.EntityConfig
{
    public class UnidadeMedidaConfiguration : EntityTypeConfiguration<UnidadeMedida>
    {
        public UnidadeMedidaConfiguration()
        {
            HasKey(u => u.UnidadeMedidaId);

            Property(u => u.Descricao)
                .IsRequired()
                .HasMaxLength(150);

            Property(u => u.Sigla)
                .IsRequired()
                .HasMaxLength(3);
        }
    }
}
