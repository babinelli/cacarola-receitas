using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APC_BarbaraCoscolim_P8_v1.Models
{
    public class Receita
    {
        #region Scalar properties
        [Display(Name = "Receita")]
        public int ReceitaID { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaID { get; set; }

        [Display(Name = "Dificuldade")]
        public int DificuldadeID { get; set; }

        [Display(Name = "Utilizador")]
        public string UserID { get; set; }

        [Display(Name = "Receita")]
        public string NomeReceita { get; set; }

        [Display(Name = "Modo de preparo")]
        public string ModoPreparo { get; set; }

        [Display(Name = "Tempo de preparo (em minutos)")]
        public int TempoPreparo { get; set; }

        [Display(Name = "Ingredientes")]
        public List<Ingrediente> ListaIngredientes { get; set; }
        #endregion

        #region Navigation properties
        // 1 receita --> n ingredientes
        public virtual List<Ingrediente> Ingredientes { get; set; }

        // 1 receita --> 1 categoria
        public virtual Categoria Categoria { get; set; }

        // 1 receita --> 1 dificuldade
        public virtual Dificuldade Dificuldade { get; set; }

        // 1 receita --> n comentarios
        public virtual List<Comentario> Comentarios { get; set; }

        // 1 receita --> n classificação
        public virtual List<Classificacao> Classificacoes { get; set; }

        #endregion
    }
}