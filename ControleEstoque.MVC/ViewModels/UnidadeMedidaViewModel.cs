using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.MVC.ViewModels
{
    public class UnidadeMedidaViewModel
    {
        [Key]
        public int UnidadeMedidaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(150, ErrorMessage = "Descrição máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Descrição mínimo 2 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Sigla")]
        [MaxLength(3, ErrorMessage = "Sigla máximo 3 caracteres")]
        public string Sigla { get; set; }

        public bool Ativo { get; set; }
    }
}