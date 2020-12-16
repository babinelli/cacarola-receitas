using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace APC_BarbaraCoscolim_P8_v1.Models
{
    public class CacarolaReceitaContext : DbContext
    {
        public CacarolaReceitaContext()
            : base("name = CacarolaReceitas")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Desativar a pluralização das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Classificacao> Classificacao { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Dificuldade> Dificuldade { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
        public DbSet<Receita> Receita { get; set; }
        public DbSet<UnidadeMedida> UnidadeMedida { get; set; }

    }
}