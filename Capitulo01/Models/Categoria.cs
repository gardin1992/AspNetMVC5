﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitulo01.Models
{
    public class Categoria
    {
        public long CategoriaId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}