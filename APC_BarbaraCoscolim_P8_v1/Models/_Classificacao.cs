using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APC_BarbaraCoscolim_P8_v1.Models;

namespace APC_BarbaraCoscolim_P8_v1.Models
{
    public partial class Classificacao
    {
        #region Methods
        public static double CalcularAvaliacaoReceita(int? id)
        {
            CacarolaReceitaContext db = new CacarolaReceitaContext();

            var avaliacoes = db.Classificacao.Where(n => n.ReceitaID == id).Count();

            // Se já existirem avaliações, calcula a média
            if (avaliacoes > 0)
            {
                var notaMedia = db.Classificacao.Where(n => n.ReceitaID == id).Average(n => n.NotaClassificacao);
                double media = Math.Ceiling(notaMedia);
                return media;
            }
            // Se ainda não houverem avaliações, a "média" é zero
            else
            {
                return 0;
            }
        }
        #endregion
    }
}