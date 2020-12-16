using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APC_BarbaraCoscolim_P8_v1;

namespace APC_BarbaraCoscolim_P8_v1.Models
{
    public partial class Ingrediente
    {
        public static void CriarListaIngredientes(int receitaId, List<Ingrediente> listaIngredientes)
        {
            CacarolaReceitaContext db = new CacarolaReceitaContext();

            foreach (var ingrediente in listaIngredientes)
            {
                ingrediente.ReceitaID = receitaId;
            }
            
            db.Ingrediente.AddRange(listaIngredientes);
            db.SaveChanges();
        }

        public static void AtualizarListaIngredientes(List<Ingrediente> listaIngredientes, int receitaId)
        {
            DeletarListaIngredientes(receitaId);
            CriarListaIngredientes(receitaId, listaIngredientes);
        }

        private static void DeletarListaIngredientes(int receitaId)
        {
            CacarolaReceitaContext db = new CacarolaReceitaContext();

            var ingredientesAntigos = db.Ingrediente.Where(i => i.ReceitaID == receitaId);

            db.Ingrediente.RemoveRange(ingredientesAntigos);
            db.SaveChanges();
        }

        public static void DeletarIngrediente(int ingredienteId)
        {
            CacarolaReceitaContext db = new CacarolaReceitaContext();

            var ingrediente = db.Ingrediente.Where(i => i.IngredienteID == ingredienteId).First();
            db.Ingrediente.Remove(ingrediente);
            db.SaveChanges();
        }
    }
}