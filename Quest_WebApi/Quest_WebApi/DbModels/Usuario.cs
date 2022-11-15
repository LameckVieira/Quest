using System;
using System.Collections.Generic;

namespace Quest_WebApi.DbModels
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
