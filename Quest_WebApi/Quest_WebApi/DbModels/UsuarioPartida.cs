using System;
using System.Collections.Generic;

namespace Quest_WebApi.DbModels
{
    public partial class UsuarioPartida
    {
        public UsuarioPartida()
        {
            PerguntaUsuarios = new HashSet<PerguntaUsuario>();
        }

        public int IdUsuariioPartida { get; set; }
        public int? IdUpUsuario { get; set; }
        public int? IdUpPartida { get; set; }
        public string Resultado { get; set; }

        public virtual ICollection<PerguntaUsuario> PerguntaUsuarios { get; set; }
    }
}
