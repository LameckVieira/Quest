using Quest_WebApi.Contexts;
using Quest_WebApi.Domains;
using Quest_WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Quest_WebApi.Repositories
{
    public class PerguntasUsuarioRepository : IPerguntasUsuarioRepository
    {
        QuestContext ctx = new QuestContext();

        public void Atualizar(int id, PerguntasUsuario PerguntasUsuarioAtualizada)
        {
            PerguntasUsuario perguntasUsuarioBuscados = ctx.PerguntasUsuarios.Find(id);

            if (perguntasUsuarioBuscados.IdPerguntasUsuario != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntasUsuarioBuscados.IdPerguntasUsuario = PerguntasUsuarioAtualizada.IdPerguntasUsuario;
            }

            if (perguntasUsuarioBuscados.IdPartida != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntasUsuarioBuscados.IdPartida = PerguntasUsuarioAtualizada.IdPartida;
            }

            if (perguntasUsuarioBuscados.IdUsuario != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntasUsuarioBuscados.IdUsuario = PerguntasUsuarioAtualizada.IdUsuario;
            }
            if (perguntasUsuarioBuscados.Resultado != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntasUsuarioBuscados.Resultado = PerguntasUsuarioAtualizada.Resultado;
            }


            // Atualiza o Usuariol que foi buscado
            ctx.PerguntasUsuarios.Update(perguntasUsuarioBuscados);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public PerguntasUsuario BuscarPeloResultado(int nome)
        {
            return ctx.PerguntasUsuarios.FirstOrDefault(u => u.Resultado == nome);
        }

        public PerguntasUsuario BuscarPorId(int id)
        {
            return ctx.PerguntasUsuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(PerguntasUsuario novaPerguntasUsuario)
        {
            // Adiciona este novoUsuariol
            ctx.PerguntasUsuarios.Add(novaPerguntasUsuario);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um Usuariol através do seu id
            PerguntasUsuario perguntasUsuarioBuscados = ctx.PerguntasUsuarios.Find(id);

            // Remove o Usuariol que foi buscado
            ctx.PerguntasUsuarios.Remove(perguntasUsuarioBuscados);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<PerguntasUsuario> Listar()
        {
            return ctx.PerguntasUsuarios.ToList();
        }
    }
}