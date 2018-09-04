using System.Collections.Generic;

namespace ControleEstoque.Domain.Entities
{
    public class Pais
    {
        public int PaisId { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Estado> Estados { get; set; }
    }
}
