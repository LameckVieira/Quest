using System;
using System.Collections.Generic;

namespace Quest_WebApi.DbModels
{
    public partial class Perguntas
    {
        public Perguntas()
        {
            PerguntaUsuarios = new HashSet<PerguntaUsuario>();
        }

        public int IdPergunta { get; set; }
        public string Pergunta { get; set; }
        public string[] Alternativas { get; set; }
        public string Reposta { get; set; }
        public int? IdPTema { get; set; }

        public virtual Tema IdPTemaNavigation { get; set; }
        public virtual ICollection<PerguntaUsuario> PerguntaUsuarios { get; set; }
    }
}
