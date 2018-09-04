using System.Collections.Generic;

namespace ControleEstoque.Domain.Entities
{
    public class LocalArmazenamento
    {
        public int LocalArmazenamentoId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
