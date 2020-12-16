using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APC_BarbaraCoscolim_P8_v1.Models
{
    public class Dificuldade
    {
        #region Scalar properties
        [Display(Name = "Dificuldade")]
        public int DificuldadeID { get; set; }

        [Display(Name = "Dificuldade")]
        public string NomeDificuldade { get; set; }
        #endregion

        #region Navigation properties
        // 1 dificuldade --> n receitas
        public virtual List<Receita> Receitas { get; set; }
        #endregion
    }
}