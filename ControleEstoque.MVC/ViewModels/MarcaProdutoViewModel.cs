﻿using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.MVC.ViewModels
{
    public class MarcaProdutoViewModel
    {
        [Key]
        public int MarcaProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(150, ErrorMessage = "Descrição máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Descrição mínimo 2 caracteres")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
    }
}