using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o código.")]
        [MaxLength(10, ErrorMessage = "O código pode ter no máximo 10 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Preencha a descrição.")]
        [MaxLength(50, ErrorMessage = "A descrição pode ter no máximo 50 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o preço de custo.")]
        public decimal PrecoCusto { get; set; }

        [Required(ErrorMessage = "Preencha o preço de venda.")]
        public decimal PrecoVenda { get; set; }

        [Required(ErrorMessage = "Preencha a quantidade em estoque.")]
        public int QuantidadeEstoque { get; set; }

        [Required(ErrorMessage = "Selecione a unidade de medida.")]
        public int UnidadeMedidaId { get; set; }

        [Required(ErrorMessage = "Selecione o grupo.")]
        public int GrupoProdutoId { get; set; }

        [Required(ErrorMessage = "Selecione a marca.")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "Selecione o fornecedor.")]
        public int FornecedorId { get; set; }

        [Required(ErrorMessage = "Selecione o local de armazenamento.")]
        public int LocalArmazenamentoId { get; set; }

        public bool Ativo { get; set; }

        public string Imagem { get; set; }
    }
}