using System;
using System.Collections.Generic;

#nullable disable

namespace Quest_WebApi.Domains
{
    public partial class Tema
    {
        public Tema()
        {
            Pergunta = new HashSet<Pergunta>();
        }

        public int IdTema { get; set; }
        public int? IdCategorias { get; set; }
        public string NomeTema { get; set; }

        public virtual Categoria IdCategoriasNavigation { get; set; }
        public virtual ICollection<Pergunta> Pergunta { get; set; }
    }
}
