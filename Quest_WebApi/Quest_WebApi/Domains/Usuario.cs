using System;
using System.Collections.Generic;

#nullable disable

namespace Quest_WebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            PerguntasUsuarios = new HashSet<PerguntasUsuario>();
            UsuarioPartida = new HashSet<UsuarioPartidum>();
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<PerguntasUsuario> PerguntasUsuarios { get; set; }
        public virtual ICollection<UsuarioPartidum> UsuarioPartida { get; set; }
    }
}
