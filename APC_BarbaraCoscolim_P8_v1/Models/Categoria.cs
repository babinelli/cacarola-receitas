using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APC_BarbaraCoscolim_P8_v1.Models
{
    public class Categoria
    {
        #region Scalar properties
        [Display(Name = "Categoria")]
        public int CategoriaID { get; set; }

        [Display(Name = "Categoria")]
        public string NomeCategoria { get; set; }
        #endregion

        #region Navigation properties
        // 1 categoria --> n receitas
        public virtual List<Receita> Receitas { get; set; }
        #endregion
    }
}