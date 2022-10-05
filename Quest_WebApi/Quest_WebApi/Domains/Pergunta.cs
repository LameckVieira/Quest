using System;
using System.Collections.Generic;

#nullable disable

namespace Quest_WebApi.Domains
{
    public partial class Pergunta
    {
        public int IdPergunta { get; set; }
        public int? IdTema { get; set; }
        public string Perguntas { get; set; }
        public string Alternativa { get; set; }
        public string Resposta { get; set; }

        public virtual Tema IdTemaNavigation { get; set; }
    }
}
