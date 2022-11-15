using System;
using System.Collections.Generic;

namespace Quest_WebApi.DbModels
{
    public partial class Tema
    {
        public Tema()
        {
            Pergunta = new HashSet<Perguntas>();
        }

        public int IdTema { get; set; }
        public string NomeTema { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<Perguntas> Pergunta { get; set; }
    }
}
