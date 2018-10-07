using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.MVC.ViewModels
{
    public class PaisViewModel
    {
        [Key]
        public int PaisId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(150, ErrorMessage = "Descrição máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Descrição mínimo 2 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Código")]
        [MaxLength(3, ErrorMessage = "Código máximo 3 caracteres")]
        [MinLength(2, ErrorMessage = "Código mínimo 2 caracteres")]
        public string Codigo { get; set; }

        public bool Ativo { get; set; }
       //public IEnumerable<Estado> Estados { get; set; }
    }
}