using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APC_BarbaraCoscolim_P8_v1.Models
{
    public partial class Classificacao
    {
        #region Scalar properties
        public int ClassificacaoID { get; set; }

        [Display(Name = "Receita")]
        public int ReceitaID { get; set; }

        [Display(Name = "Nota")]
        [Range(1,5)]
        public int NotaClassificacao { get; set; }

        [Display(Name = "Utilizador")]
        public string UserID { get; set; }
        #endregion

        #region Navigation properties
        // 1 nota classificação --> 1 receita 
        public virtual Receita Receita { get; set; }
        #endregion
    }
}