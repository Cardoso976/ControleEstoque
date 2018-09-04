using System.Data.Entity.ModelConfiguration;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Infra.Data.EntityConfig
{
    public class PaisConfiguration : EntityTypeConfiguration<Pais>
    {
        public PaisConfiguration()
        {
            HasKey(p => p.PaisId);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(150);

            Property(p => p.Codigo)
                .IsRequired()
                .HasMaxLength(2);
        }
    }
}
