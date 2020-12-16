using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APC_BarbaraCoscolim_P8_v1.Models
{
    public class UnidadeMedida
    {
        #region Scalar properties
        [Display(Name = "Unidade de medida")]
        public int UnidadeMedidaID { get; set; }

        [Display(Name = "Unidade de medida")]
        public string Unidade { get; set; }

        public string Descricao { get; set; }
        #endregion

        #region Navigation properties
        // 1 unidade de medida --> n ingredientes
        public virtual List<Ingrediente> Ingredientes { get; set; }
        #endregion
    }
}