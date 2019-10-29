using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Modelo.Cadastros;
using Modelo.Tabelas;

namespace Capitulo01.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") 
        {
            Database.SetInitializer<EFContext>(
                new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}