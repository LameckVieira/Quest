﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Quest_WebApi.Domains
{
    public partial class PerguntasUsuario
    {
        public int IdPerguntasUsuario { get; set; }
        public int? IdPartida { get; set; }
        public int? IdUsuario { get; set; }
        public int Resultado { get; set; }

        public virtual Partida IdPartidaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}