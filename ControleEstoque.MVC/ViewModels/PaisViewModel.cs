using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.MVC.ViewModels
{
    public class PaisViewModel
    {
        [Key]
        public int PaisId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descricao")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Código")]
        [MaxLength(3, ErrorMessage = "Máximo 3 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Codigo { get; set; }

        public bool Ativo { get; set; }
       //public IEnumerable<Estado> Estados { get; set; }
    }
}