using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Tabelas;
using System.Data.Entity;

namespace Persistencia.DAL.Tabelas
{
    public class CategoriaDAL
    {

        private EFContext context = new EFContext();

        public IQueryable<Categoria> ObterCategoriasClassificadosPorNome()
        {
            return context.Categorias.OrderBy(b => b.Nome);
        }

        public Categoria ObterCategoriaPorId(long id)
        {
            return context.Categorias.Find(id);
        }

        public void GravarCategoria(Categoria categoria)
        {
            if (categoria.CategoriaId == null)
            {
                context.Categorias.Add(categoria);
            }
            else
            {
                context.Entry(categoria).State = EntityState.Modified;
            }

            context.SaveChanges();
        }

        public Categoria EliminarCategoriaPorId(long id)
        {
            Categoria categoria = ObterCategoriaPorId(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();

            return categoria;
        }

    }
}
