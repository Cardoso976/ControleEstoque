using ControleEstoque.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ControleEstoque.Infra.Data.EntityConfig
{
    public class EntradaProdutoConfiguration : EntityTypeConfiguration<EntradaProduto>
    {
        public EntradaProdutoConfiguration()
        {
            HasKey(x => x.Id);            

            Property(x => x.Numero)
                .IsRequired()
                .HasMaxLength(10);

            Property(x => x.Data)
                .IsRequired();

            Property(x => x.Quantidade)
                .IsRequired();

            Property(x => x.ProdutoId)
                .IsRequired();

            HasRequired(x => x.Produto)
                .WithMany()
                .HasForeignKey(x => x.ProdutoId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Produto)
                .WithMany()
                .HasForeignKey(x => x.ProdutoId)
                .WillCascadeOnDelete(false);
        }
    }
}
