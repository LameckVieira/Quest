using System;
using System.Collections.Generic;

namespace Quest_WebApi.DbModels
{
    public partial class PerguntaUsuario
    {
        public int IdRegistro { get; set; }
        public int? IdPuPergunta { get; set; }
        public int? IdPuUsuarioPartida { get; set; }
        public string Status { get; set; }

        public virtual Perguntas IdPuPerguntaNavigation { get; set; }
        public virtual UsuarioPartida IdPuUsuarioPartidaNavigation { get; set; }
    }
}
