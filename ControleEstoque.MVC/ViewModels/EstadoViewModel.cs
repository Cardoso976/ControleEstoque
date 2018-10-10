using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.MVC.ViewModels
{
    public class EstadoViewModel
    {
        [Key]
        public int EstadoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(150, ErrorMessage = "Descrição máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Descrição mínimo 2 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Código")]
        [MaxLength(3, ErrorMessage = "Código máximo 3 caracteres")]
        [MinLength(2, ErrorMessage = "Código mínimo 2 caracteres")]
        public string Uf { get; set; }

        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Preencha o campo País")]
        public int PaisId { get; set; }

        public Pais Pais { get; set; }
    }
}