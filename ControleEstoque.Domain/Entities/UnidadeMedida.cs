using System.Collections.Generic;

namespace ControleEstoque.Domain.Entities
{
    public class UnidadeMedida
    {
        public int  UnidadeMedidaId { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
