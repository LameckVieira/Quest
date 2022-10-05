using System;
using System.Collections.Generic;

#nullable disable

namespace Quest_WebApi.Domains
{
    public partial class Categoria
    {
        public Categoria()
        {
            Temas = new HashSet<Tema>();
        }

        public int IdCategorias { get; set; }
        public string NomeCategoria { get; set; }

        public virtual ICollection<Tema> Temas { get; set; }
    }
}
