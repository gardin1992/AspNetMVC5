using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Tabelas;

namespace Persistencia.DAL.Tabelas
{
    public class CategoriaDAL
    {

        private EFContext context = new EFContext();

        public IQueryable<Categoria> ObterCategoriasClassificadosPorNome()
        {

            return context.Categorias.OrderBy(b => b.Nome);
        }

    }
}
