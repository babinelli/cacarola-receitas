using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APC_BarbaraCoscolim_P8_v1.Models
{
    public partial class Ingrediente
    {
        #region Scalar properties
        public int IngredienteID { get; set; }

        [Display(Name = "Receita ID")]
        public int ReceitaID { get; set; }

        [Display(Name = "Unidade de medida")]
        public int UnidadeMedidaID { get; set; }

        [Display(Name = "Ingrediente")]
        public string Nome { get; set; }

        public double Quantidade { get; set; }
        #endregion

        #region Navigation properties
        // 1 ingrediente --> 1 receita
        public virtual Receita Receita { get; set; }

        // 1 ingrediente --> 1 unidade de medida
        public virtual UnidadeMedida UnidadeMedida { get; set; }
        #endregion
    }
}