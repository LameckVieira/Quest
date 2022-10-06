using System;
using System.Collections.Generic;

#nullable disable

namespace Quest_WebApi.Domains
{
    public partial class Partida
    {
        public Partida()
        {
            PerguntasUsuarios = new HashSet<PerguntasUsuario>();
            UsuarioPartida = new HashSet<UsuarioPartida>();
        }

        public int IdPartida { get; set; }
        public int Pontuacao { get; set; }

        public virtual ICollection<PerguntasUsuario> PerguntasUsuarios { get; set; }
        public virtual ICollection<UsuarioPartida> UsuarioPartida { get; set; }
    }
}
