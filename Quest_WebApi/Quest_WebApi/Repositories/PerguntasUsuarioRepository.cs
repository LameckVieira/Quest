using Quest_WebApi.DbModels;  
using Quest_WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Quest_WebApi.Repositories
{
    public class PerguntasUsuarioRepository : IPerguntasUsuarioRepository
    {
        QuestContext ctx = new QuestContext();

        public void Atualizar(int id, PerguntaUsuario PerguntasUsuarioAtualizada)
        {
            PerguntaUsuario perguntasUsuarioBuscados = ctx.PerguntaUsuarios.Find(id);

            if (perguntasUsuarioBuscados.IdRegistro != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntasUsuarioBuscados.IdRegistro = PerguntasUsuarioAtualizada.IdRegistro;
            }

            if (perguntasUsuarioBuscados.IdPuPergunta != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntasUsuarioBuscados.IdPuPergunta = PerguntasUsuarioAtualizada.IdPuPergunta;
            }

            if (perguntasUsuarioBuscados.IdPuUsuarioPartida != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntasUsuarioBuscados.IdPuUsuarioPartida = PerguntasUsuarioAtualizada.IdPuUsuarioPartida;
            }
            if (perguntasUsuarioBuscados.Status != null)
            {
                // Atribui os novos valores aos campos existentes
                perguntasUsuarioBuscados.Status = PerguntasUsuarioAtualizada.Status;
            }


            // Atualiza o Usuariol que foi buscado
            ctx.PerguntaUsuarios.Update(perguntasUsuarioBuscados);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public PerguntaUsuario BuscarPeloResultado(int nome)
        {
            return ctx.PerguntaUsuarios.FirstOrDefault(u => u.IdRegistro == nome);
        }

        public PerguntaUsuario BuscarPorId(int id)
        {
            return ctx.PerguntaUsuarios.FirstOrDefault(u => u.IdPuUsuarioPartida == id);
        }

        public void Cadastrar(PerguntaUsuario novaPerguntasUsuario)
        {
            // Adiciona este novoUsuariol
            ctx.PerguntaUsuarios.Add(novaPerguntasUsuario);

            // Salva as informações para serem gravas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            // Busca um Usuariol através do seu id
            PerguntaUsuario perguntasUsuarioBuscados = ctx.PerguntaUsuarios.Find(id);

            // Remove o Usuariol que foi buscado
            ctx.PerguntaUsuarios.Remove(perguntasUsuarioBuscados);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        public List<PerguntaUsuario> Listar()
        {
            return ctx.PerguntaUsuarios.ToList();
        }
    }
}