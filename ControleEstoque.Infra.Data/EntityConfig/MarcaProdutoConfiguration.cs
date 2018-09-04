using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Infra.Data.EntityConfig
{
    public class MarcaProdutoConfiguration : EntityTypeConfiguration<MarcaProduto>
    {
        public MarcaProdutoConfiguration()
        {
            HasKey(m => m.MarcaProdutoId);

            Property(m => m.Descricao)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
