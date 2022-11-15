using System;
using System.Collections.Generic;

namespace Quest_WebApi.DbModels
{
    public partial class Categoria
    {
        public Categoria()
        {
            Temas = new HashSet<Tema>();
        }

        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }

        public virtual ICollection<Tema> Temas { get; set; }
    }
}
