using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APC_BarbaraCoscolim_P8_v1.Models
{
    public class Comentario
    {
        #region Scalar properties
        [Display(Name = "Comentário")]
        public int ComentarioID { get; set; }

        [Display(Name = "Receita")]
        public int ReceitaID { get; set; }

        [Display(Name = "Comentado por")]
        public string UserID { get; set; }

        [Display(Name = "Comentário")]
        public string TextoComentario { get; set; }
        #endregion

        #region Navigation properties
        // 1 comentario --> 1 receita
        public virtual Receita Receita { get; set; }
        #endregion
    }
}